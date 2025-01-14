using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputActions : MonoBehaviour
{
    // class holding all the input actions to be called
    public static Action<InputAction.CallbackContext> OnJump;
    public static Action<InputAction.CallbackContext> OnInteract;
    public static Action OnCrouchStarted;
    public static Action OnCrouchPerformed;
    public static Action OnCrouchCanceled;
}
