using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour //автор тов. Сергей Иевлев
{
    enum EnemyState
    {
        Staying,
        Chasing,
        Attacking
    }
    private EnemyState state = EnemyState.Staying;

    private NavMeshAgent agent;
    private GameObject player;

    [Header("Navigation Properties")]
    [SerializeField]
    private string playerTag;
    [SerializeField]
    private float visionDistance;
    [SerializeField]
    private float attackDistance;

    [Header("Attack properties")]
    [SerializeField]
    private float reloadTime;
    private float currentReloadTime;
    [SerializeField]
    private float timeBeforeAttack;
    [SerializeField]
    private float damage;

    [Header("Animation Properties")]
    [SerializeField]
    private string movingParameterName;
    [SerializeField]
    private string attackingParameterName;
    private Animator anim;
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.isStopped = true;
        player = GameObject.FindGameObjectWithTag(playerTag);
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateState();
        Act();
        Reload();
        Animate();
    }

    private void Reload()
    {
        if (currentReloadTime < reloadTime)
        {
            currentReloadTime += Time.deltaTime;
        }
    }

    void UpdateState()
    {
        float dst = Vector3.Distance(transform.position, player.transform.position);
        if (dst > attackDistance && dst < visionDistance)
        {
            state = EnemyState.Chasing;
        }
        if (dst < attackDistance)
        {
            state = EnemyState.Attacking;
        }
        if (dst > visionDistance)
        {
            state = EnemyState.Staying;
        }
    }
    void Act()
    {
        if (state == EnemyState.Chasing && agent.isStopped)
        {
            agent.isStopped = false;
            agent.SetDestination(player.transform.position);
        }
        else
        {
            agent.isStopped = true;
        }
        if (state == EnemyState.Attacking)
        {
            Attack();
        }
    }

    private void Attack()
    {
        if (currentReloadTime > reloadTime)
        {
            Invoke("DamagePlayer", timeBeforeAttack);
            currentReloadTime = 0;
        }
    }

    private void DamagePlayer()
    {
        if (Vector3.Distance(transform.position, player.transform.position) <= attackDistance)
        {
            player.GetComponent<DamageSystem>().TakeDamage(damage);
        }
    }

    void Animate()
    {
        if (state == EnemyState.Chasing)
        {
            anim.SetBool(movingParameterName, true);
            anim.SetBool(attackingParameterName, false);
        }
        if (state == EnemyState.Staying)
        {
            anim.SetBool(movingParameterName, false);
            anim.SetBool(attackingParameterName, false);
        }
        if (state == EnemyState.Attacking)
        {
            anim.SetBool(movingParameterName, false);
            anim.SetBool(attackingParameterName, true);
        }
    }
}