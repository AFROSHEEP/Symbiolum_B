using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Animal { Bear, Mole, Fish, Fox, Beaver, Bunny };

public class Host : MonoBehaviour
{
    public float size;
    public bool water;
    public float speed;
    public float jumpSpeed;
    public float yOffset;
    public Animal type;
    public bool skill_active;
    public Host host;

    public GameObject Mole;
    public GameObject Bear;
    public GameObject Fish;

    public Animal[] Prey = { Animal.Mole, Animal.Bunny, Animal.Beaver };

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
            activate();
    }

    private void activate()
    {
        switch (type)
        {
            case Animal.Bear:
                Bear.GetComponentInChildren<bear_script>().activate_skill();
                break;
            case Animal.Mole:
                Mole.GetComponentInChildren<mole_script>().activate_skill();
                break;
            case Animal.Fish:
                break;
        }
    }

    public void start_host()
    {
        switch (type)
        {
            case Animal.Bear:
                Bear.GetComponentInChildren<bear_script>().start_hosting_bear();
                break;
            case Animal.Mole:
                Mole.GetComponentInChildren<mole_script>().start_hosting_mole();
                break;
            case Animal.Fish:
                Fish.GetComponentInChildren<fish_script>().start_hosting_fish();
                break;
        }
    }
}
