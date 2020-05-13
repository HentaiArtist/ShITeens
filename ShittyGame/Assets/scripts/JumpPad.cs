using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpPad : MonoBehaviour
{ public float JamPower;
    public float RigidbodyLifetime;
    private void OnTriggerEnter(Collider other)
       
    {
        Rigidbody rb = other.GetComponent<Rigidbody>();
      
        if (rb != null)
        {
            rb.AddForce(transform.up * JamPower);
        }
     /*   else
        {
            pl.AddComponent<Rigidbody>();
            

            

           
        }*/
    }


  
   
}
