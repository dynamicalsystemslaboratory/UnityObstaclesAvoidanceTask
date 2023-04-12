using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tree_randompos : MonoBehaviour
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
        locations = new Vector3[31];
        benches = new GameObject[16];
        locations[0] = new Vector3(27.42f, -23.993f, 12.451f);

        locations[1] = new Vector3(42.6f,-24f,9.4f);
        locations[2] = new Vector3(35.6f,-24f,19.1f);
        locations[3] = new Vector3(33.5f, -24f, 45.3f);
       
        locations[4] = new Vector3(29f, -24f, 68.2f);
        locations[5] = new Vector3(46.9f, -24f, 60.5f);
        locations[6] = new Vector3(47f, -24f, 65.82f);
        locations[7] = new Vector3(16f, -24f, 12.1f);
        locations[8] = new Vector3(47.4f, -24f, 43.7f);
        locations[9] = new Vector3(21.5f, -24f, 111.1f);
        locations[10] = new Vector3(18.2f, -24f, 32.5f);
        locations[11] = new Vector3(32.4f, -24f, 104.6f);
        locations[12] = new Vector3(18.2f, -24f, 0.5f);
        locations[13] = new Vector3(49f, -24f, -35.8f);
        locations[14] = new Vector3(16.5f, -24f, -8.2f);
        locations[15] = new Vector3(44.6f, -24f, -26.7f);
        locations[16] = new Vector3(44.6f, -24f, 92.6f);
        locations[17] = new Vector3(42.9f, -24f, 128.1f);
        locations[18] = new Vector3(13.6f, -24f, 147.5f);
        locations[19] = new Vector3(39.4f, -24f, 169.4f);
        locations[20] = new Vector3(36.5f, -24f, 182f);
        locations[21] = new Vector3(20.2f, -24f, 180.3f);
        locations[22] = new Vector3(15f, -24f, 202.7f);
        locations[23] = new Vector3(42.4f, -24f, 225.8f);
        locations[24] = new Vector3(42.4f, -24f, 230.5f);
        locations[25] = new Vector3(37.6f, -24f, 325.9f);
        locations[26] = new Vector3(44.2f, -24f, 248.8f);
        locations[27] = new Vector3(44.2f, -24f, 273.4f);
        locations[28] = new Vector3(31.5f, -24f, 274.8f);
        locations[29] = new Vector3(31.5f, -24f, 308.4f);
        locations[30] = new Vector3(29.2f, -24f, 355.8f);



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
            for (int n = 0; n < 16; n++)
            {
                index = (int)Random.Range(0, 30);
                while (used.Contains(index) == true)
                {
                    print("same!!");
                    index = (int)Random.Range(0, 30);
                }
                used.Add(index);
                bench1 = bench;
                benches[n] = Instantiate(bench, locations[index],Quaternion.identity);
                
              
                print(index);
   
                count += 1;

            }
            bolflag = false;
        }




    }
}



