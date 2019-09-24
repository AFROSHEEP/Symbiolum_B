using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class predator_script : MonoBehaviour
{
    public float sp = 7.0f;
    public Transform[] spots;
    private int goal;
    private float wait = 1.0f;
    public GameManager GM;

    private void Update()
    {
        Vector3 move = Vector3.MoveTowards(transform.position, spots[goal].position, sp * Time.deltaTime);
        //if (!is_grounded)
        //move.y += 1;
        transform.position = move;

        if (Vector3.Distance(transform.position, spots[goal].position) < 0.3f)
        {
            if (wait > 0)
                wait -= Time.deltaTime;
            else
            {
                wait = 2.0f;
                //goal = Random.Range(0, spots.Length);
                goal++;
                if (goal == spots.Length)
                    goal = 0;
            }

        }
        else
        {
            Vector3 targetDir = -1 * (spots[goal].position - transform.position);
            Quaternion newRotation = Quaternion.LookRotation(targetDir) * Quaternion.AngleAxis(180, Vector3.up);
            transform.rotation = Quaternion.Slerp(transform.rotation, newRotation, 0.05f);
        }
    }

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
