using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public enum WeaponShootType
{
 
    AUTO,
    MANUAL
}

public class Shooting : MonoBehaviour
{
    public WeaponShootType shootType;

    RaycastHit hit;
    public Transform Muzzle;
    public LineRenderer laserLineRenderer;
    public GameObject ShootParticle;
    public GameObject OnHitParticle;
    float RayTimer;
    public float RayLifeTime = 0.2f;
    float effectsDisplayTime = 0.2f;
    public Text Ammotext;
    public Text AmmoCounttext;
    Animator Anim;
    AudioSource gunAudio;
    //   public AudioClip ShootSound;
    public AudioClip ReloadSound;

    public float DamagePerShoot;
    public int BulletsPerShot;
    public float delayBetweenShots;
    public float SpreadAngle;
    public float ShootingRange;
    public int AmmoPerShoot;
    public int MaxAmmo;
    public int AmmoCount;
    public int CurAmmoInClip;
    public int Clip;

    [SerializeField]
    float LastShot;
    [SerializeField]
    bool isfiring;


    Camera cum;


    public void DisableEffects()
    {
        laserLineRenderer.enabled = false;

    }
    void Awake()
    {


        Anim = GetComponent<Animator>();
        gunAudio = GetComponent<AudioSource>();

        CurAmmoInClip = Clip;
        AmmoCount = MaxAmmo;


    }

    private void Start()
    {
        Vector3[] initLaserPositions = new Vector3[2] { Vector3.zero, Vector3.zero };
        laserLineRenderer.SetPositions(initLaserPositions);
        Anim = GetComponent<Animator>();
        Anim.enabled = false;

    }

    void Update()
    {




        switch (shootType)
        {
            case WeaponShootType.MANUAL:
                ; break;

            case WeaponShootType.AUTO:
                if (isfiring)
                {

                    TryShoot();

                }
                break;


        }

        RayTimer += Time.deltaTime;
        if (RayTimer >= RayLifeTime * effectsDisplayTime)
        {
            DisableEffects();
        }
    }





    public bool TryShoot()
    {
        if (CurAmmoInClip != 0 && Time.time > LastShot + delayBetweenShots)
        {
            Shoot();

            return true;
        }
        return false;
    }


    public Vector3 GetFirigDirection()
    {
        cum = GetComponentInParent<Camera>();
        float Spread = Random.Range(0, SpreadAngle);
        Vector3 dir = (cum.transform.forward);
        // print(dir);
        dir = Quaternion.AngleAxis(Spread, cum.transform.right) * dir;
        // print(dir);
        dir = Quaternion.AngleAxis(Random.Range(0, 360), cum.transform.forward) * dir;
        // print(dir);
        return dir;
    }

    public void Shoot()
    {
        LastShot = Time.time;
        if (CurAmmoInClip >= AmmoPerShoot)
        {
            CurAmmoInClip -= AmmoPerShoot;
            Instantiate(OnHitParticle, Muzzle.position, Quaternion.identity);

            Anim.Play("Shooting");

            for (int i = 0; i < BulletsPerShot; i++)
            {
                Vector3 BulletLook = GetFirigDirection();



                laserLineRenderer.enabled = true;
                RayTimer = 0f;


                if (Physics.Raycast(cum.transform.position, BulletLook, out hit))
                {

                    //   print(hit.point);
                    GameObject Enemy = hit.collider.gameObject;
                    DamageSystem dmg = Enemy.GetComponent<DamageSystem>();
                    laserLineRenderer.SetPosition(0, Muzzle.position);
                    laserLineRenderer.SetPosition(1, hit.point);

                    Instantiate(OnHitParticle, hit.point, Quaternion.identity);

                    if (dmg != null)
                    {
                        dmg.TakeDamage(DamagePerShoot);
                    }
                   


                }
                else return;

            }

            //       if (ShootSound)
            //  {
            //    gunAudio.PlayOneShot(ShootSound);
            // }
        }

    }
    public void TryReload()
    {
        if (CurAmmoInClip != Clip && AmmoCount > 0)
        {
            Reload();
        }

    }

    public void Reload()
    {

        AmmoCount -= Clip;
        CurAmmoInClip = Clip;
        Anim.Play("Reload");
    }



    public void AmmoRestore(int AmmoFromPickUp)
    {
        if (AmmoCount != MaxAmmo)
        {
            AmmoCount += AmmoFromPickUp;
        }
    }

    public void Use()
    {
        switch (shootType)
        {
            case WeaponShootType.AUTO:
                isfiring = true;
                break;



            case WeaponShootType.MANUAL:
                TryShoot();
                break;
        }

    }

    public void Enduse()
    {
        switch (shootType)
        {
            case WeaponShootType.AUTO:
                isfiring = false;
                break;



            case WeaponShootType.MANUAL:
                break;
        }

    }

}

