using UnityEngine;

public class mole_collider : MonoBehaviour
{
    public delegate void mole();
    public static event mole mole_in_range;
    public static event mole mole_out_range;

    private bool is_possessed;
    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (is_possessed)
        {
            transform.parent.position = player.transform.position;
            //transform.parent.rotation = player.transform.rotation;
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

    private void start_hosting_mole()
    {
        Debug.Log("mole is hosting");
        //gameObject.GetComponentInChildren<MeshCollider>().enabled = false;
        is_possessed = true;
    }

    private void end_hosting_mole()
    {
        //gameObject.GetComponentInChildren<MeshCollider>().enabled = true;
        Debug.Log("mole is not hosting");
        is_possessed = false;
    }
}
