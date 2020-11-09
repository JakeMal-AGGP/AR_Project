using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bodyCollision : MonoBehaviour
{

    //I really didnt want to have to make an entire new script just to detect collisions, but unity forced my hand

    private CarSpawner cs;
    private car_script car;

    private void Awake()
    {
        cs = GameObject.Find("scene").GetComponent<CarSpawner>();
        car = transform.parent.GetComponentInParent<car_script>();

    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.transform.tag == "outofbounds")
        {
            if(car.goodForPoints) // if the car hits outofbounds while goodForPoints is true, that indicates that they have successfully passed through the intersection. Add points
            {
                cs.addPoints(100);
                Destroy(car.gameObject);
            }
        }

        if (other.transform.name == "intersection")
        {
            car.isInIntersection = true;
            car.goodForPoints = true;
        }
        else
        {
            car.isInIntersection = false;
        }


        if (other.transform.tag == "car")
        {
            if(cs)
            {
                cs.gameStatus = "Car crash!";
                cs.gameActive = false;
            }
        }
    }

}
