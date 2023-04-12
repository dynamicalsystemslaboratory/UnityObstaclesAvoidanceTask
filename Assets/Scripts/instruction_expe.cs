using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class instruction_expe : MonoBehaviour
{

    // Start is called before the first frame update
    public GameObject canvas1;
    public GameObject arrow1;
    public GameObject canvas2;
    public bool flagbol= false;
    public bool flagbol2 = false;
    public OVRPlayerController player1;

    void Start()
    {
        player1.Acceleration = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (OVRInput.Get(OVRInput.Button.One) || Input.GetKeyDown(KeyCode.B))
        {
            // positionx = player.transform.x;
            if (flagbol == false && flagbol2 == false)
            {
                canvas1.SetActive(false);
                player1.Acceleration = 0.4f;
      
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
        canvas2.SetActive(true);
        flagbol2 = true;
    }

    void scenechange()
    {

        SceneSwitcher.nextscene();
        

    }
}
