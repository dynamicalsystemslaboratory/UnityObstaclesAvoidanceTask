using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collide : MonoBehaviour

{
	public static int collisioncount;
	bool cldbool = false;
	bool flag = false;
    // Start is called before the first frame update
  
	//当碰撞开始时

        public void start()
    {
		collisioncount = 0;

	}
	void OnCollisionEnter(Collision other)
	{
		if (other.gameObject.tag != "floor"&& other.gameObject.name != "OVRPlayerController")
		{
			print("OnCollisionEnter"+other.gameObject.name);

			StartCoroutine(Haptics(1, 1, 0.2f, true, false));

            if(cldbool == false)
            {
				collisioncount += 1;
				cldbool = true;
            }
		}

	}



	
	void OnCollisionExit(Collision other)
	{
		if (other.gameObject.tag != "floor" && other.gameObject.name != "OVRPlayerController")
		{
			print("OnCollisionExit" + other.gameObject.name);
			cldbool = false;
		}
		//flag = false;

	}
  //  private void Update()
  //  {
		//if (flag == true)
  //      {
		//	StartCoroutine(Haptics(1, 1, 0.3f, true, false));
		//	Invoke("Stop", 0.5f);
		//}
		
  //  }


  //  private void Stop()
  //  {
		//flag = false;
  //  }

    IEnumerator Haptics(float frequency, float amplitude, float duration, bool rightHand, bool leftHand)
	{
		if (rightHand) OVRInput.SetControllerVibration(frequency, amplitude, OVRInput.Controller.RTouch);
		if (leftHand) OVRInput.SetControllerVibration(frequency, amplitude, OVRInput.Controller.LTouch);

		yield return new WaitForSeconds(duration);

		if (rightHand) OVRInput.SetControllerVibration(0, 0, OVRInput.Controller.RTouch);
		if (leftHand) OVRInput.SetControllerVibration(0, 0, OVRInput.Controller.LTouch);

		print("vibrating");
		
	}




}
