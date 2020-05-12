using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Particle : MonoBehaviour
{
    public GameObject player;
    public GameObject explosion;
    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject == player)
        {
            Instantiate(explosion, transform.position, Quaternion.identity);
        }
    }
}
