using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bench_pos : MonoBehaviour
{
    float dist;
    public GameObject bench;
    public GameObject[] benches;
    GameObject bench1;
    int count = 1;
    int index;
    bool bolflag = true;
    ArrayList used = new ArrayList();

    Vector3[] locations;
    // Start is called before the first frame update

    void Start()
    {
        locations = new Vector3[6];
        benches = new GameObject[3];
        locations[0] = new Vector3(65f, -24.9f, -51.32f);

        locations[1] = new Vector3(66.2f, -24.9f, -31.5f);
        locations[2] = new Vector3(99.7f, -24.9f, 10.5f);
        locations[3] = new Vector3(99.7f, -24.9f, 23.5f);

        locations[4] = new Vector3(99.7f, -24.9f, 97.3f);
        locations[5] = new Vector3(99.7f, -24.9f, 115.8f);



        print("location" + locations[0]);

        // rock1.transform.position = locations[0];
        index = (int)Random.Range(0, 6);
        print(index);
        used.Add(index);


    }

    // Update is called once per frame
    void Update()
    {
        // var position = new Vector3(Random.Range(-16, 10), 0, Random.Range(-12, 9));
        // var radius = Random.Range(0, 2);


        if (bolflag == true)
        {
            for (int n = 0; n < 3; n++)
            {
                index = (int)Random.Range(0, 5);
                while (used.Contains(index) == true)
                {
                    print("same!!");
                    index = (int)Random.Range(0, 5);
                }
                used.Add(index);
                bench1 = bench;
                benches[n] = Instantiate(bench, locations[index], Quaternion.identity);
               // benches[n].transform.Rotate(0, 180f, 0);

                print(index);
                //rockfirst.SetActive(false);
                count += 1;

            }
            bolflag = false;
        }




    }
}



