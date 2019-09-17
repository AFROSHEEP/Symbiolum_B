using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class log_block : MonoBehaviour
{
    public GameObject log;
    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
            if (other.gameObject.GetComponent<PlayerController>().host != null)
                if (other.gameObject.GetComponent<PlayerController>().host.type == Animal.Bear)
                    log.GetComponent<Rigidbody>().isKinematic = false;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
            if (other.gameObject.GetComponent<PlayerController>().host != null)
                if (other.gameObject.GetComponent<PlayerController>().host.type == Animal.Bear)
                    log.GetComponent<Rigidbody>().isKinematic = true;
    }
}