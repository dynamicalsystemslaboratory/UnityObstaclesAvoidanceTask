using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class group1_random : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject group4;
    public GameObject group2;
    public GameObject group3;
    public GameObject[] group4s = new GameObject[8];
    public GameObject[] group2s = new GameObject[15];
    public GameObject[] group3s = new GameObject[8];
    //public ArrayList positionlist;
    public Vector3[] positions2 = new Vector3[21];
    public Vector3[] positions3 = new Vector3[8];
    public Vector3[] positions4 = new Vector3[10];
    int index;
    int index2;
    int index3;
    bool bolflag = true;
    bool bolflag1 = true;
    bool bolflag2 = true;
    ArrayList used = new ArrayList();
    ArrayList used2 = new ArrayList();
    ArrayList used3 = new ArrayList();
    void Start()
    {

        positions3[0] = new Vector3(26.8f,-24.3f,283.51f);//rotatey 144
        positions3[1] = new Vector3(26.8f, -24.3f, 239.91f); //scale*0.33
        positions3[2] = new Vector3(18.74f, -24.3f, 211.01f);
        positions3[3] = new Vector3(22.54f, -24.2f, 165.6109f);
        positions3[4] = new Vector3(22.54f,-24.3f,119.91f);
        positions3[5] = new Vector3(22.54f, -24.3f, 76.21f);
        positions3[6] = new Vector3(27.74f, -24.3f, 28.71f);
        positions3[7] = new Vector3(20.449f, -24.3f, 329.21f);




        positions4[0] = new Vector3(19.9f, -24.2f, 22.2f);//rotatey163.34
        positions4[1] = new Vector3(19.9f, -24.2f, 66.8f);
        positions4[2] = new Vector3(19.9f, -24.2f, 277.2f);
        positions4[3] = new Vector3(19.9f, -24.2f, 320f);
        positions4[4] = new Vector3(19.9f, -24.2f, 363.4f);
        positions4[5] = new Vector3(43.45f,-24.2f,359.5f);//rotate -15.7
        positions4[6] = new Vector3(43.45f, -24.2f, 317f);
        positions4[7] = new Vector3(43.45f, -24.2f, 139.3f);
        positions4[8] = new Vector3(43.45f, -24.2f, 185f);
      




        positions2[0] = new Vector3(51.613f,-24.447f,-5.4814f);//scale *0.608 rotatey = -122.069
        positions2[1] = new Vector3(51.613f,-24.447f,28.5f);
        positions2[2] = new Vector3(51.613f, -24.447f, 91.7f);
        positions2[3] = new Vector3(51.613f, -24.447f, 113.7f);
        positions2[4] = new Vector3(51.613f, -24.447f, 222.3f);
        positions2[5] = new Vector3(51.613f, -24.447f, 189.7f);
        positions2[6] = new Vector3(51.613f, -24.447f, 166.4f);
        positions2[7] = new Vector3(51.4f, -24.447f, 137.4f);
        positions2[8] = new Vector3(51.4f, -24.447f, 113.4f);

        positions2[9] = new Vector3(10.2f, -24.447f, 89.87f);//-302.5
        positions2[10] = new Vector3(10.2f, -24.447f, 129.9f);//-302.5
        positions2[11] = new Vector3(9.6f, -24.447f, 112.9f);//-302.5
        positions2[12] = new Vector3(9.6f, -24.447f, 54.8f);//-302.5
        positions2[13] = new Vector3(9.6f, -24.447f, 15.8f);//-302.5
        positions2[14] = new Vector3(9.6f, -24.447f, -20.4f);//-302.5
        positions2[15] = new Vector3(9.6f, -24.447f, 244.8f);//-302.5
        positions2[16] = new Vector3(9.6f, -24.447f, 268.3f);//-302.5
        positions2[17] = new Vector3(9.6f, -24.447f, 290.9f);//-302.5
        positions2[18] = new Vector3(9.6f, -24.447f, 349.1f);//-302.5
        positions2[19] = new Vector3(9.6f, -24.447f, 373.1f);//-302.5
        positions2[20] = new Vector3(10.2f, -24.447f, 222f);//-302.5ef5e4





    }

    // Update is called once per frame
    void Update()
    {
        if (bolflag == true)
        {
            for (int n = 0; n < 15; n++)
            {
                index2 = (int)Random.Range(0, 21);
                while (used2.Contains(index2) == true)
                {
                    print("same!!");
                    index2 = (int)Random.Range(0, 21);
                }
                used2.Add(index2);
                group2s[n] = Instantiate(group2, positions2[index2], Quaternion.identity);
               

                if(index2 > 9)
                {
                    group2s[n].transform.Rotate(0, -122f, 0);
                }
                else
                {
                    group2s[n].transform.Rotate(0, -302.5f, 0);
                }

                print(index2);


            }
            bolflag = false;
        }

        if (bolflag == false && bolflag1 == true)
        {
            for (int n = 0; n < 8; n++)
            {
                index3 = (int)Random.Range(0, 8);
                while (used3.Contains(index3) == true)
                {
                    print("same!!");
                    index3 = (int)Random.Range(0, 8);
                }
                used3.Add(index3);
                group3s[n] = Instantiate(group3, positions3[index3], Quaternion.identity);
                // benches[n].transform.Rotate(0, 180f, 0);
 
                    group3s[n].transform.Rotate(0, 144f, 0);
                
   
                    group3s[n].transform.localScale = group3s[n].transform.localScale * 0.33f;
                
                print(index3);
                //rockfirst.SetActive(false);
                // count += 1;

            }
            bolflag1 = false;
        }

        if (bolflag1 == false && bolflag2 == true)
        {
            for (int n = 0; n < 8; n++)
            {
                index = (int)Random.Range(0, 9);
                while (used.Contains(index) == true)
                {
                    print("same!!");
                    index = (int)Random.Range(0, 9);
                }
                used.Add(index);

                group4s[n] = Instantiate(group4, positions4[index], Quaternion.identity);
                if (index < 5)
                {
                    group4s[n].transform.Rotate(0, 163.34f, 0);
                }
                else
                {
                    group4s[n].transform.Rotate(0, -15.7f, 0);
                    //group4s[n].transform.localScale = group4s[n].transform.localScale * 1.47f;
                }
                

              

            }
            bolflag2 = false;
        }

    }
}
