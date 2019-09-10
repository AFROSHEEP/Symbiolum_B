using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bear_push : MonoBehaviour
{
    private float force = 20.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Movable")
        {
            Debug.Log("hit log");
            col.gameObject.GetComponent<Rigidbody>().AddForce(force, 0, 0);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
