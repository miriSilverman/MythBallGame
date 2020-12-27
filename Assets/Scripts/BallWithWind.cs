using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class BallWithWind : MonoBehaviour
{
    [SerializeField] private float speed = 10f;
    [SerializeField] private GameObject room;
    public Transform child;
    public Collider shutWhileFlying;
    void Update ()
    {
        child.transform.rotation = Quaternion.Euler (0.0f, 0.0f, gameObject.transform.rotation.z * -1.0f);
    }
    
    private Rigidbody _rb;
    private bool _inWindArea = false;
    private WindArea _windArea;
    
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
        
    }

    private void FixedUpdate()
    {
        if (_inWindArea)
        {
            _rb.AddForce(_windArea.direction * _windArea.strength);
        }
        //Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical"));
        
        //_rb.AddForce(movement*speed);
    }
    private void OnMouseDown()
    {
        room.transform.DORotate(new Vector3(0, 0, 90), 10f);

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("windArea"))
        {
            _inWindArea = true;
            _windArea = other.gameObject.GetComponent<WindArea>();
            shutWhileFlying.enabled = false;
        }
        
    }


    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("windArea"))
        {
            _inWindArea = false;
            shutWhileFlying.enabled = true;
        }
    }
}
