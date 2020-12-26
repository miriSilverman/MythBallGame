using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;



public class Ball : MonoBehaviour
{
    private Rigidbody rb;
    [SerializeField] private float maxVelocity;
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.maxAngularVelocity = maxVelocity;
    }
}