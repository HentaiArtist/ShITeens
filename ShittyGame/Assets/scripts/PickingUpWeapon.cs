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
            Item PickeUpItem = pickup.GetComponent<Item>();
            ;   
            
            if (PickeUpItem != null)
            {               
               
                pickup.transform.parent = HandsSlot.transform;
                pickup.transform.localPosition = Vector3.zero;          
                pickup.transform.localRotation = Quaternion.identity;
                                                            
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
