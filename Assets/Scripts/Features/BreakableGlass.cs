using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakableGlass : MonoBehaviour
{
    public float forceThreshold;
    
    private void OnCollisionEnter(Collision other)
    {
        foreach (ContactPoint contact in other.contacts)
        {
            
            
            if (contact.thisCollider.name.Equals("Glass") || contact.thisCollider.CompareTag("Glass"))
            {
                GameController.Instance.GlassAudio();
                float collisionForce = other.impulse.magnitude / Time.fixedDeltaTime;
                Debug.Log(collisionForce);
                if (collisionForce > forceThreshold)
                {
                    contact.thisCollider.gameObject.SetActive(false);
                }
            }
            
            

        }

    }
}
