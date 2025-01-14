using UnityEngine;
using UnityEngine.InputSystem;

public class Floor : MonoBehaviour
{
    // obtaining component references
    private Material _material;
    private void Start() {
        _material = GetComponent<Renderer>().material;
    }
    
    // subscribing / unsubscribing to action events
    private void OnEnable() {
        InputActions.OnInteract += RedFloor;
        InputActions.OnJump += GreenFloor;
        InputActions.OnCrouchStarted += BlueFloor;
    }
    private void OnDisable() {
        InputActions.OnInteract -= RedFloor;
        InputActions.OnJump -= GreenFloor;
        InputActions.OnCrouchStarted -= BlueFloor;
    }

    // methods called when action events are heard
    private void RedFloor(InputAction.CallbackContext context) { _material.color = Color.red; }
    private void GreenFloor(InputAction.CallbackContext context) { _material.color = Color.green; }
    private void BlueFloor() { _material.color = Color.blue; }
}
