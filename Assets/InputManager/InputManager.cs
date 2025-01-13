using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour, GameInput.IGameplayActions
{
    public GameInput gameInput;
    public GameObject player;

    void Start()
    {
        // Create a new instance of Game Input class.
        gameInput = new GameInput();
        // Enable the gameplay action map.
        gameInput.Gameplay.Enable();
        // Set the callbacks for the gameplay action map.
        gameInput.Gameplay.SetCallbacks(this);
    }

    
    public void OnJump(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            // Invoke the jump started event.
            Actions.onJumpStarted?.Invoke();
        }
        if (context.performed)
        {
            // Invoke the jump performed event.
            Actions.onJumpPerformed?.Invoke();
        }
        if (context.canceled)
        {
            // Invoke the jump canceled event.
            Actions.onJumpCanceled?.Invoke();
        }
    }

    public void OnCrouch(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            // Invoke the crouch started event.
            Actions.onCrouchStarted?.Invoke();
        }
        if (context.performed)
        {
            // Invoke the crouch performed event.
            Actions.onCrouchPerformed?.Invoke();
        }
        if (context.canceled)
        {
            // Invoke the crouch canceled event.
            Actions.onCrouchCanceled?.Invoke();
        }
    }

    public void OnShoot(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            // Invoke the shoot started event.
            Actions.onShootStarted?.Invoke();
        }
        if (context.performed)
        {
            // Invoke the shoot performed event.
            Actions.onShootPerformed?.Invoke();
        }
        if (context.canceled)
        {
            // Invoke the shoot canceled event.
            Actions.onShootCanceled?.Invoke();
        }
    }

    public void OnZoom(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            // Invoke the zoom started event.   
            Actions.onZoomStarted?.Invoke();
        }
        if (context.performed)
        {
            // Invoke the zoom performed event.
            Actions.onZoomPerformed?.Invoke();
        }
        if (context.canceled)
        {
            // invoke the zoom canceled event.
            Actions.onZoomCanceled?.Invoke();
        }
    }

    
}
