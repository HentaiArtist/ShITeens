using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum MovementState
    {
        Jumping,
        Walking,
        Sprinting,
        Idle
        //   Crouching,
        //  Sliding
    }
public class ThirdPersonMovement : MonoBehaviour
{



    float MouseX, MouseY;
   // public int AmountOjumps;
  //  int JumpCounter;
    public LayerMask whatIsGround;
    Rigidbody rb;
    public float jumpForce;
    public float WalkSpeed;
    public KeyCode JumpButton;
    public MovementState CurMovement;
    public float CurSpeed;
    public float SprintMultiplier;
   
    bool ReadyToJump;
   // Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        StartWalk();
        Cursor.lockState = CursorLockMode.Locked;
     //   animator = GetComponent<Animator>();

    }

    void StartWalk()
    {
      //  animator.SetBool("Walking", true);
     //   animator.SetBool("Jump", true);
        CurMovement = MovementState.Walking;
        CurSpeed = WalkSpeed;
        ReadyToJump = true;
       // JumpCounter = 0;

    }

    public void INputs()
    {
        if (Input.GetKeyDown(JumpButton) && ReadyToJump)
        {
            StartJump();
        }


        if (Input.GetKey(KeyCode.LeftShift))
        {
            CurSpeed = WalkSpeed * SprintMultiplier;
        }

        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            CurSpeed = WalkSpeed;
        }

    }



    public void StartJump()
    {

        // animator.SetBool("Jump", true);
      
            rb.AddForce(Vector3.up * jumpForce);
            CurMovement = MovementState.Jumping;
            ReadyToJump = false;
            
        }



    
    // Update is called once per frame
    void Update()
    {


        INputs();

        switch (CurMovement)
        {
            case MovementState.Walking:
            case MovementState.Sprinting:
                MovementOnGround();
                break;



            case MovementState.Jumping:
                WhileJumping();
                break;

            default:
                Debug.LogError("В ходьбе произошла ошибка с енамом ");
                break;

        }

    }

    public void MovementOnGround()
    {

        float hor = Input.GetAxis("Horizontal");
        float ver = Input.GetAxis("Vertical");
        Vector3 PlayerMov = new Vector3(hor, 0, ver) * CurSpeed * Time.deltaTime;
       // print($"{hor} {ver} {CurSpeed}");
        transform.Translate(PlayerMov, Space.Self);


    }

    public void WhileJumping()
    {

        // animator.SetBool("Walkig", false);
        ReadyToJump = false;
        /*   if (rb.velocity.y < 0)
           {
               RaycastHit hit;
               Ray ray = new Ray(transform.position - Vector3.up, Vector3.down);
               if (Physics.Raycast(ray, out hit, 0.2f))
               {
                   StartWalk();
               }
           }*/
    }

    private void OnCollisionStay(Collision other)
    {
        //Make sure we are only checking for walkable layers
        int layer = other.gameObject.layer;
        if (whatIsGround != (whatIsGround | (1 << layer))) return;
        {
            StartWalk();
        }
        //Iterate through every collision in a physics update
    }
}
        




    





