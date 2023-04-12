using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class grabright : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject startCanvas;
    public GameObject center1;
    public GameObject center2;
    public GameObject center3;
    public GameObject triggeritem;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(OVRInput.Get(OVRInput.RawAxis1D.RHandTrigger)==1f|| OVRInput.Get(OVRInput.RawAxis1D.LHandTrigger)==1f || Input.GetKeyDown(KeyCode.B))
        {
            startCanvas.SetActive(false);
            center1.SetActive(false);
            center2.SetActive(true);
            triggeritem.SetActive(true);
            center3.SetActive(true);
            PlayerPrefs.SetFloat("starttime_bed", Time.time);
        }
    }
}
