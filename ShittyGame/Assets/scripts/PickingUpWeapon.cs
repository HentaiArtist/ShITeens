using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickingUpWeapon : MonoBehaviour
{

 //   public AudioSource FailAudio;
    public Transform HandsSlot;
    public float PickingDistance = 10;
    
     public  Camera cam;
      void Update()
    {
               
    }

 

    public GameObject PickItem()
    {

        //Vector3 forward = Camera.main.transform.position;

        RaycastHit hit;
        GameObject pickup;
      //  GameObject Ytem;
        

        if (Physics.Raycast(cam.transform.position,cam.transform.forward, out hit, 1<<8))
        {
            pickup = hit.collider.gameObject;
            Item PickeUpCompoet = pickup.GetComponent<Item>();
            ;   
            
            if (PickeUpCompoet != null)
            {
           
                pickup.transform.parent = HandsSlot.transform;
                pickup.transform.localPosition = Vector3.zero;          
               
                Animator animator = pickup.GetComponent<Animator>();
                animator.enabled = true;
                 Collider collider = pickup.GetComponent<Collider>();
                collider.enabled = false; 
                pickup.transform.rotation = new Quaternion(0, 0, 0, 0);
                pickup.transform.localRotation = new Quaternion(0, 0, 0, 0);


                return pickup;                                       

            
               
            }
            else
            {
              //  FailAudio.Play();
                return null;
            }
        }
        else
        {
           // FailAudio.Play();
            return null;
        }
    }
}
