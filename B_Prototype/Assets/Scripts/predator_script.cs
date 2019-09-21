using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class predator_script : MonoBehaviour
{
    public GameManager GM;

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("collided");

        if (other.gameObject.tag == "Player")
        {
            Debug.Log("player");

            GM.GetComponent<GameManager>().restart_scene();
        }

        else
        {
            Debug.Log("not player");

            if (is_prey(other))
            {
                Debug.Log("is prey");

                Destroy(other.gameObject);
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
