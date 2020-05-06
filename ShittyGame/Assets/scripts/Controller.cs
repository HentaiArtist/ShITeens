using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    float LvlUiCounter;
  
   
    public KeyCode LvlUi;
     public KeyCode ReloadKey;
    public KeyCode ItemChangeKey;
    public KeyCode PickItemKey;
    //public Transform Hands;
    Inventory inventory;
  public  bool opened;
    PickingUpWeapon handsscript;
    DamageSystem Dsystem;
    Rigidbody rb;
    Animator animator;
    public GameObject LvlUpWindow;
   /// ThirdPersonCamera cum;
  //  Vector3 Movement;
  //  public Transform player;
  //public Camera cum;
  // Start is called before the first frame update
    private void Awake()
    {

        handsscript = GetComponent<PickingUpWeapon>();
        opened = true;
        Dsystem = GetComponent<DamageSystem>();
        inventory = GetComponent<Inventory>();
        // anim = GetComponent<Animator>();

    }

    void Start()
    {
         //   cum = GetComponentInChildren<ThirdPersonCamera>();
        rb = GetComponent<Rigidbody>();

    }

    // Update is called once per frame
    void Update()
    {
   /*    Movement.x = Input.GetAxisRaw("Horizontal");
        Movement.z = Input.GetAxisRaw("Vertical");
      */  
        if (Input.GetKeyDown(PickItemKey))
        {
            GameObject go = handsscript.PickItem();
            inventory.Add(go);
        }

        if (Input.GetKeyDown(ReloadKey))
        {
            inventory.Reload();
        }

        ///   rb.AddForce(normalVector * jumpForce * 0.5f);


        if (Input.GetMouseButtonDown(0))// && opened == true)
        {
            inventory.Use();
        }

        if (Input.GetMouseButtonUp(0)) //&& opened == true)
        {
            inventory.Enduse();
        }



        if (Input.GetKeyDown(ItemChangeKey))

        {
            inventory.ChangeItem();
        }

      /*  if (Input.GetKeyDown(LvlUi))

        {
            Time.timeScale = 0.1f;
           gameObject.GetComponent<ThirdPersonMovement>().enabled = false;
            LvlUpWindow.SetActive(true);
            LvlUiCounter++;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            opened = false;
            //   inventory.enabled = false;
            cum.enabled = false;
            if (LvlUiCounter == 2)
            {
                gameObject.GetComponent<ThirdPersonMovement>().enabled = true;
                Time.timeScale = 1;
                LvlUpWindow.SetActive(false);
                LvlUiCounter = 0;
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
                opened = true;
              
                cum.enabled = true;
                //inventory.enabled = true;

            }
           
    
            
        }*/

        /*  if (Input.GetMouseButton(1))
          {
              anim.SetBool("IsAiming", true);

          }

          if (Input.GetMouseButtonUp(1))
          {
              anim.SetBool("IsAiming", false);
          }

      */



        //   cum.transform.position = player.transform.position;

    }





    private void FixedUpdate()
    {
       // rb.MovePosition(rb.position + Movement * Step * Time.fixedDeltaTime);
    }


}
