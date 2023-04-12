//using System.Collections;
//using System.Collections.Generic;
//using System.Diagnostics;
//using System.Threading;
//using System;
//using System.Windows;
//using UnityEngine;
//using Debug = UnityEngine.Debug;

//public class PlayerRaycast2 : MonoBehaviour
//{
//    public float distanceToSee;

//    float[] min = { 0F, 0F, 0F, 0F, 0F, 0F, 0F, 0F, 0F, 0F };
//    float[] identityVect = { 1F, 1F, 1F, 1F, 1F, 1F, 1F, 1F};
//    int[] actualVect = { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
//    int[] desiredVect = { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
//    int[] deltaVect = { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
//    int[] arrayIndex = { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };

//    float[] differenceVect = { 0F, 0F, 0F, 0F, 0F, 0F, 0F, 0F};
//    float[] frequencyVect = {0F, 0F, 0F, 0F, 0F, 0F, 0F, 0F};
//    float[] numberVect = { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };


//    //float[] differenceVect2 = { 0F, 0F, 0F, 0F, 0F, 0F, 0F, 0F};
//    //float[] differenceVect3 = { 0F, 0F, 0F, 0F, 0F, 0F, 0F, 0F};
//    //float[] differenceVect4 = { 0F, 0F, 0F, 0F, 0F, 0F, 0F, 0F};
//    //float[] differenceVect5 = { 0F, 0F, 0F, 0F, 0F, 0F, 0F, 0F};
//    //float[] differenceVect6 = { 0F, 0F, 0F, 0F, 0F, 0F, 0F, 0F};
//    //float[] differenceVect7 = { 0F, 0F, 0F, 0F, 0F, 0F, 0F, 0F};
//    //float[] differenceVect8 = { 0F, 0F, 0F, 0F, 0F, 0F, 0F, 0F};
//    //float[] differenceVect9 = { 0F, 0F, 0F, 0F, 0F, 0F, 0F, 0F};
//    //float[] differenceVect10 = { 0F, 0F, 0F, 0F, 0F, 0F, 0F, 0F};

//    float[] distanceVect = { 1.25F, 2.5F, 3.75F, 5F, 6.25F, 7.5F, 8.75F, 10F };

//    RaycastHit whatIHit;
//    RaycastHit whatIHit2;
//    RaycastHit whatIHit3;
//    RaycastHit whatIHit4;
//    RaycastHit whatIHit5;
//    RaycastHit whatIHit6;
//    RaycastHit whatIHit7;
//    RaycastHit whatIHit8;
//    RaycastHit whatIHit9;
//    RaycastHit whatIHit10;

//    float[] timerSpeed = { 0.5f, 0.5f, 0.2f, 0.2f, 0.2f, 0.2f, 0.2f, 0.2f, 0.2f, 0.2f };

//    private float lastTimestamp = Time.time;
//    private float lastTimestamp2 = Time.time;
//    private float lastTimestamp3 = Time.time;
//    private float lastTimestamp4 = Time.time;
//    private float lastTimestamp5 = Time.time;
//    private float lastTimestamp6 = Time.time;
//    private float lastTimestamp7 = Time.time;
//    private float lastTimestamp8 = Time.time;
//    private float lastTimestamp9 = Time.time;
//    private float lastTimestamp10 = Time.time;


//    void Start()
//    {

//    }

//    void Update()
//    {
//        LayerMask mask = ~LayerMask.GetMask("Ignore Raycast");

//        //var firstDirection = (transform.forward - transform.right * 3 / 5).normalized;

//        //var secondDirection = (transform.forward + transform.up * 1 / 3 - transform.right * 2 / 5).normalized;

//        var firstDirection = (transform.forward + transform.up * 1 / 3).normalized;

//        var secondDirection = (transform.forward - transform.up * 1 / 3).normalized;

//        var thirdDirection = (transform.forward - transform.up * 1 / 3 - transform.right * 2 / 5).normalized;

//        var fourthDirection = (transform.forward + transform.up * 1 / 3 - transform.right * 1 / 5).normalized;

//        var fifthDirection = (transform.forward - transform.up * 1 / 3 - transform.right * 1 / 5).normalized;

//        var sixthDirection = (transform.forward + transform.up * 1 / 3 + transform.right * 1 / 5).normalized;

//        var seventhDirection = (transform.forward - transform.up * 1 / 3 + transform.right * 1 / 5).normalized;

//        var eighthDirection = (transform.forward + transform.up * 1 / 3 + transform.right * 2 / 5).normalized;

//        var ninthDirection = (transform.forward - transform.up * 1 / 3 + transform.right * 2 / 5).normalized;

//        var tenthDirection = (transform.forward + transform.right * 3 / 5).normalized;



//        bool stateA = Physics.Raycast(this.transform.position, firstDirection, out whatIHit, distanceToSee, mask);

//        bool stateB = Physics.Raycast(this.transform.position, secondDirection, out whatIHit2, distanceToSee, mask);

//        bool stateC = Physics.Raycast(this.transform.position, thirdDirection, out whatIHit3, distanceToSee, mask);

//        bool stateD = Physics.Raycast(this.transform.position, fourthDirection, out whatIHit, distanceToSee, mask);

//        bool stateE = Physics.Raycast(this.transform.position, fifthDirection, out whatIHit2, distanceToSee, mask);

//        bool stateF = Physics.Raycast(this.transform.position, sixthDirection, out whatIHit3, distanceToSee, mask);

//        bool stateG = Physics.Raycast(this.transform.position, seventhDirection, out whatIHit, distanceToSee, mask);

//        bool stateH = Physics.Raycast(this.transform.position, eighthDirection, out whatIHit2, distanceToSee, mask);

//        bool stateI = Physics.Raycast(this.transform.position, ninthDirection, out whatIHit3, distanceToSee, mask);

//        bool stateJ = Physics.Raycast(this.transform.position, tenthDirection, out whatIHit3, distanceToSee, mask);


//        bool[] state = {stateA, stateB, stateC, stateD, stateE, stateF, stateG, stateH, stateI, stateJ};

//        for (int i = 0; i <= min.Length - 1; i++)
//        {
//            min[i] = Mathf.Infinity;
//        }

//        if (state[0] || state[1])
//        {
            
//            for (int i = 0; i <= distanceVect.Length - 1; i++)
//            {
//                differenceVect[i] = Mathf.Abs(whatIHit.distance * identityVect[i] - distanceVect[i]);

//                if (differenceVect[i] < min[0])
//                {
//                    min[0] = differenceVect[i];
//                }

//                differenceVect2[i] = Mathf.Abs(whatIHit2.distance * identityVect[i] - distanceVect[i]);

//                if (differenceVect2[i] < min[1])
//                {
//                    min[1] = differenceVect2[i];
//                }

//                differenceVect3[i] = Mathf.Abs(whatIHit3.distance * identityVect[i] - distanceVect[i]);

//                if (differenceVect3[i] < min[2])
//                {
//                    min[2] = differenceVect3[i];
//                }

//                differenceVect4[i] = Mathf.Abs(whatIHit4.distance * identityVect[i] - distanceVect[i]);

//                if (differenceVect4[i] < min[3])
//                {
//                    min[3] = differenceVect4[i];
//                }

//                differenceVect5[i] = Mathf.Abs(whatIHit5.distance * identityVect[i] - distanceVect[i]);

//                if (differenceVect5[i] < min[4])
//                {
//                    min[4] = differenceVect5[i];
//                }

//                differenceVect6[i] = Mathf.Abs(whatIHit6.distance * identityVect[i] - distanceVect[i]);

//                if (differenceVect6[i] < min[5])
//                {
//                    min[5] = differenceVect6[i];
//                }

//                differenceVect7[i] = Mathf.Abs(whatIHit7.distance * identityVect[i] - distanceVect[i]);

//                if (differenceVect7[i] < min[6])
//                {
//                    min[6] = differenceVect7[i];
//                }

//                differenceVect8[i] = Mathf.Abs(whatIHit8.distance * identityVect[i] - distanceVect[i]);

//                if (differenceVect8[i] < min[7])
//                {
//                    min[7] = differenceVect8[i];
//                }

//                differenceVect9[i] = Mathf.Abs(whatIHit9.distance * identityVect[i] - distanceVect[i]);

//                if (differenceVect9[i] < min[8])
//                {
//                    min[8] = differenceVect9[i];
//                }

//                differenceVect10[i] = Mathf.Abs(whatIHit10.distance * identityVect[i] - distanceVect[i]);

//                if (differenceVect10[i] < min[9])
//                {
//                    min[9] = differenceVect10[i];
//                }
//            }


//            for(int i = 0; i <= state.Length-1; i++)
//            {
//                if(state[i] == true)
//                {
//                    desiredVect[i] = 1;
//                }
//                else if(state[i] != true)
//                {
//                    desiredVect[i] = 0;
//                }
//            }


//            if (state[0] == true)
//            {
//                arrayIndex[0] = Array.IndexOf(differenceVect, min[0]);
//            }


//            if (desiredVect[0] - actualVect[0] == 1)
//            {
//                if (Time.time - lastTimestamp >= timerSpeed[0])
//                {
//                    if (arrayIndex[0] == 7)
//                    {
//                        ActuatorSPI.SendFirst();
//                        actualVect[0] = 1;
//                        lastTimestamp = Time.time;
//                    }
//                    else if (arrayIndex[0] == 6)
//                    {
//                        ActuatorSPI.SendFirst_2();
//                        actualVect[0] = 1;
//                        lastTimestamp = Time.time;
//                    }
//                    else if (arrayIndex[0] == 5)
//                    {
//                        ActuatorSPI.SendFirst_3();
//                        actualVect[0] = 1;
//                        lastTimestamp = Time.time;
//                    }
//                    else if (arrayIndex[0] == 4)
//                    {
//                        ActuatorSPI.SendFirst_4();
//                        actualVect[0] = 1;
//                        lastTimestamp = Time.time;
//                    }
//                    else if (arrayIndex[0] == 3)
//                    {
//                        ActuatorSPI.SendFirst_5();
//                        actualVect[0] = 1;
//                        lastTimestamp = Time.time;
//                    }
//                    else if (arrayIndex[0] == 2)
//                    {
//                        ActuatorSPI.SendFirst_6();
//                        actualVect[0] = 1;
//                        lastTimestamp = Time.time;
//                    }
//                    else if (arrayIndex[0] == 1)
//                    {
//                        ActuatorSPI.SendFirst_7();
//                        actualVect[0] = 1;
//                        lastTimestamp = Time.time;
//                    }
//                    else if (arrayIndex[0] == 0)
//                    {
//                        ActuatorSPI.SendFirst_8();
//                        actualVect[0] = 1;
//                        lastTimestamp = Time.time;
//                    }
//                }
//            }

//            else if (desiredVect[0] - actualVect[0] == -1)
//            {
//                ActuatorSPI.SendNo();
//                actualVect[0] = 0;
//                // Need to turn off actuator
//            }


//            if (state[1] == true)
//            {
//                arrayIndex[1] = Array.IndexOf(differenceVect2, min[1]);
//            }

//            if (desiredVect[1] - actualVect[1] == 1)
//            {
//                if (Time.time - lastTimestamp2 >= timerSpeed[1])
//                {
//                    if (arrayIndex[1] == 7)
//                    {
//                        ActuatorSPI.SendSecond();
//                        actualVect[1] = 1;
//                        lastTimestamp2 = Time.time;
//                    }
//                    else if (arrayIndex[1] == 6)
//                    {
//                        ActuatorSPI.SendSecond_2();
//                        actualVect[1] = 1;
//                        lastTimestamp2 = Time.time;
//                    }
//                    else if (arrayIndex[1] == 5)
//                    {
//                        ActuatorSPI.SendSecond_3();
//                        actualVect[1] = 1;
//                        lastTimestamp2 = Time.time;
//                    }
//                    else if (arrayIndex[1] == 4)
//                    {
//                        ActuatorSPI.SendSecond_4();
//                        actualVect[1] = 1;
//                        lastTimestamp2 = Time.time;
//                    }
//                    else if (arrayIndex[1] == 3)
//                    {
//                        ActuatorSPI.SendSecond_5();
//                        actualVect[1] = 1;
//                        lastTimestamp2 = Time.time;
//                    }
//                    else if (arrayIndex[1] == 2)
//                    {
//                        ActuatorSPI.SendSecond_6();
//                        actualVect[1] = 1;
//                        lastTimestamp2 = Time.time;
//                    }
//                    else if (arrayIndex[1] == 1)
//                    {
//                        ActuatorSPI.SendSecond_7();
//                        actualVect[1] = 1;
//                        lastTimestamp2 = Time.time;
//                    }
//                    else if (arrayIndex[1] == 0)
//                    {
//                        ActuatorSPI.SendSecond_8();
//                        actualVect[1] = 1;
//                        lastTimestamp2 = Time.time;
//                    }
//                }
//            }

//            else if (desiredVect[1] - actualVect[1] == -1)
//            {
//                ActuatorSPI.SendNo();
//                actualVect[1] = 0;
//                // Need to turn off actuator
//            }
//        }

//        else if (!state[0] && !state[1] && !state[2] && !state[3] && !state[4] && !state[5] && !state[6] && !state[7] && !state[8] && !state[9])
//        {
//            UnityEngine.Debug.Log("Not touching anything");
//            ActuatorSPI.SendNo();
//            for(int i = 0; i <= actualVect.Length-1; i++)
//            {
//                actualVect[i] = 0;
//            }
//        }

//        for (int i = 0; i <= actualVect.Length - 1; i++)
//        {
//            if (actualVect[i] == 1)
//            {
//                if (i == 0 && i != 1)
//                {
//                    if (Time.time - lastTimestamp >= timerSpeed[0])
//                    {
//                        ActuatorSPI.SendNo();
//                        actualVect[0] = 0;
//                        lastTimestamp = Time.time;
//                    }
//                }
//                else if (i == 1 && i != 0)
//                {
//                    if (Time.time - lastTimestamp2 >= timerSpeed[1])
//                    {
//                        ActuatorSPI.SendNo();
//                        actualVect[1] = 0;
//                        lastTimestamp2 = Time.time;
//                    }
//                }

//                else if (i == 0 && i == 1)
//                {
//                    if (Time.time - lastTimestamp >= timerSpeed[0])
//                    {
//                        ActuatorSPI.SendNo();
//                        actualVect[0] = 0;
//                        actualVect[1] = 0;
//                        lastTimestamp = Time.time;
//                    }
//                }
//            }
//        }
//    }


//}

