using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonCamera : MonoBehaviour
{
    public Camera cam;
    private Vector3 rotation = Vector3.zero;
    private float cameraRotationX = 0f;
    private float currentCameraRotationX = 0f;
    public float cameraRotationLimit;
    public float lookSensitivity;
    public float SensMultiplier;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }
    private void FixedUpdate()
    {
        PerformRotation();
    }
    public void Rotate(Vector3 _rotation)
    {
        rotation = _rotation;
    }
    private void Update()
    {
        float _yRot = Input.GetAxisRaw("Mouse X");

        Vector3 _rotation = new Vector3(0f, _yRot, 0f) * lookSensitivity * SensMultiplier;
        Rotate(_rotation);
        float _xRot = Input.GetAxisRaw("Mouse Y");
        float _cameraRotationX = _xRot * lookSensitivity * SensMultiplier;

        RotateCamera(_cameraRotationX);
    }

    void PerformRotation()
    {
        Rigidbody rb = GetComponentInParent<Rigidbody>();
        rb.MoveRotation(rb.rotation * Quaternion.Euler(rotation));
        if (cam != null)
        {

            currentCameraRotationX -= cameraRotationX;
            currentCameraRotationX = Mathf.Clamp(currentCameraRotationX, -cameraRotationLimit, cameraRotationLimit);

            cam.transform.localEulerAngles = new Vector3(currentCameraRotationX, 0f, 0f);
        }
    }
    public void RotateCamera(float _cameraRotationX)
    {
        cameraRotationX = _cameraRotationX;
    }
}


