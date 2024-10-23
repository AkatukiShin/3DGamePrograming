using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float walkSpeed = 30;
    [SerializeField] float dashSpeed = 50;
    [SerializeField] float jumpPower = 30;

    private Rigidbody rigidbody;

    private bool isWalk;
    private bool isDash;
    private bool isJump;
    private bool canJump;

    private float inputValue;

    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    void Update()
    {
        Move();
        Jump();

    }

    void Move()
    {
        if (isDash && isWalk)
        {
            rigidbody.AddForce(new Vector2(dashSpeed * inputValue, 0));
        }
        else if (isWalk)
        {
            rigidbody.AddForce(new Vector2(walkSpeed * inputValue, 0));
        }
    }

    void Jump()
    {
        if(canJump)
        {
            canJump = false;
            rigidbody.AddForce(new Vector2(0, jumpPower), ForceMode.Impulse);
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.CompareTag("Ground"))
        {
            canJump = true;
        }
    }
    public void OnMove(InputAction.CallbackContext context)
    {
        inputValue = context.ReadValue<Vector2>().x;
        if(context.performed) isWalk = true;
        if(context.canceled)  isWalk = false;
    }
    
    public void OnDash(InputAction.CallbackContext context)
    {
        if(context.performed) isDash = true;
        if(context.canceled)  isDash = false;
    }
    public void OnJump(InputAction.CallbackContext context)
    {
        if(context.performed) Jump();
    }
}
