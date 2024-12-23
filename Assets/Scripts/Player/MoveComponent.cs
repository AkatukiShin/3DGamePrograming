using System;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class MoveComponent : MonoBehaviour
{
    [SerializeField] private float walkSpeed = 12;
    [SerializeField] private float dashSpeed = 18;
    [SerializeField] private float jumpPower = 8;
    [SerializeField] private float rotateSpeed = 500;
    
    private bool isWalk;
    private bool isDash;
    private bool isJump;
    private bool canJump;
    private float inputValue;
    private Rigidbody PLrigidbody;
    private Vector3 currentRotateForward = Vector3.right;
    
    void Start()
    {
        PLrigidbody = GetComponent<Rigidbody>();
    }
    
    void FixedUpdate()
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
        if (inputValue > 0)
        {
            currentRotateForward = Vector3.right; 
        }
        else if (inputValue < 0)
        {
            currentRotateForward = Vector3.left; 
        }
        
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
    
    public void OnMove(InputAction.CallbackContext context)
    {
        inputValue = context.ReadValue<Vector2>().x;
        if (context.performed) isWalk = true;
        if (context.canceled) isWalk = false;
    }
    
    public void OnDush(InputAction.CallbackContext context)
    {
        if (context.performed) isDash = true;
       
        if (context.canceled) isDash = false;
    }
    
    public void OnJump(InputAction.CallbackContext context)
    {
        if (context.performed) Jump();
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Ground")||other.gameObject.CompareTag("Object")||other.gameObject.CompareTag("Pipe")||other.gameObject.CompareTag("ItemBox")||other.gameObject.CompareTag("CanBreakBox"))
        {
            canJump = true;
        }
    }
}
