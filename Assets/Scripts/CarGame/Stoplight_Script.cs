using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stoplight_Script : MonoBehaviour
{

    public GameObject objRed, objGreen;
    public Material red_lit, green_lit, red_dim, green_dim;
    public GameObject stoplightTrigger;


    public void setLights(bool status)
    {
        if(status)
        {
            objGreen.GetComponent<Renderer>().material = green_lit;
            objRed.GetComponent<Renderer>().material = red_dim;
            stoplightTrigger.SetActive(false);

            return;
        }

        objGreen.GetComponent<Renderer>().material = green_dim;
        objRed.GetComponent<Renderer>().material = red_lit;
        stoplightTrigger.SetActive(true);

    }

}
