using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [Header("Components"), Space] 
    [SerializeField] private Animator animator;
    [SerializeField] private InputAction inputControl;
    [SerializeField] private Rigidbody rb;
    private float inputValue;

    [Header("Config"), Space] 
    [SerializeField] private float speed;


    private void OnEnable()
    {
        inputControl.Enable();
    }

    private void OnDisable()
    {
        inputControl.Disable();
    }

    private void Update()
    {
        GatherInput();
        HandleMoveAnimation();
    }

    private void FixedUpdate()
    {
        Move();
        
    }

    #region Movement

    private void GatherInput()
    {
        inputValue = inputControl.ReadValue<float>();
    }

    private void Move()
    {
        var newSpeed =inputValue * speed * Time.fixedDeltaTime;
        rb.velocity = new Vector3(newSpeed, 0, 0);
    }

    #endregion

    #region Animation

    private void HandleMoveAnimation()
    {
        animator.SetInteger("Walk",(int)inputValue);
    }

    #endregion
}