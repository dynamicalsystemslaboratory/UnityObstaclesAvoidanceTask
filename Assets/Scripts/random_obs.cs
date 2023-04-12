using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class random_obs : MonoBehaviour
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
        locations[0] = new Vector3(30.47f, -24f, -22.38f);
        locations[1] = new Vector3(30.47f, -24f, 0.8f);
        locations[2] = new Vector3(22.8f, -24f, 17.5f);
        locations[3] = new Vector3(22.7f, -24f, 31.11f);
        locations[4] = new Vector3(32.1f, -24f, 45.7f);
        locations[5] = new Vector3(40.19f, -24f, 52.7f);
        locations[6] = new Vector3(336.7f, -24f, 73f);
        locations[7] = new Vector3(40.6f, -24f, 85.6f);

        locations[8] = new Vector3(40.6f, -24.28f, 113f);
        locations[9] = new Vector3(33.3f, -24f, 140.1f);

        locations[10] = new Vector3(30.9f, -24f, 160.1f);

        locations[11] = new Vector3(34.02f, -24f, 191.06f);
        locations[12] = new Vector3(37.35f, -24f, 204.61f);

        locations[13] = new Vector3(32f, -24f, 228f);

        locations[14] = new Vector3(25.2f, -24f, 237.4f);

        locations[15] = new Vector3(25.2f, -24f, 252.1f);
        locations[16] = new Vector3(41f, -24f, 252.1f);

        locations[17] = new Vector3(42.23f, -24f, 269.57f);
        locations[18] = new Vector3(40.7f, -24f, 293.4f);
        locations[19] = new Vector3(39.7f, -24f, 314.7f);
        locations[20] = new Vector3(24.7f, -24f, 248.7f);
        locations[21] = new Vector3(24.7f, -24f, 323.8f);

        locations[22] = new Vector3(38.9f, -23.65f, 278.11f);
        locations[23] = new Vector3(26.9f, -24f, 358.3f);
        locations[24] = new Vector3(36.6f, -24f, 379.1f);
        locations[25] = new Vector3(36.6f, -24f, 361.7f);
        locations[26] = new Vector3(41.4f, -24f, 348.5f);
        locations[27] = new Vector3(41.4f, -24f, 387.7f);
        locations[28] = new Vector3(41.4f, -24f, 220.3f);
        locations[29] = new Vector3(16.6f, -24f, 173.7f);
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


        if (bolflag == true)
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
                rocks[n] = Instantiate(rock1, locations[index], Quaternion.identity);
                print(index);
                //rockfirst.SetActive(false);
                count += 1;

            }
            bolflag = false;
        }




    }
}



