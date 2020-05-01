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
    public float AmmoPerShoot;
    //public float currentCharge { get; private set; }
    //LevelingUp lvl;



    // ParticleSystem gunParticles;
  //  AudioSource gunAudio;
    //Light gunLight;
//float effectsDisplayTime = 0.2f;
 //   public AudioClip ShootSound;
    public float ShootingRange;
    //  public AudioClip ReloadSound;
    // Animator Anim;
  //  public float AmmoCount;
    public float CurAmmo;
   // public float Clip;
    //   public Text Ammotext;
    //  public Text AmmoCounttext;
    public Transform Gunslot;
    public Transform ProjectileSpawn;
    //   public int MaxAmmo;
    public float delayBetweenShots;
  //  public float BulletSpeed;
    //  public float ReloadSpeed;

    public float SpreadAngle;

    void Awake()
    {

      //  lvl = GetComponentInParent<LevelingUp>();
        // gunParticles = GetComponent<ParticleSystem>();
        //   Anim = GetComponent<Animator>();
       // gunAudio = GetComponent<AudioSource>();
       // gunLight = GetComponent<Light>();
        CurAmmo = 0;
        //  AmmoCount = MaxAmmo;
    }

    private void Start()
    {
        Vector3[] initLaserPositions = new Vector3[2] { Vector3.zero, Vector3.zero };
        laserLineRenderer.SetPositions(initLaserPositions);
      //  laserLineRenderer.SetWidth(laserWidth, laserWidth);
    }

    void Update()
    {

        // if(transform.position == Gunslot.position)
        // CurAmmo = lvl.CurXP;

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


                /*  case WeaponShootType.CHARGE:
                      ChargeDuration += Time.deltaTime;
                      break;

              }
            /*  if (transform.position == Gunslot.position) {
                  Ammotext.text = CurAmmo.ToString();
                  AmmoCounttext.text = AmmoCount.ToString();
              }*/
        }
    }

    public void DisableEffects()
    {

       // gunLight.enabled = false;
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
        float Spread = Random.Range(0, SpreadAngle);
        Vector3 dir = (Camera.main.transform.forward);
        // print(dir);
        dir = Quaternion.AngleAxis(Spread, Camera.main.transform.right) * dir;
        // print(dir);
        dir = Quaternion.AngleAxis(Random.Range(0, 360), Camera.main.transform.forward) * dir;
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
               RaycastHit hit;
                //Ray ray = new Ray();

                laserLineRenderer.enabled = true;

              if(Physics.Raycast(Camera.main.transform.position, BulletLook ,out hit ))
                {
                   
                //   print(hit.point);
                    GameObject Enemy = hit.collider.gameObject;
                    DamageSystem dmg = Enemy.GetComponent<DamageSystem>();
                   
                  //  Instantiate(OnHitParticle, hit.point, Quaternion.identity);
                      //  Instantiate(OnHitParticle, ProjectileSpawn.position, Quaternion.identity);

                    if (dmg != null)
                    {

                        dmg.TakeDamage(DamagePerShoot);
                       


                    }
                    else return;

                }
               laserLineRenderer.SetPosition(0, ProjectileSpawn.position);
               laserLineRenderer.SetPosition(1, hit.point);              
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
 void Skryto(){ /*  public void TryReload()
    {
        if (CurAmmo != Clip && AmmoCount > 0 && Time.time > LastReload + ReloadSpeed)
        {
            Reload();
        }

    }
    
   public void Reload() { 
        if (CurAmmo != Clip && AmmoCount > 0 && Time.time > LastReload + ReloadSpeed)
        {
            AmmoCount -= Clip;
            CurAmmo = Clip;
           
        }  
           LastReload = Time.time;
       
    }
    */}


    public void AmmoRestore(float AmmoFromPickUp)
    { 
            CurAmmo += AmmoFromPickUp;
    
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

