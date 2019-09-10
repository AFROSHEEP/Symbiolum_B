using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class kill_player : MonoBehaviour
{

    public delegate void kill();
    public static event kill restart; 
    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.tag == "Player")
            if (restart != null)
                restart();
    }
}
