using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Shoppinglist: MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject startCanvas;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (OVRInput.Get(OVRInput.RawAxis1D.RHandTrigger) == 1f || OVRInput.Get(OVRInput.RawAxis1D.LHandTrigger) == 1f)
        {
            SceneManager.LoadScene("storeScene");
        }
    }
}
