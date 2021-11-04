using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player_Movement : MonoBehaviour
{
    public Rigidbody rb;

    public float forwardForce;
    public float sidewaysForce; //yaaaaaaaaay adjusting your speed in console my beloved
    void Start()
    {

    }

    void Update()
    {
        Vector3 vel = Vector3.zero;
        if (Input.GetKey("w"))
        {
            vel += transform.forward * forwardForce;
        }
        if (Input.GetKey("s"))
        {
            vel -= transform.forward * forwardForce;
        }
        if (Input.GetKey("a"))
        {
            vel -= transform.right * sidewaysForce;

        }
        if (Input.GetKey("d"))
        {
            vel += transform.right * sidewaysForce;
        }
        rb.velocity = new Vector3(vel.x, rb.velocity.y, vel.z); //deltatime fucking seems to hate me so have a velocity calculator
    }
}
