using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class car_script : MonoBehaviour
{

    Transform trans;
    Rigidbody rb;

    public Car car;


    void Start()
    {
        trans = gameObject.transform;
        rb = gameObject.GetComponent<Rigidbody>();

        car = new Car();

        //rb.velocity = (Vector3.forward * car.speed);
    }

    
    void Update()
    {

        trans.position += Vector3.forward * car.speed * Time.deltaTime;
        
    }
}
