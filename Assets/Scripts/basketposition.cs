using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class basketposition : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject playerobject;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position= new Vector3(playerobject.transform.position.x - 0.7f, this.transform.position.y, this.transform.position.z);

    }

    //private void OnCollisionExit(Collision collision)
    //{
    //    print("notcolliding");
    //    this.transform.position = this.transform.parent.position;
    //}
}
