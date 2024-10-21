using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float walkSpeed = 10;
    [SerializeField] private float runSpeed  = 20;
    [SerializeField] private float jumpPower = 30;
    [SerializeField] private float gravityScale = 10;

    private Rigidbody rigidbody;

    private Vector2 direction;
    private Vector2 inputMove;

    private bool isMove;
    private bool isDush;

    private void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        if (isDush)
        {
            rigidbody.AddForce(new Vector2(runSpeed * inputMove.x, 0));
            Debug.Log("ダッシュ");
        }

        if (isMove)
        {
            rigidbody.AddForce(new Vector2(walkSpeed * inputMove.x, 0));
            Debug.Log("歩く");
        }

        rigidbody.AddForce(new Vector2(0,  -gravityScale));
}
    
    public void Move(InputAction.CallbackContext context)
    {
        inputMove = context.ReadValue<Vector2>();
        if (context.started)  isMove = true;
        if (context.canceled) isMove = false;
    }

    public void Dush(InputAction.CallbackContext context)
    {
        if (context.started)  isDush = true;
        if (context.canceled) isDush = false;
    }

    public void Jump(InputAction.CallbackContext context)
    {
        rigidbody.AddForce(new Vector2(0,jumpPower), ForceMode.Impulse);
    }
    
}
