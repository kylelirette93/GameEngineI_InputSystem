using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Rigidbody rb;
    float jumpForce = 200f;
    Vector3 originalScale;
    Vector3 movementVector;
    bool canJump = true;
   void OnEnable()
    {
        Actions.onJumpStarted += StartJump;
        Actions.onJumpPerformed += JumpHeld;
        Actions.onJumpCanceled += JumpReleased;
        Actions.onCrouchStarted += StartCrouch;
        Actions.onCrouchPerformed += CrouchHeld;
        Actions.onCrouchCanceled += CrouchReleased;
}

    private void OnDisable()
    {
        Actions.onJumpStarted -= StartJump;
        Actions.onJumpPerformed -= JumpHeld;
        Actions.onJumpCanceled -= JumpReleased;
        Actions.onCrouchStarted -= StartCrouch;
        Actions.onCrouchPerformed -= CrouchHeld;
        Actions.onCrouchCanceled -= CrouchReleased;
    }

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        originalScale = transform.localScale;
    }

  

    void StartJump()
    {
        Debug.Log("Jump has started");
        rb.AddForce(0, jumpForce, 0);
    }

    void JumpHeld()
    {
        Debug.Log("Jump is being performed.");
    }

    void JumpReleased()
    {
        Debug.Log("Jump has been cancelled");
    }

    void StartCrouch()
    {
        Debug.Log("Crouch has started.");
        transform.localScale = (transform.localScale / 2);
    }

    void CrouchHeld()
    {
        Debug.Log("Crouch is being performed.");
    }

    void CrouchReleased()
    {
        Debug.Log("Crouch is being canceled");
        transform.localScale = originalScale;
    }

   
}
