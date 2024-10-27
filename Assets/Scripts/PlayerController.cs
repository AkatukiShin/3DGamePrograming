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
    [SerializeField] float rotateSpeed = 100; // 回転速度を設定

    private Rigidbody PLrigidbody;
    private Animator animator;
    private Vector3 currentRotateForward = Vector3.right; // 初期向きの設定を追加（右向き）

    private bool isWalk;
    private bool isDash;
    private bool isJump;
    private bool canJump;

    private float inputValue;

    void Start()
    {
        PLrigidbody = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        Move();
        RotatePlayer(); // 振り向き処理を追加
    }

    void Move()
    {
        if (isDash && isWalk)
        {
            PLrigidbody.AddForce(new Vector2(dashSpeed * inputValue, 0));
        }
        else if (isWalk)
        {
            PLrigidbody.AddForce(new Vector2(walkSpeed * inputValue, 0));
        }
    }

    void RotatePlayer()
    {
        // 入力に応じてプレイヤーのターゲット向きを設定
        if (inputValue > 0)
        {
            currentRotateForward = Vector3.right; // 右向き
        }
        else if (inputValue < 0)
        {
            currentRotateForward = Vector3.left; // 左向き
        }

        // ターゲット方向に向けて滑らかに回転
        Quaternion targetRotation = Quaternion.LookRotation(currentRotateForward);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotateSpeed * Time.deltaTime);
    }

    void Jump()
    {
        if (canJump)
        {
            canJump = false;
            PLrigidbody.AddForce(new Vector2(0, jumpPower), ForceMode.Impulse);
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            canJump = true;
        }
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        inputValue = context.ReadValue<Vector2>().x;
        if (context.performed) isWalk = true;
        if (context.canceled) isWalk = false;
    }
    
    public void OnDash(InputAction.CallbackContext context)
    {
        if (context.performed) isDash = true;
        if (context.canceled) isDash = false;
    }
    
    public void OnJump(InputAction.CallbackContext context)
    {
        if (context.performed) Jump();
    }
}
