using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;
using TMPro;
using UnityEngine.SceneManagement;

public class Stoplight_Controller : MonoBehaviour, IVirtualButtonEventHandler
{
    public GameObject button1, button2, button3, button4;
    public GameObject light1, light2, light3, light4;
    //GameObject plane1, plane2, plane3, plane4;
    public Plane plane1, plane2, plane3, plane4;
    public Material red_lit, red_dim, green_lit, green_dim;

    public CarSpawner game;

    void Start()
    {
        button1.GetComponent<VirtualButtonBehaviour>().RegisterEventHandler(this);
        button2.GetComponent<VirtualButtonBehaviour>().RegisterEventHandler(this);
        button3.GetComponent<VirtualButtonBehaviour>().RegisterEventHandler(this);
        button4.GetComponent<VirtualButtonBehaviour>().RegisterEventHandler(this);

        plane1 = new Plane(button1.transform.GetChild(0).gameObject, false, light1);
        plane2 = new Plane(button2.transform.GetChild(0).gameObject, false, light2);
        plane3 = new Plane(button3.transform.GetChild(0).gameObject, false, light3);
        plane4 = new Plane(button4.transform.GetChild(0).gameObject, false, light4);

        setLight(plane1);
        setLight(plane2);
        setLight(plane3);
        setLight(plane4);

    }


    void Update()
    {
        
    }

    public void OnButtonPressed(VirtualButtonBehaviour vb)
    {


    }

    public void OnButtonReleased(VirtualButtonBehaviour vb) // Virtual button released...
    {


        if(!game.gameActive) // If game isn't active (which only occurs when game has ended), restart game
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

        if(!game.startGame) // If game isn't started, start game
        {
            game.startGame = true;
        }
        else // Stoplight Control while game is active
        {
            if (vb.VirtualButtonName == button1.GetComponent<VirtualButtonBehaviour>().VirtualButtonName)
            {
                setLight(plane1);

            }
            else if (vb.VirtualButtonName == button2.GetComponent<VirtualButtonBehaviour>().VirtualButtonName)
            {
                setLight(plane2);
            }
            else if (vb.VirtualButtonName == button3.GetComponent<VirtualButtonBehaviour>().VirtualButtonName)
            {
                setLight(plane3);
            }
            else if (vb.VirtualButtonName == button4.GetComponent<VirtualButtonBehaviour>().VirtualButtonName)
            {
                setLight(plane4);
            }
        }

        

    }

    void setLight(Plane plane)
    {

        if(plane.isGreen)
        {
            plane.plane.GetComponent<Renderer>().material = red_lit;
            plane.isGreen = false;
            
        }
        else
        {
            plane.plane.GetComponent<Renderer>().material = green_lit;
            plane.isGreen = true;
            
        }

        plane.light.GetComponent<Stoplight_Script>().setLights(plane.isGreen);

    }
}
