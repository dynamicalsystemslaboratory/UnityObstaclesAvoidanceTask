using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class changeInstruction : MonoBehaviour
{
    int nextindex;
    // Start is called before the first frame update
    void Start()
    {
        nextindex = SceneManager.GetActiveScene().buildIndex+1;
    }

    // Update is called once per frame
    void Update()
    {
        if (OVRInput.GetDown(OVRInput.Button.SecondaryIndexTrigger, OVRInput.Controller.All))
        {
            SceneManager.LoadScene(nextindex);

        }
    }

    public void Scene()
    {
        SceneManager.LoadScene("instruction3");
    }
}
