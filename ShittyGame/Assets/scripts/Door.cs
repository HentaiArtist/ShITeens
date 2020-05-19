using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
   // public GameObject player;
    Animator animator;
    [SerializeField]
    bool closed;

    private void Start()
    {
        animator = GetComponentInParent<Animator>();
        closed = true;
    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (closed)
            {
                animator.Play("Open");
                closed = false;
            }

            if (!closed)
            {
                animator.Play("Close");
                closed = true;
            }
        }
    }

    private void Update()
    {
        
    }
}