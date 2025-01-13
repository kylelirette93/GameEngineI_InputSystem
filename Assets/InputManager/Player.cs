using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Rigidbody rb;
    float jumpForce = 10f;
    Vector3 originalScale;
    bool canJump = true;
    bool isShrinking = false;

   void OnEnable()
    {
        // Subscribe to jump and crouch input events.
        Actions.onJumpStarted += StartJump;
        Actions.onJumpPerformed += JumpHeld;
        Actions.onJumpCanceled += JumpReleased;
        Actions.onCrouchStarted += StartCrouch;
        Actions.onCrouchPerformed += CrouchHeld;
        Actions.onCrouchCanceled += CrouchReleased;
}

    private void OnDisable()
    {
        // Unsubscribe from jump and crouch input events.
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
        // Store the original scale of the player.
        originalScale = transform.localScale;
    }

  

    void StartJump()
    {
        Debug.Log("Jump has started");
        if (canJump)
        {
            // Add jump force to the player object.
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            // Prevent the player from jumping again until they land.
            canJump = false;
        }
    }

    void JumpHeld()
    {
        Debug.Log("Jump is being performed.");
        // Apply a continuous upward force.
        rb.AddForce(Vector3.up * (jumpForce * Time.deltaTime), ForceMode.Acceleration);
    }

    void JumpReleased()
    {
        Debug.Log("Jump has been cancelled");
        // Stop applying upward force if the player releases the jump button.
        if (rb.velocity.y > 0)
        {
            rb.velocity = new Vector3(rb.velocity.x, 0, rb.velocity.z);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        // Reset flag so player can jump if they landed.
        canJump = true;
    }

    void StartCrouch()
    {
        Debug.Log("Crouch has started.");
        // Shrink the player by half.
        transform.localScale = (transform.localScale / 2);
        isShrinking = true;
    }

    void CrouchHeld()
    {
        Debug.Log("Crouch is being performed.");
        if (isShrinking)
        {
            StartCoroutine(Shrink());
        }
    }

    private IEnumerator Shrink()
    {
        while (isShrinking)
        {
            // Shrink the player while button is held.
            transform.localScale -= new Vector3(0, 0.01f, 0);
            yield return new WaitForSeconds(0.1f);
        }
    }

    void CrouchReleased()
    {
        Debug.Log("Crouch is being canceled");
        // Stop shrinking, reset player scale.
        isShrinking = false;
        transform.localScale = originalScale;
    }

   
}
