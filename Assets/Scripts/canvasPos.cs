using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class canvasPos : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject playerobject;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position = new Vector3(playerobject.transform.position.x - 1.2f, playerobject.transform.position.y-0.1f, playerobject.transform.position.z+0.2f);

    }

    //private void OnCollisionExit(Collision collision)
    //{
    //    print("notcolliding");
    //    this.transform.position = this.transform.parent.position;
    //}
}
