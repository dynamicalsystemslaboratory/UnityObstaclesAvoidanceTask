using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class distance2 : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject bunny;
    public GameObject sphere;
    public GameObject checkpoint;
    public GameObject checkpoint1;
    public GameObject checkpoint2;
    public GameObject arrow;
    public GameObject canvas;
    public GameObject canvas1;
    public GameObject center1;
    public GameObject center2;

    bool flag = true;
    float dist;
    float dist2;
    float dist3;
    float dist4;
    void Start()
    {
        // dist = Vector3.Distance(other.transform.position, player.transform.position);
        // canvas = GameObject.Find("backInstruction");
        print(canvas);
    }

    // Update is called once per frame
    void Update()
    {
        dist = Vector3.Distance(sphere.transform.position, transform.position);
        dist2 = Vector3.Distance(checkpoint.transform.position, transform.position);
        dist3 = Vector3.Distance(checkpoint1.transform.position, transform.position);
        dist4 = Vector3.Distance(checkpoint2.transform.position, transform.position);

        if (dist2 < 1.5f||dist3<1.5f||dist4<1.5f)
        {
            center1.SetActive(false);
            arrow.SetActive(true);
            center2.SetActive(true);
            //arrow1.SetActive(true);
            flag = false;
        }
        else { print(dist2); }

        if (dist < 2f)
        {
            bunny.SetActive(false);
            canvas1.SetActive(true);
            center1.SetActive(true);
            center2.SetActive(false);
        }
        else
        {

        }
    }
}
