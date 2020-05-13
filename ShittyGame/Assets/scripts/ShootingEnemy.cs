using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingEnemy : Enemy
{
    [Header ("Shooting properties")]
    [SerializeField]
    private GameObject bullet;
    [SerializeField]
    private Transform gunPoint;
    public override void DamagePlayer()
    {
        Instantiate(bullet, gunPoint.position, gunPoint.rotation);
    }
}
