using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour, GameInput.IGameplayActions
{
    public GameInput gameInput;
    public GameObject player;

   
    

    void Start()
    {
        gameInput = new GameInput();
        gameInput.Gameplay.Enable();
        gameInput.Gameplay.SetCallbacks(this);
    }

    
    public void OnJump(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            Actions.onJumpStarted?.Invoke();
        }
        if (context.performed)
        {
            Actions.onJumpPerformed?.Invoke();
        }
        if (context.canceled)
        {
            Actions.onJumpCanceled?.Invoke();
        }
    }

    public void OnCrouch(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            Actions.onCrouchStarted?.Invoke();
        }
        if (context.performed)
        {
            Actions.onCrouchPerformed?.Invoke();
        }
        if (context.canceled)
        {
            Actions.onCrouchCanceled?.Invoke();
        }
    }

    public void OnShoot(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            Actions.onShootStarted?.Invoke();
        }
        if (context.performed)
        {
            Actions.onShootPerformed?.Invoke();
        }
        if (context.canceled)
        {
            Actions.onShootCanceled?.Invoke();
        }
    }

    
}
