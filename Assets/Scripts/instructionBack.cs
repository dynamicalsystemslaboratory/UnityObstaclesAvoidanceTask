using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class instructionBack : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (OVRInput.Get(OVRInput.Button.One) || Input.GetKeyDown(KeyCode.B))
        {
            SceneManager.LoadScene("instruction_menu");
        }
    }
}
