using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonCamera : MonoBehaviour
{
    public float RotationSpeed = 1;
    public Transform Target, Player ,Slot;
    float MouseX, MouseY;
  
    void Start()
    {
      //  Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }
    private void LateUpdate()
    {
        CumControll();
    }

    void CumControll() {
        MouseX += Input.GetAxis("Mouse X") * RotationSpeed;
        MouseY -= Input.GetAxis("Mouse Y") * RotationSpeed;
        MouseY = Mathf.Clamp(MouseY,-50,30);
       var MouseYPos = Mathf.Clamp(MouseY, -3, 3);
        transform.LookAt(Target);
        Target.rotation = Quaternion.Euler(MouseY, MouseX, 0);
       // Target.position = new Vector3(MouseX, MouseY, 0);
        Player.rotation = Quaternion.Euler(0, MouseX, 0);
        Slot.rotation = Quaternion.Euler(MouseY, MouseX, 0);
    }


}
