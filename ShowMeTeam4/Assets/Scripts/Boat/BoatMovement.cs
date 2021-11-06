using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoatMovement : MonoBehaviour
{
    [Header("Boat")]
    [SerializeField] private GameObject boat;
    [SerializeField] private GameObject floor;
    [SerializeField] private Rigidbody rb;

    [Header("Movement speeds")]
    [SerializeField] private float forwardSpeed;
    float speed;
    [SerializeField] private float sidewaysSpeed;
    
    [HideInInspector] public float direction;
    private float force;
    
    private Vector3 movement;
    private bool inAbility;

    [Header("Water interaction")]
    [SerializeField] private float waveIntensity;
    [SerializeField] private float waveAmount;

    private void Start()
    {
        speed = forwardSpeed;
    }

    public void ChangeDirection(int newDirection, float newForce)
    {
        direction = newDirection;
        force = newForce / 2;
    }

    private void Update()
    {
        movement = new Vector3(sidewaysSpeed * direction * force, 0f, speed);
    }

    private void FixedUpdate()
    {
        MoveBoat();
    }

    private void MoveBoat()
    {
        transform.Translate(movement * Time.deltaTime);
        floor.transform.position = new Vector3(boat.transform.position.x, Mathf.Sin(Time.time * waveAmount) * waveIntensity - .2f, transform.position.z);
    }

    public void Jump(float jumpForce)
    {
        rb.AddForce(0f, transform.up.y * jumpForce, 0f, ForceMode.VelocityChange);
    }

    public void Slomo(float slomoAmount)
    {
        if (inAbility) return;
        inAbility = true;
        speed = speed * slomoAmount;
        StartCoroutine(RevertSpeed(4f));
    }

    public void Speedup(float speedupAmount)
    {
        if (inAbility) return;
        inAbility = true;
        speed = speed * speedupAmount;
        StartCoroutine(RevertSpeed(2.5f));
    }

    private IEnumerator RevertSpeed(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        speed = forwardSpeed;
        inAbility = false;
    }
}