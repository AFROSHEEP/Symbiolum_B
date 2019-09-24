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
    public GameObject Beaver;
    public GameObject Bunny;

    public Animal[] Prey = { Animal.Mole, Animal.Bunny, Animal.Beaver };
    //public Animal[] Prey = { Animal.Bunny, Animal.Beaver };

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
            case Animal.Beaver:
                Beaver.GetComponentInChildren<beaver_script>().activate_skill();
                break;
            case Animal.Bunny:
                Bunny.GetComponentInChildren<bunny_script>().activate_skill();
                break;
        }
    }

    public void start_host()
    {
        switch (type)
        {
            case Animal.Bear:
                Bear.GetComponentInChildren<bear_script>().start_hosting();
                break;
            case Animal.Mole:
                Mole.GetComponentInChildren<mole_script>().start_hosting();
                break;
            case Animal.Fish:
                Fish.GetComponentInChildren<fish_script>().start_hosting();
                break;
            case Animal.Beaver:
                Beaver.GetComponentInChildren<beaver_script>().start_hosting();
                break;
            case Animal.Bunny:
                Bunny.GetComponentInChildren<bunny_script>().start_hosting();
                break;
        }
    }
}
