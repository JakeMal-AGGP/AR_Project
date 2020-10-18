using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stoplight_Script : MonoBehaviour
{

    public GameObject objRed, objGreen;
    public Material red_lit, green_lit, red_dim, green_dim;


    private void Awake()
    {
        
    }

    void Start()
    {
        
    }

    
    void Update()
    {
       
    }

    public void setLights(bool status)
    {
        if(status)
        {
            objGreen.GetComponent<Renderer>().material = green_lit;
            objRed.GetComponent<Renderer>().material = red_dim;

            return;
        }

        objGreen.GetComponent<Renderer>().material = green_dim;
        objRed.GetComponent<Renderer>().material = red_lit;

    }

}
