using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class objectCheck_fruit : MonoBehaviour
{
	// Start is called before the first frame update
	float seconds, minutes, start;
	public GameObject lemon;
	public GameObject basket;
	public GameObject banana;
	public GameObject half_banana;
	public GameObject apple;
	public GameObject avocado;
	public GameObject orange;
	public GameObject lemon1;
	public GameObject banana1;
	public GameObject half_banana1;
	public GameObject apple1;
	public GameObject avocado1;
	public GameObject orange1;
	int lemoncount = 0;
	int orangecount = 0;
	int applecount = 0;
	int halfbanana_count = 0;
	int avocadocount = 0;
	int bananacount = 0;
	public bool checklist;
	bool flagbol = true;

	int wrong = 0;
	public bool[] list = new bool[6];


	void Start()
	{
		start = PlayerPrefs.GetFloat("starttime_fruit");
	}

	// Update is called once per frame
	void Update()
	{
		minutes = (int)((Time.time - start) / 60f);
		seconds = (int)((Time.time - start) % 60f);
		//print(wrong);
		
	}
	//print(seconds);




	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag != "floor" && other.gameObject.name != "OVRPlayerController")
		{
			other.gameObject.transform.SetParent(basket.transform);

			print("OnCollisionEnter" + other.gameObject.name);
			//other.transform.ToOVRPose(true);





			if (other.gameObject.tag == "lime")
			{

				//other.transform.ToOVRPose(true);
				lemoncount += 1;
				if (lemoncount == 2)
				{
					//other.gameObject.transform.SetParent(basket.transform);
					lemon.SetActive(true);
					lemon1.SetActive(true);
					list[0] = true;

				}
				else if (lemoncount > 2)
				{
					if (flagbol == true)
					{


						print("wrongitem" + wrong);
						print(flagbol);
						wrong += 1;
						flagbol = false;
					}
				}
			}

			else if (other.gameObject.tag == "half_orange")
			{

				orangecount += 1;
				if (orangecount == 2)
				{
					orange.SetActive(true);
					orange1.SetActive(true);
					list[1] = true;
				}
				//other.transform.ToOVRPose(true);

				else if (orangecount > 2)
				{
					if (flagbol == true)
					{


						print("wrongitem" + wrong);
						print(flagbol);
						wrong += 1;
						flagbol = false;
					}
				}
			}

			else if (other.gameObject.tag == "half_banana")
			{
				//other.gameObject.transform.SetParent(basket.transform);
				half_banana.SetActive(true);
				half_banana1.SetActive(true);
				halfbanana_count += 1;
				list[2] = true;

				if (halfbanana_count >= 2)
				{

					if (flagbol == true)
					{


						print("wrongitem" + wrong);
						print(flagbol);
						wrong += 1;
						flagbol = false;

					}
				}
			}

			else if (other.gameObject.tag == "avocado")
			{
				//other.gameObject.transform.SetParent(basket.transform);
				avocado.SetActive(true);
				avocado1.SetActive(true);
				avocadocount += 1;
				list[3] = true;
				if (avocadocount >= 2)
				{

					if (flagbol == true)
					{


						print("wrongitem" + wrong);
						print(flagbol);
						wrong += 1;
						flagbol = false;

					}
				}
			}

			else if (other.gameObject.tag == "apple")
			{

				applecount += 1;
				if (applecount == 2)
				{
					apple.SetActive(true);
					apple1.SetActive(true);
					list[4] = true;
				}
				else if (applecount > 2)
				{

					if (flagbol == true)
					{


						print("wrongitem" + wrong);
						print(flagbol);
						wrong += 1;
						flagbol = false;

					}
				}



			}
			else if (other.gameObject.tag == "banana")
			{


				banana.SetActive(true);
				banana1.SetActive(true);
				bananacount += 1;
				list[5] = true;
				if (bananacount >= 2)
				{

					if (flagbol == true)
					{


						print("wrongitem" + wrong);
						print(flagbol);
						wrong += 1;
						flagbol = false;

					}
				}

			}
			else
			{
				if (flagbol == true)
				{


					print("wrongitem" + wrong);
					print(flagbol);
					wrong += 1;
					flagbol = false;
				}
			}

			for (int i = 0; i < 6; i++)
			{
				print(list[i]);
				if (list[i] == false)
				{

					checklist = false;
					break;
				}
				else
				{
					checklist = true;
				}

			}

			if (checklist == true)
			{
				PlayerPrefs.SetInt("minutepast_fruit", (int)minutes);
				PlayerPrefs.SetInt("secondspast_fruit", (int)seconds);
				PlayerPrefs.SetInt("Wrong_fruit", wrong);
				SceneManager.LoadScene("Score_fruit");
			}






		}
	}



	void OnTriggerExit(Collider other)
	{
		print("OnCollisionExit");
		flagbol = true;

	}


}
