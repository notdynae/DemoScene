using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.PlayerLoop;

public class InputManager : MonoBehaviour, GameInput.IGameplayActions
{

    private GameInput _gameInput;
    private void Awake()
    {
        _gameInput = new GameInput();
        _gameInput.Gameplay.Enable();
        _gameInput.Gameplay.SetCallbacks(this);
    }

    public void OnJump(InputAction.CallbackContext context) { InputActions.OnJump?.Invoke(context); }
    public void OnInteract(InputAction.CallbackContext context) { InputActions.OnInteract?.Invoke(context); }
    public void OnCrouch(InputAction.CallbackContext context)
    {
        if (context.started) InputActions.OnCrouchStarted?.Invoke();
        if (context.performed) InputActions.OnCrouchPerformed?.Invoke();
        if (context.canceled) InputActions.OnCrouchCanceled?.Invoke();
    }
}
