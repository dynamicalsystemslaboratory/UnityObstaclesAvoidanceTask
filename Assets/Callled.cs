using UnityEngine;
using System.Collections;

public class Callled : MonoBehaviour
{

	// Use this for initialization
	void Start()
	{

	}

	// Update is called once per frame
	void Update()
	{

	}

	void OnMouseDown()
	{
		print("Clicked");
		SerialSend.ledaOn();
	}
}