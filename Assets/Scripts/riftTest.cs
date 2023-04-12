using System.Collections;

using System.Collections.Generic;

using UnityEngine;


//using Uduino;

public class riftTest : MonoBehaviour
{
    StateController _statecontroller;
    static bool hitflag;
    static bool bolflag;
    static float timer;
    static ArrayList regionup1 = new ArrayList(6);
    static ArrayList regionup2 = new ArrayList(6);
    static ArrayList regionup3 = new ArrayList(6);
    static ArrayList regionup4 = new ArrayList(6);
    static ArrayList regionup5 = new ArrayList(6);
    private void Start()
    {
        //UduinoManager.Instance.pinMode(3, PinMode.PWM);
        //UduinoManager.Instance.pinMode(4, PinMode.PWM);
        //UduinoManager.Instance.pinMode(5, PinMode.PWM);
        //UduinoManager.Instance.pinMode(6, PinMode.PWM);
        //UduinoManager.Instance.pinMode(7, PinMode.PWM);
        _statecontroller = new StateController();
        _statecontroller.eyes = this.transform;

       
    }

    private void Update()
    {
        Look(_statecontroller);
        print(hitflag);
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
        public static float lookAngle = 120;//角度
        public static float lookAccurate = 7;//精度
        public static float lookRange = 1.5f;//长度
    }
    //放射线检测
    private void Look(StateController controller)
    {

        //一条向前的射线
        //print(hitflag);



        //多一个精确度就多两条对称的射线,每条射线夹角是总角度除与精度
        float subAngle = (defaultStats.lookAngle / 2) / defaultStats.lookAccurate;


        if (bolflag == true)
        {
            hitflag = false;

            bolflag = false;
        }


        LookAround(controller, Quaternion.identity, Color.green, transform.name + 0);
        for (int i = 0; i < defaultStats.lookAccurate; i++)
        {
            LookAround(controller, Quaternion.Euler(0, -1 * subAngle * (i + 1), 0), Color.green, transform.name + (i + 1));
            LookAround(controller, Quaternion.Euler(0, subAngle * (i + 1), 0), Color.green, transform.name + (i + 8));

        }

        if (Time.time - timer > 0.5f)
        {
           

            if(hitflag == true)
            {
                SerialSend.riftTest();
            }
            else {
                SerialSend.riftTestoff();
            }
        }

        bolflag = true;





    }

    //射出射线检测是否有Player
    static public bool LookAround(StateController controller, Quaternion eulerAnger, Color DebugColor, string RayNumber)
    {



        var dir = eulerAnger * controller.eyes.forward.normalized * defaultStats.lookRange;
        Debug.DrawRay(controller.eyes.position, dir, DebugColor);

        RaycastHit hit;
        if (Physics.Raycast(controller.eyes.position, eulerAnger * controller.eyes.forward, out hit, defaultStats.lookRange) && hit.collider.CompareTag("Player"))
        {
            controller.chaseTarget = hit.transform;
            Debug.Log("Found:" + hit.transform.name + "  RayNumber:" + RayNumber + "distance:" + hit.distance);
            hitflag  = true;

            return true;

        }
        else
        {
            
            return false;

        }

    }

}
