using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trashcan : MonoBehaviour
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
        locations = new Vector3[25];
        rocks = new GameObject[15];
        locations[0] = new Vector3(35.57f, -24.1f, 184.59f);
        locations[1] = new Vector3(20.1f, -24.1f, 164.4f);
        locations[2] = new Vector3(20.1f, -24.1f, 130.25f);


        locations[3] = new Vector3(35.44f, -24.1f, 130.25f);
        locations[4] = new Vector3(11.3f, -24.1f, 114.1f);
        locations[5] = new Vector3(48.3f, -24.1f, 114.1f);
        locations[6] = new Vector3(19.1f, -24.1f, 100.5f);
        locations[7] = new Vector3(23.7f, -24.1f, 64.8f);

        locations[8] = new Vector3(42.38f, -24.1f, 56.22f);
        locations[9] = new Vector3(42.38f, -24.1f, 30.4f);
        locations[10] = new Vector3(87.9f, -24.1f, 328.9f);
        locations[11] = new Vector3(22.2f, -24.1f, 328.9f);
        locations[12] = new Vector3(85.6f, -24.1f, 371.3f);
        locations[13] = new Vector3(46.47f, -24.1f, 4.8f);
        locations[14] = new Vector3(46.7f, -24.1f, -7.23f);
        locations[15] = new Vector3(14.8f, -24.1f, -4.6f);
        locations[16] = new Vector3(46.4f, -24.1f, -25.5f);
        locations[17] = new Vector3(46.4f, -24.1f, 87.9f);
        locations[18] = new Vector3(40.2f, -24.1f, 176.7f);
        locations[19] = new Vector3(41.7f, -24.1f, 206.3f);
        locations[20] = new Vector3(43.2f, -24.1f, 230.3f);
        locations[21] = new Vector3(14f, -24.1f,294.7f);
        locations[22] = new Vector3(48.3f, -24.1f, 289f);
        locations[23] = new Vector3(44.1f, -24.1f, 294.7f);
        locations[24] = new Vector3(44.1f, -24.1f, 307f);



        print("location" + locations[0]);

        // rock1.transform.position = locations[0];
        //index = (int)Random.Range(0, 9);
        print(index);
       // used.Add(index);


    }

    // Update is called once per frame
    void Update()
    {
        // var position = new Vector3(Random.Range(-16, 10), 0, Random.Range(-12, 9));
        // var radius = Random.Range(0, 2);


        if (bolflag == true)
        {
            for (int n = 0; n < 15; n++)
            {
                index = (int)Random.Range(0, 24);
                while (used.Contains(index) == true)
                {
                    print("same!!");
                    index = (int)Random.Range(0, 24);
                }
                used.Add(index);
                rockfirst = rock1;
                rocks[n] = Instantiate(rock1, locations[index], Quaternion.identity);
                print(index);
                //rockfirst.SetActive(false);
                count += 1;

            }
            bolflag = false;
        }




    }
}



