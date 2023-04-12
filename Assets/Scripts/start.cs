using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class start : MonoBehaviour
{
    // Start is called before the first frame update
    // public GameObject canvasObject;

    //public GameObject trigger;
    //bool Startbol3;
    //public GameObject canvas1;
    public GameObject canvas2;
    public OVRPlayerController playercontroll;
    public GameObject player;
    public GameObject player1;
    public GameObject player3;
    public GameObject canvasobj1;
    public GameObject canvasobj2;
    public GameObject startCanvas;
    public GameObject handr;
    public GameObject handl;
    public GameObject triggerobject;
    int Startbol = 0;
    int Startbol2 = 0;
    int Startbol3 = 0;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Startbol3 = 1;
        if (Startbol2 != 1 && OVRInput.Get(OVRInput.RawAxis1D.RHandTrigger) == 1f || OVRInput.Get(OVRInput.RawAxis1D.LHandTrigger) == 1f || Input.GetKeyDown(KeyCode.B))
        {
            canvas2.SetActive(true);
            startCanvas.SetActive(false);

            player.SetActive(false);
            player3.SetActive(true);
            triggerobject.SetActive(true);
            PlayerPrefs.SetFloat("starttime_fruit", Time.time);
            Startbol2 = 1;


        }

        if (Startbol3 == 1 && (OVRInput.GetUp(OVRInput.Button.One) || Input.GetKeyDown(KeyCode.A)))
        {
            if (Startbol == 0 && Startbol2 == 1)
            {
                //SceneManager.LoadScene("shoppinglist_single");
                // environment1.SetActive(false);
                player.SetActive(false);
                player3.SetActive(false);
                player1.SetActive(true);
                handr.SetActive(false);
                handl.SetActive(false);
                canvasobj1.SetActive(false);
                canvasobj2.SetActive(true);
                playercontroll.Acceleration = 0;
                Startbol = 1;
                //Startbol2 = 0;
            }
            else if (Startbol == 1 && Startbol2 == 1)
            {
                player1.SetActive(false);
                player3.SetActive(true);
                player.SetActive(false);
                handr.SetActive(true);
                handl.SetActive(true);
                canvasobj2.SetActive(false);
                canvasobj1.SetActive(true);
                playercontroll.Acceleration = 0.05f;
                Startbol = 0;
                //Startbol2 = 0;
            }

        }

    }
}




