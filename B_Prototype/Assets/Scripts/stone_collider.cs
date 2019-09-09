using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stone_collider : MonoBehaviour
{
    public delegate void range();
    public static event range in_range;
    public static event range out_range;

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
            transform.parent.rotation = player.transform.rotation;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (in_range != null)
            in_range();
    }

    private void OnTriggerExit(Collider other)
    {
        if (out_range != null)
            out_range();
    }

    //public void possess()
    //{
    //    //get animal in range
    //    //player pos = animal pos and lock
    //    //make it so can't possess again
    //    //turn off wisp mesh renderer
    //    //change movement variables
    //    //enable animal skill
    //}

    private void OnEnable()
    {
        PlayerController.possess_stone += start_hosting_stone;
        PlayerController.unpossess_stone += end_hosting_stone;
    }

    private void OnDisable()
    {
        PlayerController.possess_stone -= start_hosting_stone;
        PlayerController.unpossess_stone -= end_hosting_stone;
    }

    private void start_hosting_stone()
    {
        Debug.Log("stone is hosting");
        //gameObject.GetComponentInChildren<MeshCollider>().enabled = false;
        is_possessed = true;
    }

    private void end_hosting_stone()
    {
        //gameObject.GetComponentInChildren<MeshCollider>().enabled = true;
        Debug.Log("stone is not hosting");
        is_possessed = false;
    }
}
