using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickingUpWeapon : MonoBehaviour
{

 //   public AudioSource FailAudio;
    public Transform HandsSlot;
    public float PickingDistance = 10;
      void Update()
    {
               
    }

 

    public GameObject PickItem()
    {

        //Vector3 forward = Camera.main.transform.position;

        RaycastHit hit;
        GameObject Ytem;

        if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, 1<<8))
        {
            Ytem = hit.collider.gameObject;




            Item ii = Ytem.GetComponent<Item>();
           // Rigidbody Rbg = Ytem.GetComponent<Rigidbody>();


            if (ii != null)
            {
               // Rbg.isKinematic = true;
                //Rbg.useGravity = false;
                Ytem.transform.parent = HandsSlot.transform;
                Ytem.transform.localPosition = Vector3.zero;
                Ytem.transform.localRotation = Quaternion.identity;
             
                return Ytem;
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
