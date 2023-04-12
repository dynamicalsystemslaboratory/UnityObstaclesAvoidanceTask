using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;
using Oculus.Avatar;
using UnityEngine.UI;
public class move : MonoBehaviour
{

    GameObject box1;
   // GameObject camera1;
    // Use this for initialization
    bool flag = true;
    
    void Start()
    {
        box1 = GameObject.Find("Cube");
       // camera1 = GameObject.Find("OVRCameraRig");
    }
    // Update is called once per frame
    void Update()
    {
        

       // print(Vector3.Distance(box1.transform.position, transform.position));

        if (Vector3.Distance(box1.transform.position, transform.position) < 1.8f&&flag == true)
        {
            print("collide@");
            
            flag = false;
            box1.GetComponent<MeshRenderer>().material.color = new Color(0.7647f, 0.574f, 0.9578f) ;
    
            OVRInput.SetControllerVibration(1, 1, OVRInput.Controller.RTouch);
            vibrationManager.singleton.TriggerVibration(40, 2, 2);

        }
        else if(Vector3.Distance(box1.transform.position, transform.position) >= 1.8f && flag == false)
        {
            flag = true;
            box1.GetComponent<MeshRenderer>().material.color = new Color(0.7647f,0,0.9578f);
            vibrationManager.singleton.TriggerVibration(40, 2, 2);
        }

    }
}
