using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField]
    private float speed;
    [SerializeField]
    private float flyDistance;
    [SerializeField]
    private float damage;
    void Update()
    {
        float frameDistance = speed * Time.deltaTime;
        flyDistance -= frameDistance;
        if (flyDistance > 0)
        {
            transform.Translate(Vector3.forward * frameDistance);
        }
        else
        {
            SelfDestruct();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        DamageSystem ds = collision.gameObject.GetComponent<DamageSystem>();
        if (ds != null)
        {
            ds.TakeDamage(damage);
        }
        SelfDestruct();
    }

    private void SelfDestruct()
    {
        Destroy(gameObject);
    }
}
