using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rock_random2 : MonoBehaviour
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
        locations = new Vector3[20];
        rocks = new GameObject[15];
        locations[0] = new Vector3(21.7f, -24.16f, 23.657f);//rotatey:180
        locations[1] = new Vector3(22.7f, -24.16f, 65.75f);
        locations[2] = new Vector3(35.4f, -24.16f, 113f);


        locations[3] = new Vector3(35.4f, -24.16f, 87.51f);
        locations[4] = new Vector3(35.99f, -24.16f,140.82f);
        locations[5] = new Vector3(43.15f, -24.16f, 158.92f);
        locations[6] = new Vector3(43.15f, -24.16f, 176.69f);
        locations[7] = new Vector3(35.78f, -24.16f, 192.6f);

        locations[8] = new Vector3(35.78f, -24.16f, 192.6f);
        locations[9] = new Vector3(21f, -24.16f, 192.6f);
        locations[10] = new Vector3(19.62f, -24.16f, 229.21f);

        locations[11] = new Vector3(19.62f, -24.16f, 255.6f);
        locations[12] = new Vector3(46.5f, -24.16f, 255.6f);
        locations[13] = new Vector3(46.82f, -24.16f, 286.7f);
        locations[14] = new Vector3(46.82f, -24.16f, 305.6f);
        locations[15] = new Vector3(40.2f, -24.16f, 361.1f);
        locations[16] = new Vector3(40.2f, -24.16f, 318.2f);
        locations[17] = new Vector3(25.6f, -24.2f, 363.16f);
        locations[18] = new Vector3(25.6f, -24.2f, 381f);
        locations[19] = new Vector3(42.17f, -24.2f, 381f);


       //print("location" + locations[0]);

        // rock1.transform.position = locations[0];
        //index = (int)Random.Range(0, 9);
        //print(index);
        //used.Add(index);


    }

    // Update is called once per frame
    void Update()
    {


        if (bolflag == true)
        {
            for (int n = 0; n < 15; n++)
            {
                index = (int)Random.Range(0, 19);
                while (used.Contains(index) == true)
                {
                    print("same!!");
                    index = (int)Random.Range(0, 19);
                }
                used.Add(index);
                rockfirst = rock1;
                rocks[n] = Instantiate(rock1, locations[index], Quaternion.identity);
                print(index);
                //rockfirst.SetActive(false);

               

            }
            bolflag = false;
        }




    }
}



