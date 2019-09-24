using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class beaver_script : MonoBehaviour
{
    public bool is_possessed;
    public bool skill_active;
    public GameObject beaverLog;

    public float sp = 8.0f;
    public Transform[] area1;
    public Transform[] area2;
    public Transform[] spots;
    private int goal;
    private float wait = 2.0f;
    public float logY;
    public float logZ;
    public float logAngle;

    public GameObject player;
    //public GameObject parent;

    private void Start()
    {
        goal = Random.Range(0, spots.Length);
        spots = area1;
    }

    void Update()
    {
        if (is_possessed)
        {
            transform.position = player.transform.position;
            //Quaternion newRotation = Quaternion.LookRotation(player.transform.position) * Quaternion.AngleAxis(180, Vector3.up);
            //transform.rotation = Quaternion.Slerp(transform.rotation, newRotation, 0.05f);
            transform.rotation = player.transform.rotation * Quaternion.AngleAxis(180, Vector3.up);
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, spots[goal].position, sp * Time.deltaTime);

            if (Vector3.Distance(transform.position, spots[goal].position) < 0.3f)
            {
                if (wait > 0)
                    wait -= Time.deltaTime;
                else
                {
                    wait = 2.0f;
                    goal = Random.Range(0, spots.Length);
                }

            }
            else
            {
                Vector3 targetDir = -1 * (spots[goal].position - transform.position);
                Quaternion newRotation = Quaternion.LookRotation(targetDir) * Quaternion.AngleAxis(180, Vector3.up);
                transform.rotation = Quaternion.Slerp(transform.rotation, newRotation, 0.05f);
            }
        }
    }

    public void activate_skill()
    {
        if (is_possessed)
            spawn_log();
    }

    private void spawn_log()
    {
        float x = transform.position.x;
        float y = transform.position.y + logY;
        float z = transform.position.z - logZ; // make these numbers variables
        
        Instantiate(beaverLog, new Vector3(x, y, z), Quaternion.Euler(logAngle, 0, 0));
    }

    public void start_hosting()
    {
        is_possessed = true;
    }

    public void end_hosting()
    {
        is_possessed = false;
    }

}
