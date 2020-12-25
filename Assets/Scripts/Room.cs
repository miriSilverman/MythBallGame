using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room : MonoBehaviour
{
    [SerializeField] private float rotationSpeed;

    private bool _dragging = false;

    public Rigidbody rb;
    
    [SerializeField] private float maxVelocity = 3f;
    void Start()
    {
        rb.maxAngularVelocity = maxVelocity;
        // stablizedVectors = new[]
        // {
        //     transform.forward, -transform.forward, transform.right, -transform.right, transform.up, -transform.up
        // };
        //rb.centerOfMass = transform.position;
    }
    void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
            _dragging = false;

        }   
    }

    private void OnMouseDrag()
    {
        _dragging = true;

    }

    private void FixedUpdate()
    {
        if (_dragging)
        {
            float x = Input.GetAxis("Mouse X") * rotationSpeed;
            float y = Input.GetAxis("Mouse Y") * rotationSpeed;

            if (Input.GetKey(KeyCode.LeftControl))
            {
                int sign = 1;
                var playerScreenPoint = Camera.main.WorldToScreenPoint(transform.position);
                if (Input.mousePosition.x < playerScreenPoint.x)
                {
                    sign = -1;
                }
                rb.AddTorque(Vector3.forward * (y * sign), ForceMode.Impulse);
            }

            else
            {
                rb.AddTorque(Vector3.down * x, ForceMode.Impulse);
                rb.AddTorque(Vector3.right * y, ForceMode.Impulse);
            }
        }
    }
}

