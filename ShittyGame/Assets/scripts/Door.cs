using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.HDPipeline;

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
            animator.Play("Open");
            Invoke("Close", 2f);

        }
    }

   void Close ()
    {
        animator.Play("Close");
    }
}