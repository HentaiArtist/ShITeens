using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Particle : MonoBehaviour
{
    public GameObject player;
    public float createtimer;
    public GameObject CreateParticle;
    public GameObject[] ToCreate ;
    public GameObject[] ToSetActive;
    bool activated = false ;

   

    public void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject == player && !activated)
        {
            activated = true;
            foreach (GameObject go in ToCreate)
            {

                Instantiate(go, transform.position, Quaternion.identity);
                Instantiate(CreateParticle, go.transform.position, Quaternion.identity);
            }
            foreach (GameObject go in ToSetActive){

                go.SetActive(true);
                Instantiate(CreateParticle, go.transform.position, Quaternion.identity);
            }
        }
    }
}
