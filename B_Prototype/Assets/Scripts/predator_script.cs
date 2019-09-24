using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class predator_script : MonoBehaviour
{
    public GameManager GM;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            GM.GetComponent<GameManager>().restart_scene();
        }

        else if (other.gameObject.tag == "Animal")
        {
            if (is_prey(other))
            {
                //deactivate renderers
                MeshRenderer[] rs = other.gameObject.GetComponentsInChildren<MeshRenderer>();
                foreach (MeshRenderer r in rs)
                    r.enabled = false;

                //deactivate colliders
                BoxCollider[] bs = other.gameObject.GetComponentsInChildren<BoxCollider>();
                foreach (BoxCollider b in bs)
                    b.enabled = false;
            }
        }
    }

    private bool is_prey(Collider other)
    {
        Host host = other.GetComponent<Host>();
        
        if (host.Prey.Contains(host.type))
            return true;

        return false;
    }
}
