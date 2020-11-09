using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//Vuforia automatically enables GameObjects MeshRenderer components when the are tracked. This is no good for trigger objects which shouldn't be seen by the player.
//This script makes sure they remain disabled

public class RenderDisabler : MonoBehaviour
{
    private MeshRenderer rend;
    void Start()
    {
        rend = gameObject.GetComponent<MeshRenderer>();
    }

    void Update()
    {
        if(rend.enabled)
        {
            rend.enabled = false;
        }
    }
}
