using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class car_script : MonoBehaviour
{

    private CarSpawner cs;
    public Transform trans;
    public Rigidbody rb;
    public Vector3 direction;
    public Transform raycastOrigin;
    public bool isStopped;
    private float tick;
    private bool startFromStop;
    public bool isInIntersection;
    public bool goodForPoints;

    public Car car;

    private void Awake()
    {
        cs = GameObject.Find("scene").GetComponent<CarSpawner>();
    }

    void Start()
    {
        
        car = new Car();
        isStopped = false;
        startFromStop = false;
        tick = 0;
        isInIntersection = false;
        goodForPoints = false;
        randomColor();

    }

    
    void Update()
    {

        if(!cs.gameActive)
        {
            isStopped = true;
        }

        //Start from stop makes sure that cars space out when they start from a stop
        if(startFromStop)
        {

            tick += 1;

            if(tick >= 60)
            {
                tick = 0;
                startFromStop = false;
                isStopped = false;
            }
        }

        //If the car isn't supposed to be stopped, move it forward
        if(!isStopped)
        {
            trans.position += -trans.forward * car.speed * Time.deltaTime;
        }

    }

    private void FixedUpdate()
    {

        if (!isInIntersection)
        {



            RaycastHit hit;

            //Raycast detection to let the car know when to stop
            if (Physics.Raycast(raycastOrigin.position, -raycastOrigin.forward, out hit, 100))
            {
                if (hit.transform.tag == "stoplight_trigger")
                {
                    float dist = Vector3.Distance(hit.transform.position, raycastOrigin.position);

                    if (dist <= .22)
                    {
                        isStopped = true;
                    }
                    else
                    {
                        if (!startFromStop) { startFromStop = true; }
                    }
                }
                else if (hit.transform.tag == "car")
                {

                    float dist = Vector3.Distance(hit.transform.position, raycastOrigin.position);

                    if (dist <= .22)
                    {
                        isStopped = true;

                    }
                    else
                    {
                        if (!startFromStop) { startFromStop = true; }
                    }
                }
                else
                {
                    if (!startFromStop) { startFromStop = true; }
                }
            }
            else
            {
                if (!startFromStop) { startFromStop = true; }
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.transform.name);
    }

    private void randomColor()
    {
        var color = UnityEngine.Random.ColorHSV();
        gameObject.transform.GetChild(0).transform.Find("body").GetComponent<Renderer>().material.color = color;
        gameObject.transform.GetChild(0).transform.Find("cap").GetComponent<Renderer>().material.color = color;
        gameObject.transform.GetChild(0).transform.Find("front_windshield_back").GetComponent<Renderer>().material.color = color;
        gameObject.transform.GetChild(0).transform.Find("rear_windshield_back").GetComponent<Renderer>().material.color = color;

    }
}
