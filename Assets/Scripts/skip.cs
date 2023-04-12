using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class skip : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if ( OVRInput.Get(OVRInput.Button.Two))
        {
            SceneManager.LoadScene("Main");
        }
    }
}
