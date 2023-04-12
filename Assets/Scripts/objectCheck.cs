using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class objectCheck : MonoBehaviour
{
	// Start is called before the first frame update
	float seconds, minutes, start;
	public GameObject milkcross;
	public GameObject cerealcross;
	public GameObject cokecross;
	public GameObject cookiecross;
	public GameObject mayocross;
	public GameObject sandcross;
	public GameObject milk2cross;
	public GameObject cereal2cross;
	public GameObject coke2cross;
	public GameObject cookie2cross;
	public GameObject mayo2cross;
	public GameObject sand2cross;
	public GameObject basket;
	public bool checklist;
	bool flagbol = true;
	public int milkcount = 0;
	public int sandwichcount = 0;
	int cokecount = 0;
	int cerealcount = 0;
	int mayocount = 0;
	int cookiecount = 0;
	int wrong = 0;
	public bool[] list = new bool[6];
	

	void Start()
    {
		start = PlayerPrefs.GetFloat("starttime_store");
		print("start" + start);
	}

    // Update is called once per frame
    void Update()
    {
		minutes = (int)((Time.time - start) / 60f);
		seconds = (int)((Time.time - start) % 60f);
		//print("Seconds"+seconds);
		//print("m" + minutes);
		//print("wrongitem" + wrong);
	}


    void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag != "floor" && other.gameObject.name != "OVRPlayerController")
		{
			other.gameObject.transform.SetParent(basket.transform);

			print("OnCollisionEnter" + other.gameObject.name);
			//other.transform.ToOVRPose(true);
			
			//other.transform.position = basket.transform.position;
			if (other.gameObject.tag == "milk")
			{
				other.gameObject.transform.SetParent(basket.transform);
				milkcount += 1;
				//other.transform.Translate = this.transform.Translate;
				if (milkcount == 2)
				{
					//other.gameObject.transform.SetParent(basket.transform);
					milkcross.SetActive(true);
					milk2cross.SetActive(true);
					list[0] = true;

				}
                else if(milkcount > 2)
                {
					if (flagbol == true)
					{


						print("wrongitem" + wrong);
						print(flagbol);
						wrong = wrong + 1;
						flagbol = false;
					}
				}
			}


			else if (other.gameObject.tag == "cereal")
			{
				other.gameObject.transform.SetParent(basket.transform);
				cerealcross.SetActive(true);
				cereal2cross.SetActive(true);
				cerealcount += 1;
				list[1] = true;
                if(cerealcount >= 2)
                {
					if (flagbol == true)
					{


						print("wrongitem" + wrong);
						print(flagbol);
						wrong = wrong + 1;
						flagbol = false;
					}
				}
				
				//other.transform.ToOVRPose(true);
			}

			else if (other.gameObject.tag == "coke")
			{
				other.gameObject.transform.SetParent(basket.transform);
				cokecross.SetActive(true);
				coke2cross.SetActive(true);
				cokecount += 1;
				list[2] = true;

				if (cokecount >= 2)
				{
					if (flagbol == true)
					{


						print("wrongitem" + wrong);
						print(flagbol);
						wrong = wrong + 1;
						flagbol = false;
					}
				}
				//other.transform.ToOVRPose(true);
			}

			else if (other.gameObject.tag == "cookie")
			{
				other.gameObject.transform.SetParent(basket.transform);
				cookiecross.SetActive(true);
				cookie2cross.SetActive(true);
				cookiecount += 1;
				list[3] = true;

				if (cokecount >= 2)
				{
					if (flagbol == true)
					{


						print("wrongitem" + wrong);
						print(flagbol);
						wrong = wrong + 1;
						flagbol = false;
					}
				}
			}

			else if (other.gameObject.tag == "mayo")
			{
				other.gameObject.transform.SetParent(basket.transform);
				mayocross.SetActive(true);
				mayo2cross.SetActive(true);
				mayocount += 1;
				list[4] = true;
				if (mayocount >= 2)
				{
					if (flagbol == true)
					{


						print("wrongitem" + wrong);
						print(flagbol);
						wrong = wrong + 1;
						flagbol = false;
					}
				}
			}

			else if (other.gameObject.tag == "sandwich")
			{
				other.gameObject.transform.SetParent(basket.transform);
				sandwichcount += 1;
				if (sandwichcount == 2)
				{

					sandcross.SetActive(true);
					sand2cross.SetActive(true);
					list[5] = true;

				}
				else if (sandwichcount > 2)
				{
					if (flagbol == true)
					{


						print("wrongitem" + wrong);
						print(flagbol);
						wrong = wrong + 1;
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
					wrong = wrong + 1;
					flagbol = false;
				}
            }

			


			for (int i = 0; i < 6; i++)
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
            if(checklist == true)
            {
				PlayerPrefs.SetInt("minutepast", (int)minutes);
				PlayerPrefs.SetInt("secondspast", (int)seconds);
				PlayerPrefs.SetInt("Wrong", wrong);
				SceneManager.LoadScene("score");
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
