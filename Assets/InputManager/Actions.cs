using System;


public static class Actions
{
    // Handles the player input.
    public static Action onJumpStarted;
    public static Action onJumpPerformed;
    public static Action onJumpCanceled;
    public static Action onCrouchStarted;
    public static Action onCrouchPerformed;
    public static Action onCrouchCanceled;

    // Handle shooting input.
    public static Action onShootStarted;
    public static Action onShootPerformed;
    public static Action onShootCanceled;
}