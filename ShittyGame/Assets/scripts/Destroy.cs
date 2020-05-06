using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy : MonoBehaviour
{
   public float timer;

    // Update is called once per frame
    void Update()
    {
        if (timer >0 )
        {
            timer--;
        }

        if (timer ==0)
        {
            Destroy(gameObject);
        }

    }
   


}
