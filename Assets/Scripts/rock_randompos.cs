using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rock_randompos : MonoBehaviour
{
    float dist;
    public GameObject rock1;
    public GameObject[] rocks;
    GameObject rockfirst;
    int count = 1;
    int index;
    bool bolflag = true;
    ArrayList used = new ArrayList();

    Vector3[] locations;
    // Start is called before the first frame update

    void Start()
    {
        locations = new Vector3[30];
        rocks = new GameObject[20];
        locations[0] = new Vector3(46.8f, -23.154f, -3.872f);
        locations[1] = new Vector3(43.93f, -23.154f, 1.51f);
        locations[2] = new Vector3(45.71f, -23.154f, 26.4f);
        locations[3] = new Vector3(48.5f, -23.154f, 32.1f);
        locations[4] = new Vector3(40.19f, -23.15f, 47.5f);
        locations[5] = new Vector3(40.19f, -23.154f, 52.7f);
        locations[6] = new Vector3(38.38f, -23.154f, 75.9f);
        locations[7] = new Vector3(40.16f, -23.154f, 80.55f);

        locations[8] = new Vector3(40.16f, -23.154f, 100.2f);
        locations[9] = new Vector3(37.3f, -23.154f, 116.1f);

        locations[10] = new Vector3(22.3f, -23.154f, 116.1f);

        locations[11] = new Vector3(19.96f, -23.65f, 121.09f);
        locations[12] = new Vector3(19.96f, -23.65f, 155.5f);

        locations[13] = new Vector3(19.96f, -23.65f, 165.6f);

        locations[14] = new Vector3(37.8f, -23.65f, 168.7f);

        locations[15] = new Vector3(36.3f, -23.65f, 178.7f);
        locations[16] = new Vector3(29.5f, -23.65f, 192.8f);

        locations[17] = new Vector3(22f, -23.65f, 203.6f);
        locations[18] = new Vector3(16.8f, -23.65f, 209.6f);
        locations[19] = new Vector3(21.4f, -23.65f, 232.6f);
        locations[20] = new Vector3(18.64f, -23.65f, 248.7f);
        locations[21] = new Vector3(38.9f, -23.65f, 254.9f);

        locations[22] = new Vector3(38.9f, -23.65f, 278.11f);
        locations[23] = new Vector3(27.98f, -23.65f, 278.9f);
        locations[24] = new Vector3(28.34f, -23.65f, 297.9f);
        locations[25] = new Vector3(26.84f, -23.65f, 313.19f);
        locations[26] = new Vector3(38.3f, -23.65f, 323.13f);
        locations[27] = new Vector3(38.3f, -23.65f, 340.19f);
        locations[28] = new Vector3(38.3f, -23.65f, 352f);
        locations[29] = new Vector3(25.7f, -23.65f, 358.5f);
        print("location" + locations[0]);

       // rock1.transform.position = locations[0];
        index = (int)Random.Range(0, 19);
        print(index);
        used.Add(index);


    }

    // Update is called once per frame
    void Update()
    {
        // var position = new Vector3(Random.Range(-16, 10), 0, Random.Range(-12, 9));
        // var radius = Random.Range(0, 2);


        if(bolflag == true)
        {
            for (int n = 0; n < 20; n++)
            {
                index = (int)Random.Range(0, 29);
                while (used.Contains(index) == true)
                {
                    print("same!!");
                    index = (int)Random.Range(0, 29);
                }
                used.Add(index);
                rockfirst = rock1;
                rocks[n] = Instantiate(rock1, locations[index], Quaternion.LookRotation(transform.position));
                print(index);
                //rockfirst.SetActive(false);
                count += 1;

            }
            bolflag = false;
        }




    }
}



