using System.Collections;

using System.Collections.Generic;

using UnityEngine;


//using Uduino;

public class ray1 : MonoBehaviour
{
    StateController _statecontroller;
   
    private void Start()
    {

        _statecontroller = new StateController();
        _statecontroller.eyes = this.transform;

       
    }

    private void Update()
    {
        Look(_statecontroller);
    }
    //
    //  LookDecision
    //
    public class StateController
    {
        public Transform eyes;
        public Transform chaseTarget;

    }
    public class defaultStats
    {
        public static float lookAngle = 120;
        public static float lookAccurate = 1;
        public static float lookRange = 10f;
    }
    //放射线检测
    private void Look(StateController controller)
    {

        float subAngle = (defaultStats.lookAngle / 2) / defaultStats.lookAccurate;


       


        LookAround(controller, Quaternion.identity, Color.green, transform.name + 0);
        for (int i = 0; i < defaultStats.lookAccurate; i++)
        {
            LookAround(controller, Quaternion.Euler(0, -1 * subAngle * (i + 1), 0), Color.green, transform.name + (i + 1));
            LookAround(controller, Quaternion.Euler(0, subAngle * (i + 1), 0), Color.green, transform.name + (i + 8));

        }

  

  

       





    }

    //check if there is player in ray
    static public bool LookAround(StateController controller, Quaternion eulerAnger, Color DebugColor, string RayNumber)
    {



        var dir = eulerAnger * controller.eyes.forward.normalized * defaultStats.lookRange;
        Debug.DrawRay(controller.eyes.position, dir, DebugColor);

        RaycastHit hit;
        if (Physics.Raycast(controller.eyes.position, eulerAnger * controller.eyes.forward, out hit, defaultStats.lookRange) && hit.collider.CompareTag("Player"))
        {
            controller.chaseTarget = hit.transform;
            // Debug.Log("Found:" + hit.transform.name + "  RayNumber:" + RayNumber+"distance:"+hit.distance);




            return true;
        }

        else
        {

            return false;

        }

    }

}
