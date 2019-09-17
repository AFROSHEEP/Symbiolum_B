using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class water_script : MonoBehaviour
{
    public delegate void time();
    public static event time time_up;

    public int timer;
    private int original_timer;
    public GameManager GM;

    private void Start()
    {
        original_timer = timer;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
            if (other.gameObject.GetComponent<PlayerController>().host == null)
                StartCoroutine("countdown");
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
            if (other.gameObject.GetComponent<PlayerController>().host != null)
                if (other.gameObject.GetComponent<PlayerController>().host.type == Animal.Fish)
                    StopCoroutine("countdown");
    }

    private IEnumerator countdown()
    {
        timer = original_timer;

        while (timer > 0)
        {
            yield return new WaitForSeconds(1);
            timer--;
        }

        GM.GetComponent<GameManager>().restart_scene();
    }
}
