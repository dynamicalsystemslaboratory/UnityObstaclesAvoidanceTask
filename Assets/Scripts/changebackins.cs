using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class changebackins : MonoBehaviour
{

    // Start is called before the first frame update

    bool ready = false;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (OVRInput.Get(OVRInput.Button.One) || Input.GetKeyDown(KeyCode.B))
        {
            // positionx = player.transform.x;

            scenechange();

        }
    }

    void scenechange()
    {

        SceneSwitcher.nextscene();

    }
}

