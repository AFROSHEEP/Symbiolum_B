using UnityEngine;

public class bear_collider : MonoBehaviour
{
    public delegate void bear();
    public static event bear bear_in_range;
    public static event bear bear_out_range;

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
        {
            //playerPos = player.transform.position;
            //playerPos.y += 2;
            transform.parent.position = player.transform.position;
            
            //transform.parent.rotation = player.transform.rotation;
        }
    
    }

    private void OnTriggerEnter(Collider other)
    {
        if (bear_in_range != null)
            bear_in_range();
    }

    private void OnTriggerExit(Collider other)
    {
        if (bear_out_range != null)
            bear_out_range();
    }

    private void OnEnable()
    {
        PlayerController.possess_bear += start_hosting_bear;
        PlayerController.unpossess_bear += end_hosting_bear;
    }

    private void OnDisable()
    {
        PlayerController.possess_bear -= start_hosting_bear;
        PlayerController.unpossess_bear -= end_hosting_bear;
    }

    private void start_hosting_bear()
    {
        //gameObject.GetComponentInChildren<MeshCollider>().enabled = false;
        is_possessed = true;
    }

    private void end_hosting_bear()
    {
        //gameObject.GetComponentInChildren<MeshCollider>().enabled = true;
        is_possessed = false;

        // deactivate skill
    }
}
