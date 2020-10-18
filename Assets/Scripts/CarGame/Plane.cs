using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plane
{
    public Plane(GameObject p, bool ig, GameObject l)
    {

        plane = p;
        isGreen = ig;
        light = l;

    }

    public GameObject plane;
    public bool isGreen;
    public GameObject light;

}
