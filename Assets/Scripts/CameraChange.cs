using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraChange : MonoBehaviour
{
    private GameObject camera0;
    private GameObject camera1;

    private GameObject test1;
    private GameObject test3;
    private bool back = false;
    // Start is called before the first frame update
    void Start()
    {


        camera1 = GameObject.Find("Camera1");
        camera0 = GameObject.Find("Camera");

    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKey(KeyCode.Y))
        {
            //camera0.transform.position = new Vector3(0, 2, -18);
            camera0.SetActive(true);
            camera1.SetActive(false);
        }

        if (Input.GetKey(KeyCode.T))
        {
           // camera0.transform.position = new Vector3(0, 2, -18);
            camera1.SetActive(true);
            camera0.SetActive(false);
        }

    }
}
