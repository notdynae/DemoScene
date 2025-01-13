using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class TextListener : MonoBehaviour
{
    private TextMeshPro _text;
    private void Start() {
        _text = GetComponent<TextMeshPro>();
    }
    private void OnEnable() {
        InputActions.OnInteract += InteractText;
        InputActions.OnJump += JumpText;
        InputActions.OnCrouchStarted += CrouchStartedText;
        InputActions.OnCrouchPerformed += CrouchPerformedText;
        InputActions.OnCrouchCanceled += CrouchCanceledText;
    }
    private void OnDisable() {
        InputActions.OnInteract -= InteractText;
        InputActions.OnJump -= JumpText;
        InputActions.OnCrouchStarted -= CrouchStartedText;
        InputActions.OnCrouchPerformed -= CrouchPerformedText;
        InputActions.OnCrouchCanceled -= CrouchCanceledText;
    }

    private void InteractText(InputAction.CallbackContext context)
    {
        if (context.started) _text.text = $"Interact started!";
        if (context.performed) _text.text = $"Interact held!";
        if (context.canceled) _text.text = $"Interact canceled!";
    }
    private void JumpText(InputAction.CallbackContext context)
    {
        if (context.started) _text.text = $"Jump started!";
        if (context.performed) _text.text = $"Jump held!";
        if (context.canceled) _text.text = $"Jump canceled!";
    }
    
    private void CrouchStartedText() { _text.text = $"Crouch started!"; }
    private void CrouchPerformedText() { _text.text = $"Crouch held!"; }
    private void CrouchCanceledText() { _text.text = $"Crouch canceled!"; }

}
