using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class initialPos : MonoBehaviour
{
    // Start is called before the first frame update
    float positionx;
    float positiony;

    float positionz;
    // public GameObject player;
    bool initial=true;
    Vector3 playerposition;
    void Start()
    {
        positionx = PlayerPrefs.GetFloat("lastpositionx");
        positiony = PlayerPrefs.GetFloat("lastpositiony");
        positionz = PlayerPrefs.GetFloat("lastpositionz");
        playerposition = new Vector3(positionx, positiony, positionz);
        if (positionx == 0.0f && positiony == 0.0f && positionz == 0.0f)
        {
            initial = false;
        }

        if(initial == true) {
            transform.position = playerposition;
        }
 
    

    }

    // Update is called once per frame
    void Update()
    {
        if(positionx==0.0f && positiony == 0.0f && positionz == 0.0f)
        {
            initial = false;
        }

        if (initial == true)
        {

            playerposition = new Vector3(positionx, positiony, positionz);
            transform.position = playerposition;
            print("translating" + playerposition);
            initial = false;
        }

    }
}

