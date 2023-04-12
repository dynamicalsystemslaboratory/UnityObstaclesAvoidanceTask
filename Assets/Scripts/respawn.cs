using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class respawn : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject[] socks = new GameObject[9];

   // public GameObject towel;
    Vector3[] positions = new Vector3[9];

    void Start()
    {
        for (int i = 0; i < 9; i++)
        {
            positions[i] = socks[i].transform.position;

        }

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter(Collision other)
    {
        for (int i = 0; i < 9; i++)
        {
            if (other.gameObject == socks[i])
            {
                other.transform.position = positions[i];
            }
        }
    }
}
