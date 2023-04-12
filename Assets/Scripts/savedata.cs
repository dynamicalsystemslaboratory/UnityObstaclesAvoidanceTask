using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class savedata : MonoBehaviour
{
    // Start is called before the first frame update
    public OVRCameraRig cameraRig;
    public OVRPlayerController player;

    Vector3 av;
    Vector3 acceleration;
    bool timer =false;
    float accelerationx;
    float accelerationy;
    float accelerationz;
    float av1;
    float av2;
    float av3;
    float directionx;
    float directiony;
    float directionz;
    float headOrienx;
    float headOrieny;
    float headOrienz;

    int collisioncount;
    public string condition;
    float starttime;

    //public Text txt1;
   // public Text txt2;


    void Start()
    {
        CSVManager.VerifyDirectory();
        CSVManager.VerifyFile();
        PlayerPrefs.SetInt("User", 1);
        starttime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {





   
        //Vector3 av = OVRManager.display.angularAcceleration;
        //txt.text = "angulara" + av;
        //Vector3 ve = OVRManager.display.veolocity;
        //txt2.text = "linearvelocity" + ve;
        collisioncount = collide.collisioncount;
        av1 = OVRManager.display.angularVelocity.x;
        av2 = OVRManager.display.angularVelocity.y;
        av3 = OVRManager.display.angularVelocity.z;

       // OVRManager.display.angula

        headOrienx =cameraRig.centerEyeAnchor.rotation.x;
        //OVRPose hmdPose = OVRManager.tracker.GetPose().orientation.

        headOrieny = cameraRig.centerEyeAnchor.rotation.y;
        headOrienz = cameraRig.centerEyeAnchor.rotation.z;

        //txt2.text = "HeadangularVx" +c av1;
       // float acceleration = OVRInput.GetLocalControllerAngularVelocity(OVRInput.Controller.LTouch).x;

        accelerationx = OVRInput.GetLocalControllerAngularVelocity(OVRInput.Controller.LTouch).x;
        accelerationy = OVRInput.GetLocalControllerAngularVelocity(OVRInput.Controller.LTouch).y;
        accelerationz = OVRInput.GetLocalControllerAngularVelocity(OVRInput.Controller.LTouch).z;
        //txt3.text = "controllerVx" + accelerationx;
        //float directionx = OVRInput.GetLocalControllerRotation(OVRInput.Controller.LTouch).x;
       directionx = OVRInput.GetLocalControllerRotation(OVRInput.Controller.LTouch).x;
       directiony = OVRInput.GetLocalControllerRotation(OVRInput.Controller.LTouch).y;
       directionz = OVRInput.GetLocalControllerRotation(OVRInput.Controller.LTouch).z;
        
        if (timer == false)
        {
            StartCoroutine(SaveReport());
        }

        //if (OVRInput.Get(OVRInput.Button.One) || Input.GetKeyDown(KeyCode.B))
        //{
        //text.text = collisioncount.ToString();
        //txt1.text = "bodya" + accelerationx.ToString() + " " + accelerationx.ToString() + " " + accelerationx.ToString();
        //txt2.text = "bodyorien" + directionx.ToString() + " " + directiony.ToString() + " " + directionz.ToString();
       


    }
    

    string[] GetReportLine(Vector3 av, Vector3 acceleration)
    {
        //int userid = PlayerPrefs.GetInt("User");
        string[] returnable = new string[14];
        if (Time.time - starttime >= 13)
        {
            collisioncount = collide.collisioncount;
            returnable[0] = condition;
            returnable[1] = av1.ToString();
            returnable[2] = av2.ToString();
            returnable[3] = av3.ToString();
            returnable[4] = accelerationx.ToString();
            returnable[5] = accelerationy.ToString();
            returnable[6] = accelerationz.ToString();
            returnable[7] = directionx.ToString();
            returnable[8] = directiony.ToString();
            returnable[9] = directionz.ToString();
            returnable[10] = headOrienx.ToString();
            returnable[11] = headOrieny.ToString();
            returnable[12] = headOrienz.ToString();
            returnable[13] = collisioncount.ToString();
            return returnable;
        }
        else
        {
            collide.collisioncount = 0;
            collisioncount = collide.collisioncount;
           // print("loading");
            returnable[0] = "loading";
            returnable[1] = av1.ToString();
            returnable[2] = av2.ToString();
            returnable[3] = av3.ToString();
            returnable[4] = accelerationx.ToString();
            returnable[5] = accelerationy.ToString();
            returnable[6] = accelerationz.ToString();
            returnable[7] = directionx.ToString();
            returnable[8] = directiony.ToString();
            returnable[9] = directionz.ToString();
            returnable[10] = headOrienx.ToString();
            returnable[11] = headOrieny.ToString();
            returnable[12] = headOrienz.ToString();
            returnable[13] = collisioncount.ToString();
            return returnable;
        }

    }

    IEnumerator SaveReport()
    {
        
        timer = true;

        yield return new WaitForSeconds(1/180f);

            CSVManager.AppendToReport(GetReportLine(av, acceleration));
           print("saving");
            timer = false;
        
        yield return new WaitForSeconds(30f);     

       SaveReport();
    }


}

