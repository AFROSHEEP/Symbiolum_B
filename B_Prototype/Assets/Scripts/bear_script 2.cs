using UnityEngine;

public class bear_script : MonoBehaviour
{
    public bool is_possessed;
    public bool skill_active;

    public GameObject player;

    void Update()
    {
        if (is_possessed)
            transform.position = player.transform.position;
    }

    public void activate_skill()
    {
        if (skill_active)
            deactivate_skill();

        skill_active = true;
    }

    public void deactivate_skill()
    {
        skill_active = false;
    }

    private void start_hosting_bear()
    {
        is_possessed = true;
    }

    public void end_hosting_bear()
    {
        deactivate_skill();
        is_possessed = false;
    }
}
