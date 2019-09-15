using UnityEngine;

public class mole_script : MonoBehaviour
{
    public bool is_possessed;
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

            if (Input.GetKeyDown(KeyCode.Q))
                activate_skill();
        }
    }

    public void activate_skill()
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
