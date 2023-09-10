using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    // Character Controller
    [SerializeField]
    private CharacterController characterController;
    public float speed;

    public float turnSmoothTime = 0.1f;
    float turnSmoothVelocity;

    // Transform Camera Position
    [SerializeField] 
    private Transform cameraTransform;

    // Update is called once per frame
    void Update()
    {
        // Movement Character
        // Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        // characterController.Move(move * Time.deltaTime * speed);

        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        Vector3 move = new Vector3(horizontal, 0f, vertical).normalized;

        if (move.magnitude >= 0.1f) {

            float targetAngle = Mathf.Atan2(move.x, move.z) * Mathf.Rad2Deg + cameraTransform.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, targetAngle, 0f);

            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            characterController.Move(moveDir.normalized * speed * Time.deltaTime);
        }
        // move = Quaternion.AngleAxis(cameraTransform.rotation.eulerAngles.y, Vector3.up) * move;
    }

    // Lock Cursor Ketika Aplikasi di Run
    private void OnApplicationFocus(bool focusStatus) {
        if (focusStatus) {
            Cursor.lockState = CursorLockMode.Locked;
        }
        else {
            Cursor.lockState = CursorLockMode.None;
        }
    }

    
}
