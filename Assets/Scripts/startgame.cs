using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class startgame : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject canvasObject;
    public GameObject center1;
    public GameObject center2;
    public GameObject center3;
    public GameObject trigger;
    bool Startbol3;
    public GameObject canvas1;
    public GameObject canvas2;
    public GameObject canvas3;

    public OVRPlayerController player;
    int Startbol = 0;
    int Startbol2 = 0;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Startbol2 = 1;

        if(Startbol3 ==false&& (OVRInput.Get(OVRInput.RawAxis1D.RHandTrigger) == 1f || OVRInput.Get(OVRInput.RawAxis1D.LHandTrigger) == 1f || Input.GetKeyDown(KeyCode.B)))
        {
            canvasObject.SetActive(false);
            center1.SetActive(false);
            center2.SetActive(true);
            trigger.SetActive(true);
            Startbol3 = true;
            canvas3.SetActive(true);
            PlayerPrefs.SetFloat("starttime_store", Time.time);
        }

        if(Startbol2 == 1 && (OVRInput.GetUp(OVRInput.Button.One) || Input.GetKeyDown(KeyCode.A)))
        {
            if (Startbol == 0)
            {
                //SceneManager.LoadScene("shoppinglist_single");
               // environment1.SetActive(false);
                center3.SetActive(true);
                center2.SetActive(false);
                canvas1.SetActive(true);
                canvas2.SetActive(false);
                player.Acceleration = 0;
                Startbol = 1;
                Startbol2 = 0;
            }
            else
            {
                center3.SetActive(false);
                center2.SetActive(true);
                canvas1.SetActive(false);
                canvas2.SetActive(true);
                player.Acceleration = 0.1f;
                Startbol = 0;
                Startbol2 = 0;
            }

        }

    }
}
        


     
