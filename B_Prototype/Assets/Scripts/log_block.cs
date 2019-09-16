using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class log_block : MonoBehaviour
{
    public GameObject Bear;
    void OnTriggerEnter(Collider other)
    {
        if (Bear.GetComponentInChildren<bear_script>().skill_active)
        {
            GetComponent<Rigidbody>().AddForce(20, 20, 20);
        }
    }

    void start()
    {
        GetComponent<Rigidbody>().AddRelativeForce(200.0f, 200.0f, 200.0f);
    }
}
