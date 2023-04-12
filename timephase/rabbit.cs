using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rabbit : MonoBehaviour
{
    float dist;
    public GameObject bunny;
    GameObject bunny1;
    int count=1;
    int index;
    bool bolflag = true;
    ArrayList used = new ArrayList();
    
    Vector3[] locations;
    // Start is called before the first frame update

    void Start()
    {
        locations = new Vector3[20];
        locations[0] = new Vector3(-15.8f,-0.16f,-12.5f);
        locations[1] = new Vector3(-18.15f, -0.16f, -11.53f);
        locations[2] = new Vector3(-16.54f, -0.16f, -6.79f);
        locations[3] = new Vector3(-11.4f, 0.57f, -8.29f);
        locations[4] = new Vector3(-9.03f, -0.16f, -6.4f);
        locations[5] = new Vector3(-12.03f, -0.16f, -10.37f);
        locations[6] = new Vector3(-8.6f, -0.16f, -9.39f);

        locations[7] = new Vector3(-7.87f, -0.16f, -10.68f);

        locations[8] = new Vector3(-6.07f, -0.16f, -6.74f);
        locations[9] = new Vector3(-2.69f, -0.16f, -3.87f);

        locations[10]= new Vector3(0.33f, -0.16f, -3.93f);

        locations[11] = new Vector3(0.13f, -0.16f, -0.62f);
        locations[12] = new Vector3(-0.88f, 0.513f, -1.88f);

        locations[13] = new Vector3(-3.55f, -0.16f, -2.32f);

        locations[14] = new Vector3(-14.7f, -0.16f, -7.63f);
       
        locations[15] = new Vector3(-11.45f, -0.16f, -9.38f);
        locations[16] = new Vector3(-21.28f, -0.16f, -11.65f);

        locations[17] = new Vector3(-16.16f, -0.16f, -13.27f);
        locations[18] = new Vector3(-25.06f, -0.16f, -17.57f);
        locations[19] = new Vector3(-12.05f, -0.16f, -13.96f);
        print("location"+locations[0]);

        bunny.transform.position = locations[0];
        index = (int)Random.Range(0,17);
        print(index);
        used.Add(index);
        bunny = Instantiate(bunny, locations[index], Quaternion.LookRotation(transform.position));
    }

    // Update is called once per frame
    void Update()
    {
       // var position = new Vector3(Random.Range(-16, 10), 0, Random.Range(-12, 9));
       // var radius = Random.Range(0, 2);
        
        dist = Vector3.Distance(bunny.transform.position, transform.position);
        if (dist < 1.1 && count <= 9)
        {
            index = (int)Random.Range(0, 17);

            while (used.Contains(index) == true)
            {
                index = (int)Random.Range(0, 17);
                print("same!!");
            }


            
            used.Add(index);
            bunny1 = bunny;
            bunny = Instantiate(bunny, locations[index], Quaternion.LookRotation(transform.position));
            print(index);
            bunny1.SetActive(false);
            count += 1;
        }
           

            //Vector2 newPosition = Random.insideUnitCircle * 0.1f;
            //var x = bunny.transform.position.x;
            //var y = bunny.transform.position.y;
            //x = newPosition.x+x;
            //y = newPosition.y+y;
            //bunny.transform.position = new Vector3(x, 0, y); 
        }

    }

