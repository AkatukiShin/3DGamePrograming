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
    private Animator animator;

    private bool isWalk;
    private bool isDash;
    private bool isJump;
    private bool canJump;

    private float inputValue;

    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        Move();
        RotatePlayer();
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
    
    void RotatePlayer()
    {
        // 右向き (inputValueが1)
        if (inputValue == 1)
        {
            // プレイヤーが左向きの場合（y軸の回転が180度に近い場合）
            if (Mathf.Abs(transform.eulerAngles.y - 180f) > 0.1f) // 180度との差を比較
            {
                // 右向きに回転させる
                transform.rotation = Quaternion.Euler(0, 0, 0);
            }
        }

        // 左向き (inputValueが-1)
        if (inputValue == -1)
        {
            // プレイヤーが右向きの場合（y軸の回転が0度に近い場合）
            if (Mathf.Abs(transform.eulerAngles.y - 0f) > 0.1f) // 0度との差を比較
            {
                // 左向きに回転させる
                transform.rotation = Quaternion.Euler(0, 180, 0);
            }
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
