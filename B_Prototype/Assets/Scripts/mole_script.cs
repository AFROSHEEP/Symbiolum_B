using UnityEngine;

public class mole_script : MonoBehaviour
{
    public bool is_possessed;
    public bool skill_active;

    public float sp = 8.0f;
    public Transform[] area1;
    public Transform[] area2;
    public Transform[] spots;
    private int goal;
    private float wait = 2.0f;

    public GameObject player;
    public GameObject parent;
    public GameObject Lilipad;

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
            if (transform.position.z < 50)
                spots = area2;
            else
                spots = area1;
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
        {
            if (skill_active)
                deactivate_skill();

            else
            {
                //Debug.Log("Activating Mole");
                skill_active = true;

                //activate particle effect
                Lilipad.GetComponent<ParticleSystem>().Play();

                //deactivate meshrenderers
                MeshRenderer[] rs = parent.GetComponentsInChildren<MeshRenderer>();
                foreach (MeshRenderer r in rs)
                    r.enabled = false;

                //deactivate colliders
                BoxCollider[] bs = parent.GetComponentsInChildren<BoxCollider>();
                foreach (BoxCollider b in bs)
                    b.enabled = false;
            } 
        }
    }

    void deactivate_skill()
    {
        skill_active = false;

        //deactivate particle effect
        Lilipad.GetComponent<ParticleSystem>().Stop();

        //activate meshRenderers
        MeshRenderer[] rs = parent.GetComponentsInChildren<MeshRenderer>();
        foreach (MeshRenderer r in rs)
            r.enabled = true;

        //activate colliders
        BoxCollider[] bs = parent.GetComponentsInChildren<BoxCollider>();
        foreach (BoxCollider b in bs)
            b.enabled = true;
    }

    public void start_hosting()
    {
        is_possessed = true;
    }

    public void end_hosting()
    {
        deactivate_skill();
        is_possessed = false;
    }
}
