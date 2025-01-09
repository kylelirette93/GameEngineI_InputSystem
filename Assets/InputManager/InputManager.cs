using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour, GameInput.IGameplayActions
{
    public GameInput gameInput;

    void Start()
    {
        gameInput = new GameInput();
        gameInput.Gameplay.Enable();
        gameInput.Gameplay.SetCallbacks(this);
    }

    #region Public Actions

    private Action JumpEvent;
    private Action CrouchEvent;

    #endregion
    public void OnJump(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            JumpEvent?.Invoke();
        }
    }

    public void OnCrouch(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            CrouchEvent?.Invoke();
        }
    }
}
