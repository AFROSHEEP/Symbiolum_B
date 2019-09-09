using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalManager : MonoBehaviour
{
    List<GameObject> Animals = new List<GameObject>();

    public delegate void range();
    public static event range in_range;
    // Start is called before the first frame update
    void Start()
    {
        //instantiate animals
        //add to animals list
    }

    //Update is called once per frame
    void Update()
    {
        //if triggered, send info to gameManager
    }
}
