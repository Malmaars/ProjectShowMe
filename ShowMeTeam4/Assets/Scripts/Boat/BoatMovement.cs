using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoatMovement : MonoBehaviour
{
    [Header("Movement speeds")]
    [SerializeField] private float forwardSpeed;
    [SerializeField] private float sidewaysSpeed;
    
    private float direction;
    private Vector3 movement;

    [Header("Waves")]
    [SerializeField] private float waveIntensity;
    [SerializeField] private float waveAmount;

    private void Update()
    {
        GetDirection();
        movement = new Vector3(sidewaysSpeed * direction, Mathf.Sin(Time.time * waveAmount) * waveIntensity, forwardSpeed);
    }

    private void GetDirection()
    {
        if (Input.GetKey(KeyCode.A))
        {
            direction = -1f;
            return;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            direction = 1f;
            return;
        }
        else
            direction = 0f;
    }

    private void FixedUpdate()
    {
        MoveBoat();
    }

    private void MoveBoat()
    {
        transform.Translate(movement * Time.deltaTime);
    }
}