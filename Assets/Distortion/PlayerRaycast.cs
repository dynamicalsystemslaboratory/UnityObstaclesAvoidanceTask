using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO.Ports;

public class PlayerRaycast : MonoBehaviour
{
    private SerialPort sp;

    public string strArduino = "xx";

    public string s1 = "";
    public string s2 = "";
    public string s3 = "";

    [SerializeField] private float distanceToSee = 10;
    private RaycastHit raycastHit;

    // Due to the possibility of the loss of sensitivity to vibration, here a time stamp and timer speed are initialized.
    // These are used to modulate the vibration in such a way that vibrations occur for 200 ms and then stop for 200 ms,
    // where this cycle is repeated while a Raycast is in the triggered state.
    private float timerSpeed = 0.2F;
    private float[] timeStamp = new float[10];

    // Here, arrays are initialized, which store values that are referenced by the code below it.
    // identityVect is simply used as a unity vector
    // numberVect stores values ranging from 0 to 9, in order to be used within the iteration process to select different actuators or
    // frequencies in the iteration code below.
    // distanceVect stores values that are used for distance mapping, where each value corresponds to a different vibration frequency
    // actualVect stores values which determine the actual state of a given actuator: 1 for on, 0 for off
    // desiredVect stores values which indicate whether an actuator should be turned on or off: 1 for on, 0 for off
    private float[] identityVect = { 1F, 1F, 1F, 1F, 1F, 1F, 1F, 1F, 1F, 1F };
    private int[] numberVect = { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
    private float[] distanceVect = { 1F, 2F, 3F, 4F, 5F, 6F, 7F, 8F, 9F, 10F };
    private int[] actualVect = { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
    private int[] desiredVect = { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
    private float[] differenceVect = { 0F, 0F, 0F, 0F, 0F, 0F, 0F, 0F, 0F, 0F };
    private float min = 0;

    // "freqTemp" is a temporary variable that holds a value that indicates which frequency of vibration to be triggered in
    // an activated actuator
    private int freqTemp = 0;
    float[] frequencyVect = { 0F, 0F, 0F, 0F, 0F, 0F, 0F, 0F, 0F, 0F };

    private LayerMask mask;

    public MeshFilter meshFilter;

    private List<Vector3> upperLeftNormals = new List<Vector3>();
    private List<Vector3> upperLeftVertices = new List<Vector3>();
    private List<bool> rayHitUpperLeft = new List<bool>();
    private List<float> hitDistanceUpperLeft = new List<float>();

    private List<Vector3> upperRightNormals = new List<Vector3>();
    private List<Vector3> upperRightVertices = new List<Vector3>();
    private List<bool> rayHitUpperRight = new List<bool>();
    private List<float> hitDistanceUpperRight = new List<float>();

    private List<Vector3> leftNormals = new List<Vector3>();
    private List<Vector3> leftVertices = new List<Vector3>();
    private List<bool> rayHitLeft = new List<bool>();
    private List<float> hitDistanceLeft = new List<float>();

    private List<Vector3> rightNormals = new List<Vector3>();
    private List<Vector3> rightVertices = new List<Vector3>();
    private List<bool> rayHitRight = new List<bool>();
    private List<float> hitDistanceRight = new List<float>();

    private List<Vector3> lowerRightNormals = new List<Vector3>();
    private List<Vector3> lowerRightVertices = new List<Vector3>();
    private List<bool> rayHitLowerRight = new List<bool>();
    private List<float> hitDistanceLowerRight = new List<float>();

    private List<Vector3> lowerLeftNormals = new List<Vector3>();
    private List<Vector3> lowerLeftVertices = new List<Vector3>();
    private List<bool> rayHitLowerLeft = new List<bool>();
    private List<float> hitDistanceLowerLeft = new List<float>();

    public bool showUpperLeftRays;
    public bool showUpperRightRays;
    public bool showLowerLeftRays;
    public bool showLowerRightRays;
    public bool showLeftRays;
    public bool showRightRays;

    // For optimization purpose of linq boolean comparison
    private bool isHitting = true;
    private List<int> hitIndex = new List<int>();

    public Transform[] upperLeftRaycastTransfrom;
    public Transform[] upperRightRaycastTransfrom;
    public Transform[] lowerRightRaycastTransfrom;
    public Transform[] lowerLeftRaycastTransfrom;

    // Start is called before the first frame update
    void Start()
    {
        mask = ~LayerMask.GetMask("Ignore Raycast");
        UpdateVerticesAndNormals();
        sp = new SerialPort("COM3", 115200);
        OpenConnection();
    }

    public void OpenConnection()
    {
        if (sp != null)
        {
            if (sp.IsOpen)
            {
                sp.Close();
                Debug.Log("Closing port because it's already open");
            }

            else
            {
                sp.Open();
                sp.ReadTimeout = 100;
                Debug.Log("port open");
            }
        }

        else
        {
            if (sp.IsOpen)
            {
                Debug.Log("Port is already open");
            }

            else
            {
                Debug.Log("port == null");
            }
        }
    }

    public void OnApplicationQuit()
    {
        if(sp.IsOpen)
            sp.Close();
    }

    public void SendAny(string s3)
    {
        if (sp.IsOpen)
            sp.Write(s3);
    }

    public void SendNo()
    {
        if (sp.IsOpen)
            sp.Write("no");
    }

    // Update is called once per frame
    void Update()
    {
        
        // Every frame this function updates vertices position and normals, let say
        // if player turns then we have to update vertices and normals
        UpdateVerticesAndNormals();
        // For debug purpose only, you can enable booleans inspector to show rays
        // from perticular section
        ShowRays();
        // Calculating Upper Left actuators
        UpdateActuators(1, rayHitUpperLeft, hitDistanceUpperLeft, upperLeftVertices, upperLeftNormals);
        UpdateActuators(2, rayHitUpperLeft, hitDistanceUpperLeft, upperLeftVertices, upperLeftNormals);
        // Calculating Upper Right actuators
        UpdateActuators(5, rayHitUpperRight, hitDistanceUpperRight, upperRightVertices, upperRightNormals);
        UpdateActuators(6, rayHitUpperRight, hitDistanceUpperRight, upperRightVertices, upperRightNormals);
        // Calculating Lower Right actuators
        UpdateActuators(7, rayHitLowerRight, hitDistanceLowerRight, lowerRightVertices, lowerRightNormals);
        UpdateActuators(8, rayHitLowerRight, hitDistanceLowerRight, lowerRightVertices, lowerRightNormals);
        // Calculating Lower Left actuators
        UpdateActuators(3, rayHitLowerLeft, hitDistanceLowerLeft, lowerLeftVertices, lowerLeftNormals);
        UpdateActuators(4, rayHitLowerLeft, hitDistanceLowerLeft, lowerLeftVertices, lowerLeftNormals);
        // Calculating Left actuators
        UpdateActuators(0, rayHitLeft, hitDistanceLeft, leftVertices, leftNormals);
        // Calculating Right actuators
        UpdateActuators(9, rayHitRight, hitDistanceRight, rightVertices, rightNormals);
        
        if (!System.Array.Exists(rayHitUpperLeft.ToArray(), element => element == isHitting) &&
            !System.Array.Exists(rayHitUpperRight.ToArray(), element => element == isHitting) &&
            !System.Array.Exists(rayHitLowerLeft.ToArray(), element => element == isHitting) &&
            !System.Array.Exists(rayHitUpperRight.ToArray(), element => element == isHitting) &&
            !System.Array.Exists(rayHitLeft.ToArray(), element => element == isHitting) &&
            !System.Array.Exists(rayHitRight.ToArray(), element => element == isHitting))
        {
            SendNo();
            for (int j = 0; j < actualVect.Length; j++)
            {
                actualVect[j] = 0;
            }
        }
    }

    void UpdateActuators(int actuatorIndex, List<bool> rays, List<float> distances, List<Vector3> vertices, List<Vector3> normals)
    {
        UpdateHitraysAndDistanceList(rays, distances, vertices, normals);
        hitIndex = GetHitIndexes(rays);
        
        if (hitIndex.Count > 0)
        {
            if (rays[hitIndex[0]])
            {
                CalculateActuatorFrequency(distances[hitIndex[0]], actuatorIndex);
            }
            else
            {
                desiredVect[actuatorIndex] = 0;
            }
            SendActuatorFrequency(actuatorIndex);
        }
    }

    void UpdateHitraysAndDistanceList(List<bool> hitRayList, List<float> distanceList, List<Vector3> vertices, List<Vector3> normals)
    {
        for (int i = 0; i < hitRayList.Count; i++)
        {
            hitRayList[i] = Physics.Raycast(vertices[i], normals[i], out raycastHit, distanceToSee, mask);
            if (hitRayList[i])
            {
                distanceList[i] = raycastHit.distance;
                Debug.DrawLine(vertices[i], raycastHit.point, Color.green);
            }
        }
    }

    void CalculateActuatorFrequency(float hitDistance, int actuatorIndex)
    {
        desiredVect[actuatorIndex] = 1;
        differenceVect[actuatorIndex] = Mathf.Abs(hitDistance * identityVect[actuatorIndex] - distanceVect[actuatorIndex]);
        min = Mathf.Min(differenceVect);
        freqTemp = System.Array.IndexOf(differenceVect, min);
        s1 = numberVect[actuatorIndex].ToString();
        if (frequencyVect[actuatorIndex] != freqTemp)
        {
            frequencyVect[actuatorIndex] = freqTemp;
        }
        s2 = frequencyVect[actuatorIndex].ToString();
        s3 = s1 + s2;
    }

    void SendActuatorFrequency(int actuatorIndex)
    {
        if (desiredVect[actuatorIndex] - actualVect[actuatorIndex] == 1)
        {
            if (Time.time - timeStamp[actuatorIndex] >= timerSpeed)
            {
                SendAny(s3);
                actualVect[actuatorIndex] = 1;
                timeStamp[actuatorIndex] = Time.time;
            }
        }

        if (actualVect[actuatorIndex] == 1)
        {
            if (Time.time - timeStamp[actuatorIndex] >= timerSpeed)
            {
                SendAny("n" + actuatorIndex);
                actualVect[actuatorIndex] = 0;
                timeStamp[actuatorIndex] = Time.time;
            }
        }
    }

    void UpdateVerticesAndNormals()
    {
        // Cleanning up all lists
        upperRightVertices.Clear();upperRightNormals.Clear();upperLeftVertices.Clear();
        upperLeftNormals.Clear();lowerLeftVertices.Clear();lowerLeftNormals.Clear();
        lowerRightVertices.Clear();lowerRightNormals.Clear();rayHitLowerLeft.Clear();
        rayHitLowerRight.Clear();rayHitUpperLeft.Clear();rayHitUpperRight.Clear();
        hitDistanceLowerLeft.Clear();hitDistanceLowerRight.Clear();hitDistanceUpperLeft.Clear();
        hitDistanceUpperRight.Clear(); leftVertices.Clear(); leftNormals.Clear();
        rayHitLeft.Clear(); hitDistanceLeft.Clear(); rightNormals.Clear();
        rayHitRight.Clear(); hitDistanceRight.Clear(); rightVertices.Clear();

        // UPPER LEFT
        for (int i = 0; i < upperLeftRaycastTransfrom.Length; i++)
        {
            upperLeftVertices.Add(upperLeftRaycastTransfrom[i].position);
            upperLeftNormals.Add(upperLeftRaycastTransfrom[i].forward);
            rayHitUpperLeft.Add(false);
            hitDistanceUpperLeft.Add(0);
        }

        // UPPER RIGHT
        for (int i = 0; i < upperRightRaycastTransfrom.Length; i++)
        {
            upperRightVertices.Add(upperRightRaycastTransfrom[i].position);
            upperRightNormals.Add(upperRightRaycastTransfrom[i].forward);
            rayHitUpperRight.Add(false);
            hitDistanceUpperRight.Add(0);
        }

        // LOWER RIGHT
        for (int i = 0; i < lowerRightRaycastTransfrom.Length; i++)
        {
            lowerRightVertices.Add(lowerRightRaycastTransfrom[i].position);
            lowerRightNormals.Add(lowerRightRaycastTransfrom[i].forward);
            rayHitLowerRight.Add(false);
            hitDistanceLowerRight.Add(0);
        }

        // LOWER LEFT
        for (int i = 0; i < lowerLeftRaycastTransfrom.Length; i++)
        {
            lowerLeftVertices.Add(lowerLeftRaycastTransfrom[i].position);
            lowerLeftNormals.Add(lowerLeftRaycastTransfrom[i].forward);
            rayHitLowerLeft.Add(false);
            hitDistanceLowerLeft.Add(0);
        }


        // LEFT
        leftVertices.Add(transform.position);
        leftNormals.Add(-transform.right.normalized);
        rayHitLeft.Add(false);
        hitDistanceLeft.Add(0);

        // RIGHT
        rightVertices.Add(transform.position);
        rightNormals.Add(transform.right.normalized);
        rayHitRight.Add(false);
        hitDistanceRight.Add(0);
    }

    void ShowRays()
    {
        if (showUpperLeftRays)
        {
            for (int i = 0; i < upperLeftVertices.Count; i++)
            {
                Debug.DrawRay(upperLeftVertices[i], upperLeftNormals[i]);
            }
        }

        if (showUpperRightRays)
        {
            for (int i = 0; i < upperRightVertices.Count; i++)
            {
                Debug.DrawRay(upperRightVertices[i], upperRightNormals[i]);
            }
        }

        if (showLowerRightRays)
        {
            for (int i = 0; i < lowerRightVertices.Count; i++)
            {
                Debug.DrawRay(lowerRightVertices[i], lowerRightNormals[i]);
            }
        }

        if (showLowerLeftRays)
        {
            for (int i = 0; i < lowerLeftVertices.Count; i++)
            {
                Debug.DrawRay(lowerLeftVertices[i], lowerLeftNormals[i]);
            }
        }

        if (showLeftRays)
        {
            for (int i = 0; i < leftVertices.Count; i++)
            {
                Debug.DrawRay(leftVertices[i], leftNormals[i]);
            }
        }

        if (showRightRays)
        {
            for (int i = 0; i < rightVertices.Count; i++)
            {
                Debug.DrawRay(rightVertices[i], rightNormals[i]);
            }
        }
    }

    List<int> GetHitIndexes(List<bool> array)
    {
        List<int> indexes = new List<int>();
        for (int i = 0; i < array.Count; i++)
        {
            if (array[i]) 
            {
                if (indexes.Count < 1)
                    indexes.Add(i);
                else
                    break;
            }
        }

        return indexes;
    }
}
