using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    private Transform _transform;
    private Rigidbody _rb;
    
    private void Start() 
    {
        _transform = GetComponent<Transform>();
        _rb = GetComponent<Rigidbody>();
        _rb.constraints = RigidbodyConstraints.FreezeRotation;
    }
    
    private void Jump(InputAction.CallbackContext context)
    {
        if (context.started) _rb.AddForce(Vector3.up * 200f);
    }
    private void Spin(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            _rb.AddForce(Vector3.up * 200f);
            _transform.localRotation *= Quaternion.Euler(0f, 0f, 90f);
        }
        if (context.performed)_transform.localRotation *= Quaternion.Euler(0f, 0f, -90f);
       
        
    }
    private void CrouchStarted()
    {
        _transform.localScale = new Vector3(1, 0.8f, 1);
    }
    private void CrouchCanceled()
    {
        _transform.localScale = new Vector3(1f, 1f, 1f);
    }
    
    private void OnEnable() {
        InputActions.OnInteract += Spin;
        InputActions.OnJump += Jump;
        InputActions.OnCrouchStarted += CrouchStarted;
        InputActions.OnCrouchCanceled += CrouchCanceled;
    }
    private void OnDisable() {
        InputActions.OnInteract -= Spin;
        InputActions.OnJump -= Jump;
        InputActions.OnCrouchStarted -= CrouchStarted;
        InputActions.OnCrouchCanceled -= CrouchCanceled;
    }
}
