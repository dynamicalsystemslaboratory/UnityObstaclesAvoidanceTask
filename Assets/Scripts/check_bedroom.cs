using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class check_bedroom : MonoBehaviour
{
	// Start is called before the first frame update
	float seconds, minutes, start;

	public GameObject basket;
	public bool checklist;
	bool flagbol = true;
	public int sockcount = 0;
	//int wrong = 0;
	public bool[] list = new bool[2];


	void Start()
	{
		start = PlayerPrefs.GetFloat("starttime_bed");
	}

	// Update is called once per frame
	void Update()
	{
		minutes = (int)((Time.time - start) / 60f);
		seconds = (int)((Time.time - start) % 60f);

	}


	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag != "floor" && other.gameObject.name != "OVRPlayerController")
		{
			print("OnCollisionEnter" + other.gameObject.name);
			other.gameObject.transform.SetParent(basket.transform);

			

			if (other.gameObject.tag == "socks")
			{
				sockcount += 1;

                if(sockcount == 8)
                {
					list[0] = true;
				}
			}
            else if (other.gameObject.tag == "towel")
            {
				list[1] = true;
            }




			for (int i = 0; i < 2; i++)
			{
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
				PlayerPrefs.SetInt("minutepast_bed", (int)minutes);
				PlayerPrefs.SetInt("secondspast_bed", (int)seconds);
				//PlayerPrefs.SetInt("Wrong", wrong);
				SceneManager.LoadScene("score_bed");
			}
		}

	}



	void OnTriggerExit(Collider other)
	{
		print("OnCollisionExit");
		flagbol = true;
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

}
