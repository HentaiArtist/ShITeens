using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public enum WeaponShootType
{
 //   CHARGE,
    AUTO,
    MANUAL
}

public class Shooting : MonoBehaviour
{
    RaycastHit hit;
    public LineRenderer laserLineRenderer;
    public GameObject ShootParticle;
    public GameObject OnHitParticle;
    public float DamagePerShoot;
    // public float recoilForce;

    //public Camera Cum;
    // public float AimPower;
    public bool isfiring;
    //   public bool isCharging;
    //  public float ChargeDuration;
    //  public float AmmoUsedInCharge;
    //  public float AmmoNeededToStartCharge;
    //public bool IsCharge;
    //  public float LastReload;
    public float LastShot;
    // public GameObject Projectile;
    public int BulletsPerShot;
    public WeaponShootType shootType;
    public int AmmoPerShoot;
    //public float currentCharge { get; private set; }
    //LevelingUp lvl;


    float timer;
    public float RayLifeTime = 0.2f;
    // ParticleSystem gunParticles;
    AudioSource gunAudio;
    //Light gunLight;
    float effectsDisplayTime = 0.2f;
    //   public AudioClip ShootSound;
    public float ShootingRange;
    public AudioClip ReloadSound;
    Animator Anim;
    public int AmmoCount;
    public int CurAmmo;
    public int Clip;
    public Text Ammotext;
    public Text AmmoCounttext;
    public Transform Gunslot;
    public Transform ProjectileSpawn;
    public int MaxAmmo;
    public float delayBetweenShots;
    //  public float BulletSpeed;
    //  public float ReloadSpeed;
    Camera cum;
    public float SpreadAngle;

    public void DisableEffects()
    {
        laserLineRenderer.enabled = false;
       // gunLight.enabled = false;
    }
    void Awake()
    {

        //  lvl = GetComponentInParent<LevelingUp>();
        // gunParticles = GetComponent<ParticleSystem>();
        Anim = GetComponent<Animator>();
        gunAudio = GetComponent<AudioSource>();
        // gunLight = GetComponent<Light>();
        CurAmmo = Clip;
        AmmoCount = MaxAmmo;


    }

    private void Start()
    {
        Vector3[] initLaserPositions = new Vector3[2] { Vector3.zero, Vector3.zero };
        laserLineRenderer.SetPositions(initLaserPositions);
        //  laserLineRenderer.SetWidth(laserWidth, laserWidth);
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
                    //LastShot += Time.deltaTime;
                    //  if (LastShot > delayBetweenShots)
                    //  {
                    TryShoot();
                    //   }
                }
                break;
                //  if (transform.position == Gunslot.position)
                //  {
                //    Ammotext.text = CurAmmo.ToString();
                //    AmmoCounttext.text = AmmoCount.ToString();
                //  }
                /*  case WeaponShootType.CHARGE:
                      ChargeDuration += Time.deltaTime;
                      break;

              }
            
              }*/
       // }
             
        }  
        
        timer += Time.deltaTime;
                if (timer >= RayLifeTime * effectsDisplayTime)
                {
                    DisableEffects();
                }
    }





    public bool TryShoot()
    {
        if (CurAmmo != 0 && Time.time > LastShot + delayBetweenShots)
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
        if (CurAmmo >= AmmoPerShoot)
        {
            CurAmmo -= AmmoPerShoot;

            // bool ShtAnimParam = true;
            //  Anim.Play("Shooting");
            // Anim.SetBool("IsShooting", ShtAnimParam);

            //ShtAnimParam = true;

            // if(ShtAnimParam == true)
            for (int i = 0; i < BulletsPerShot; i++)
            {
                Vector3 BulletLook = GetFirigDirection();
               
                //Ray ray = new Ray();

                laserLineRenderer.enabled = true;
                timer = 0f;


                if (Physics.Raycast(cum.transform.position, BulletLook, out hit))
                {

                    //   print(hit.point);
                    GameObject Enemy = hit.collider.gameObject;
                    DamageSystem dmg = Enemy.GetComponent<DamageSystem>();
                    laserLineRenderer.SetPosition(0, ProjectileSpawn.position);
                    laserLineRenderer.SetPosition(1, hit.point);

                    Instantiate(OnHitParticle, hit.point, Quaternion.identity);
                    Instantiate(OnHitParticle, ProjectileSpawn.position, Quaternion.identity);
                   // laserLineRenderer.enabled = false;
                    if (dmg != null)
                    {
                        dmg.TakeDamage(DamagePerShoot);
                    }
                    else return;


                }

                /*  GameObject go = Instantiate(Projectile, ProjectileSpawn.position, Quaternion.LookRotation(BulletLook));
                  Rigidbody rb = go.GetComponent<Rigidbody>();
                  rb.velocity = BulletLook * BulletSpeed;
                  */
            }

            LastShot = Time.time;

            //       if (ShootSound)
            //  {
            //    gunAudio.PlayOneShot(ShootSound);
            // }
        }
    }
    public void TryReload()
    {
        if (CurAmmo != Clip && AmmoCount > 0)
        {
            Reload();
        }

    }

    public void Reload()
    {       
        
            AmmoCount -= Clip;
            CurAmmo = Clip;      
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

            /* case WeaponShootType.CHARGE:
                 ChargeDuration = 0;
                 break;*/

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

            /* case WeaponShootType.CHARGE:
                 // TODO: Shoot charges
                 ChargeDuration = 0;
                 break;*/

            case WeaponShootType.MANUAL:
                break;
        }

    }

}

