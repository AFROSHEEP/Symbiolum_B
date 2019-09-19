using UnityEngine;

public class mole_script : MonoBehaviour
{
    public bool is_possessed;
    public bool skill_active;

    public GameObject player;
    public GameObject parent;
    public GameObject Lilipad;

    void Update()
    {
        if (is_possessed)
            transform.position = player.transform.position;
    }

    public void activate_skill()
    {
        if (skill_active)
            deactivate_skill();

        else if(is_possessed)
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

    public void start_hosting_mole()
    {
        is_possessed = true;
    }

    public void end_hosting_mole()
    {
        deactivate_skill();
        is_possessed = false;
    }
}
