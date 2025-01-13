using System;


public static class Actions
{
    // Handle jump and crouch actions.
    public static Action onJumpStarted;
    public static Action onJumpPerformed;
    public static Action onJumpCanceled;
    public static Action onCrouchStarted;
    public static Action onCrouchPerformed;
    public static Action onCrouchCanceled;

    // Handle shooting actions.
    public static Action onShootStarted;
    public static Action onShootPerformed;
    public static Action onShootCanceled;

    // Handle camera actions.
    public static Action onZoomStarted;
    public static Action onZoomPerformed;
    public static Action onZoomCanceled;
}