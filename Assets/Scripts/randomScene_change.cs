using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class randomScene_change : MonoBehaviour
{
    // Start is called before the first frame update
    bool checkend = false;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void OnCollisionEnter(Collision collision)
    {

        for(int n = 0; n < 10; n++)
        {
            if(SceneSwitcher.scenecheck[n] == false)
            {

                checkend = true;
                break;
            }
        }

        if(checkend == true)
        {
            SceneSwitcher.bolflag = true;
            SceneSwitcher.experiments();
        }
        else
        {
            SceneSwitcher.end();
        }
       

    }
}
