using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using UnityEngine;

public class GrabStuff : MonoBehaviour
{
    public Transform HoldPosition;
    public float ArmLength;
    public Transform Target = null;
    public float GrabSpeed;

    public LayerMask KutNaam;

    void Start()
    {

    }


    void Update()
    {

        //if you are not holding anything, left mouse click will grab an item, otherwise it will drop the one you are holding
        if (Input.GetMouseButtonDown(0))
        {
            if (Target == null)
            {
                CanHold();
            }
            else
            {
                DropItem();
            }
        }

        if (Target != null)
        {
            //Grabs position of the target and calculates new position and how fast it reaches the new position
            //Target.position = Vector3.Lerp(Target.position, HoldPosition.position, GrabSpeed * Time.deltaTime);
            Target.position = HoldPosition.position;
        }
    }

    // Looks if there is a target in the range of the raycast, if true, it throws the transform of the hit in the target
    void CanHold()
    {
        RaycastHit _hit;
        Debug.DrawRay(transform.position, transform.forward * 20, Color.red, 10);
        //make raycast, a line to return values of objects, only gets objects in layer "YouCanGetThis
        if (Physics.Raycast(transform.position, transform.forward, out _hit, ArmLength, KutNaam))
        {
            //makes sure you can only grap things in one layer, and plays the object audio when grabbed
            if (_hit.transform.gameObject.layer == 8)
            {
                print("heb iets");
                Target = _hit.transform;
                Target.GetComponent<Rigidbody>().useGravity = false;
                Target.GetComponent<AudioSource>().Play();
            }
            //shows when you're not grabbing anything
            else
            {
                print($"nopee {_hit.transform.gameObject.name}");
            }
        }
        else
        {
            print("nope");
        }
    }
    void DropItem()
    {
        Target.GetComponent<Rigidbody>().useGravity = true;
        Target = null;
    }
}

