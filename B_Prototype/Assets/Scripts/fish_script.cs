using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fish_script : MonoBehaviour
{
    public bool is_possessed;
    public GameObject player;

    void Update()
    {
        if (is_possessed)
            transform.position = player.transform.position;
    }

    public void start_hosting_fish()
    {
        is_possessed = true;
    }

    public void end_hosting_fish()
    {
        is_possessed = false;
    }
}
