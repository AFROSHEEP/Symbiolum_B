using UnityEngine;

public class bear_script : MonoBehaviour
{
    public bool is_possessed;
    public bool skill_active;
    public bool is_grounded;

    public float sp = 8.0f;
    public Transform[] spots;
    private int goal;
    private float wait = 2.0f;

    public GameObject player;

    private void Start()
    {
        //goal = Random.Range(0, spots.Length);
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
                Vector3 targetDir = -1*(spots[goal].position - transform.position);
                Quaternion newRotation = Quaternion.LookRotation(targetDir) * Quaternion.AngleAxis(180, Vector3.up);
                transform.rotation = Quaternion.Slerp(transform.rotation, newRotation, 0.05f);
            }

        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag.Equals("Ground"))
            is_grounded = false;
        else
            is_grounded = true;
            
    }


    public void activate_skill()
    {
        if (skill_active)
            deactivate_skill();
        else
            skill_active = true;
    }

    public void deactivate_skill()
    {
        skill_active = false;
    }

    public void start_hosting()
    {
        is_possessed = true;
    }

    public void end_hosting()
    {
        //deactivate_skill();
        is_possessed = false;
    }
}
