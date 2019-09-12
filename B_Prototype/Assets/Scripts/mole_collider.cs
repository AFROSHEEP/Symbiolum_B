using UnityEngine;

public class mole_collider : MonoBehaviour
{
    public delegate void mole();
    public static event mole mole_in_range;
    public static event mole mole_out_range;

    private bool is_possessed;
    public bool skill_active;
    public GameObject player;
    public GameObject parent;

    public GameObject Lilipad;

    // Start is called before the first frame update
    void Update()
    {
        if (is_possessed)
        {
            transform.parent.position = player.transform.position;
            //transform.parent.rotation = player.transform.rotation;

            if (Input.GetMouseButtonDown(0))
            {
                activate_skill();
                //Debug.Log("mouse1");
                //Debug.Log("skill_active: " + skill_active);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (mole_in_range != null)
            mole_in_range();
    }

    private void OnTriggerExit(Collider other)
    {
        if (mole_out_range != null)
            mole_out_range();
    }

    private void OnEnable()
    {
        PlayerController.possess_mole += start_hosting_mole;
        PlayerController.unpossess_mole += end_hosting_mole;
    }

    private void OnDisable()
    {
        PlayerController.possess_mole -= start_hosting_mole;
        PlayerController.unpossess_mole -= end_hosting_mole;
    }

    void activate_skill()
    {
        if (skill_active)
            deactivate_skill();

        else
        {
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

            //SphereCollider[] ss = parent.GetComponentsInChildren<SphereCollider>();
            //foreach (SphereCollider s in ss)
            //    s.enabled = false;
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

    private void start_hosting_mole()
    {
        is_possessed = true;
    }

    private void end_hosting_mole()
    {
        deactivate_skill();
        is_possessed = false;
    }
}
