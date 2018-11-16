using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy : MonoBehaviour {

    private void Start()
    {
        //Destroy the object 5 seconds after spawning
        Destroy(gameObject, 5);

    }
}
