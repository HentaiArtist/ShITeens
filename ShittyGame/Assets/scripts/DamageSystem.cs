using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class DamageSystem : MonoBehaviour
{

    // public string SceneName;
    public Text Hp;
    public float MaxHealth;
    public float CurHealth;
    public float sinkSpeed = 2.5f;
    // public int scoreValue = 10;
    // public AudioClip deathClip;
    // public int LootAmount;
    // public float score;

    // Animator Anim;
    // SphereCollider capsuleCollider;
    public bool isDead;
    bool isSinking;
    public GameObject Player;

    void Awake()
    {
        //Anim = GetComponent<Animator>();
        //Audio = GetComponent<AudioSource>();
        // hitParticles = GetComponentInChildren<ParticleSystem>();
        // capsuleCollider = GetComponent<SphereCollider>();
        CurHealth = MaxHealth;


        // inventory = GetComponent<Inventory>();
    }



    void Update()
    {



        if (isSinking)
        {
            transform.Translate(-Vector3.up * sinkSpeed * Time.deltaTime);

        }


        if (isDead)
            Die();

     //   Hp.text = CurHealth.ToString();
    }


    public void TakeDamage(float damage)
    {
        if (isDead)
            return;
        // Audio.Play();
        CurHealth -= damage;
        // hitParticles.Play();


        if (CurHealth <= 0)
        {
            isDead = true;
        }
    }

    public void HealthRestore(float Heal)
    {
        CurHealth += Heal;
        if (CurHealth > MaxHealth)
        {
            CurHealth = MaxHealth;
        }
    }

    public void TakeContactDamage(float ContactDamage)
    {

        if (isDead)
        return;
        // Audio.Play();
        CurHealth -= ContactDamage;
        if (CurHealth <= 0)
        {
            Death();
        }
    }

    void Death()

    {
        /*if (Player)
        {
            SceneManager.LoadScene(SceneName);
        }*/


        GetComponent<UnityEngine.AI.NavMeshAgent>().enabled = false;
        isDead = true;
        //  isSinking = true;
        //  Anim.Play("Die");

        //  Audio.clip = deathClip;
        // Audio.Play();
        // Die();

    }

    public void Die()
    {

        //if (!Player)
        //   score += scoreValue;

        Destroy(gameObject, 2f);
    }

    /*public void DropFood()
    {
        for (int i = 0; i == LootAmount; i++)
        {

        }

    }*/
}