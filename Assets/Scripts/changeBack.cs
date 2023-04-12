using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class changeBack : MonoBehaviour
{

    // Start is called before the first frame update
   public GameObject player;
    bool ready= false;
    void Start()
    {
      
}

    // Update is called once per frame
    void Update()
    {
        if (OVRInput.Get(OVRInput.Button.One) || Input.GetKeyDown(KeyCode.B))
        {
           // positionx = player.transform.x;
            PlayerPrefs.SetFloat("lastpositionx",player.transform.position.x );
            PlayerPrefs.SetFloat("lastpositiony", player.transform.position.y);
            PlayerPrefs.SetFloat("lastpositionz", player.transform.position.z);

            
            ready = true;
            scenechange();
            
        }
    }

    void scenechange()
    {
        if (ready == true)
        {
            SceneManager.LoadScene("main");
        }
    }
}
