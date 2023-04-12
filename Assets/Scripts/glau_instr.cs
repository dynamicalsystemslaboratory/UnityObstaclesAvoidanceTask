using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class glau_instr : MonoBehaviour
{

    // Start is called before the first frame update
    public GameObject canvas1;
    public GameObject arrow1;
    public GameObject canvas2;
    public GameObject center1;
    public GameObject center2;
    public bool flagbol = false;
    public bool flagbol2 = false;
    public OVRPlayerController player1;
    float start;
    //public bool flagbol = false;

    void Start()
    {
        start = Time.time;
        // flagbol = false;
        player1.Acceleration = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        print(Time.time - start);
        if (OVRInput.Get(OVRInput.Button.One) || Input.GetKeyDown(KeyCode.B))
        {
            // positionx = player.transform.x;
            if (flagbol == false && flagbol2 == false&& (Time.time-start)>1f)
            {
                player1.Acceleration = 0.4f;
                center1.SetActive(false);
                center2.SetActive(true);
                canvas1.SetActive(false);

                flagbol = true;
            }
            else if (flagbol == true && flagbol2 == true)
            {
                scenechange();
            }

        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        arrow1.SetActive(false);
        center1.SetActive(true);
        center2.SetActive(false);
        canvas2.SetActive(true);
        flagbol2 = true;
    }

    void scenechange()
    {

        SceneSwitcher.nextscene();


    }
}
