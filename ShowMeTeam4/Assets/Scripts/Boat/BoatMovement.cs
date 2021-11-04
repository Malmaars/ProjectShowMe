using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoatMovement : MonoBehaviour
{
    [Header("Boat")]
    [SerializeField] private GameObject boat;

    [Header("Movement speeds")]
    [SerializeField] private float forwardSpeed;
    [SerializeField] private float sidewaysSpeed;
    
    [HideInInspector] public float direction;
    private float force;
    
    private Vector3 movement;

    [Header("Water interaction")]
    [SerializeField] private float waveIntensity;
    [SerializeField] private float waveAmount;

    public void ChangeDirection(int newDirection, float newForce)
    {
        direction = newDirection;
        force = newForce / 2;
    }

    private void Update()
    {
        movement = new Vector3(sidewaysSpeed * direction * force, Mathf.Sin(Time.time * waveAmount) * waveIntensity, forwardSpeed);
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