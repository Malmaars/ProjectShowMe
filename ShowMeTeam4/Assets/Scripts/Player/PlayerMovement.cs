using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private LayerMask layerMask;
    private Vector3 dir;
    private Camera cam;
    private Rigidbody rb;

    private void Start()
    {
        cam = Camera.main;
    }

    private void Update()
    {
        dir = new Vector3(Input.GetAxisRaw("Horizontal"), transform.position.y, Input.GetAxisRaw("Vertical"));
        
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            if (rb != null)
            {
                rb.isKinematic = true;
            }

            rb = null;
            RaycastHit hit;
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        
            if (Physics.Raycast(ray, out hit, Mathf.Infinity, layerMask))
            {
                rb = hit.collider.gameObject.GetComponent<Rigidbody>();
                rb.isKinematic = false;
            }
        }
    }

    private void FixedUpdate()
    {
        if (rb == null) return;
        rb.velocity = new Vector3(dir.x * speed, transform.position.y, dir.z * speed);
    }
} 