using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portals : MonoBehaviour
{
    [SerializeField] private Collider portal1;
    [SerializeField] private Collider portal2;
    private void OnCollisionEnter(Collision other)
    {
        foreach (ContactPoint contact in other.contacts)
        {
            
            
            if (contact.thisCollider.Equals(portal1) && contact.otherCollider.CompareTag("Ball"))
            {
                Vector3 pos = portal2.transform.up;
                GameObject Ball = Instantiate(Resources.Load("Prefabs/Ball")) as GameObject;
                
                
                Ball.transform.position = portal2.transform.position;
                Rigidbody oldRb = contact.otherCollider.GetComponent<Rigidbody>();
                Rigidbody rb = Ball.GetComponent<Rigidbody>();
                rb = oldRb;
                rb.velocity = pos * oldRb.velocity.magnitude;
                GameObject oldBall = contact.otherCollider.gameObject;
                Destroy(oldBall);
            }
            
            

        }

    }
    
    
    
}
