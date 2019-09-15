using UnityEngine;

public class bear_script : MonoBehaviour
{
    private bool is_possessed;
    public GameObject player;
    Vector3 playerPos;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (is_possessed)
            transform.parent.position = player.transform.position;
    }

    private void start_hosting_bear()
    {
        is_possessed = true;
    }

    private void end_hosting_bear()
    {
        is_possessed = false;

        // deactivate skill
    }
}
