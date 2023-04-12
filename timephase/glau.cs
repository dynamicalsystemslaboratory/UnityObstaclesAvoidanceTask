using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class glau : MonoBehaviour
{
	int collide = 0;
	bool flag = false;
	bool flag2 = false;
	bool flag3 = false;
	// Start is called before the first frame update

	//public Text collision;
	public GameObject image;
	public GameObject player;
	public GameObject trigger;
	public GameObject camera1;
	public GameObject camera2;
	public float seconds, minutes, start;
	Color color;
	Color textcolor;
	float alpha;

	bool GameOver;
	float dist;
	public GameObject bunny;
	GameObject bunny1;
	int count = 1;
	int index;
	bool bolflag = true;
	ArrayList used = new ArrayList();

	Vector3[] locations;

	void Start()
	{

		//collision.GetComponent<Text>().color.a=0;

		alpha = 0;

		locations = new Vector3[20];
		locations[0] = new Vector3(-15.8f, -0.16f, -12.5f);
		locations[1] = new Vector3(-18.15f, -0.16f, -11.53f);
		locations[2] = new Vector3(-16.54f, -0.16f, -6.79f);
		locations[3] = new Vector3(-11.4f, 0.58f, -8.29f);
		locations[4] = new Vector3(-9.03f, -0.16f, -6.4f);
		locations[5] = new Vector3(-12.03f, -0.16f, -10.37f);
		locations[6] = new Vector3(-8.6f, -0.16f, -9.39f);

		locations[7] = new Vector3(-7.87f, -0.16f, -10.68f);

		locations[8] = new Vector3(-6.07f, -0.16f, -6.74f);
		locations[9] = new Vector3(-2.69f, -0.16f, -3.87f);

		locations[10] = new Vector3(0.33f, -0.16f, -3.93f);

		locations[11] = new Vector3(0.13f, -0.16f, -0.62f);
		locations[12] = new Vector3(-0.88f, 0.513f, -1.88f);

		locations[13] = new Vector3(-3.55f, -0.16f, -2.32f);

		locations[14] = new Vector3(-14.7f, -0.16f, -7.63f);

		locations[15] = new Vector3(-11.45f, -0.16f, -9.38f);
		locations[16] = new Vector3(-21.28f, -0.16f, -11.65f);

		locations[17] = new Vector3(-16.16f, -0.16f, -13.27f);
		locations[18] = new Vector3(-25.06f, -0.16f, -17.57f);
		locations[19] = new Vector3(-12.05f, -0.16f, -13.96f);
		print("location" + locations[0]);

		bunny.transform.position = locations[0];
		index = (int)Random.Range(0, 17);
		print(index);
		used.Add(index);
		bunny = Instantiate(bunny, locations[index], Quaternion.LookRotation(transform.position));

	}

	// Update is called once per frame
	void Update()
	{



		color = new Color(255, 255, 255, alpha);
		textcolor = new Color(0, 0, 0, alpha);
		//image.GetComponent<Image>().color= color;
		//collision.GetComponent<Text>().color = textcolor;

		if (OVRInput.Get(OVRInput.Button.Two) || Input.GetKeyDown(KeyCode.B) && flag == false)
		{
			flag = true;
			start = Time.time;
			flag3 = true;
			print("flag3true");
			image.SetActive(false);
			trigger.SetActive(true);
			camera1.SetActive(false);
			camera2.SetActive(true);


		}

		if (flag == true && flag2 != true)
		{

			minutes = (int)((Time.time - start) / 60f);
			seconds = (int)((Time.time - start) % 60f);
			//counterText.text = minutes.ToString("00") + "Minutes" + seconds.ToString("00") + "Seconds";
		}


		dist = Vector3.Distance(bunny.transform.position, player.transform.position);
		if (dist < 2.1 && count <= 9)
		{
			index = (int)Random.Range(0, 17);

			while (used.Contains(index) == true)
			{
				index = (int)Random.Range(0, 17);
				print("same!!");
			}



			used.Add(index);
			bunny1 = bunny;
			bunny = Instantiate(bunny, locations[index], Quaternion.LookRotation(player.transform.position));
			print(index);
			bunny1.SetActive(false);
			count += 1;
			print(count);
		}
		else if (count == 10)
		{
			PlayerPrefs.SetInt("minuteglau", (int)minutes);
			PlayerPrefs.SetInt("secondsglau", (int)seconds);
			PlayerPrefs.SetInt("collisionglau", collide);
			SceneManager.LoadScene("scoreboard_glau");
		}

	}



	// Start is called before the first frame update

	//当碰撞开始时
	void OnCollisionEnter(Collision other)
	{
		if (other.gameObject.tag != "floor" && other.gameObject.name != "OVRPlayerController" && flag3 == true)
		{
			print("OnCollisionEnter" + other.gameObject.name);
			//StartCoroutine(changeAlpha());
			flag2 = true;

			StartCoroutine(Haptics(1, 1, 0.2f, true, false));

		}

	}




	void OnCollisionExit(Collision other)
	{
		print("OnCollisionExit");
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
		//alpha += 0.6f;

		yield return new WaitForSeconds(duration);

		if (rightHand) OVRInput.SetControllerVibration(0, 0, OVRInput.Controller.RTouch);
		if (leftHand) OVRInput.SetControllerVibration(0, 0, OVRInput.Controller.LTouch);

		//alpha -= 0.6f;

		if (flag2 == true)
		{
			collide += 1;
			//collision.text = "Collision:" + collide.ToString();
			flag2 = false;

		}


	}

	IEnumerator changeAlpha()
	{


		alpha += 0.4f;
		print("alpha:" + alpha);
		yield return new WaitForSeconds(1f);
		alpha -= 0.4f;
	}


}
