using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class kill_player : MonoBehaviour
{
    public delegate void kill();
    public static event kill restart;

    public GameObject mole;

    private void OnTriggerStay(Collider other)
    {
        if (mole.transform.Find("range_sphere").GetComponentInChildren<mole_collider>().skill_active)
        {
            transform.Find("impassible cube").GetComponent<BoxCollider>().enabled = false;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        transform.Find("impassible cube").GetComponent<BoxCollider>().enabled = true;
    }
}
