using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utility;

public class Ball : MonoBehaviour, IPooledObject
{
    [Header("Components"), Space] 
    [SerializeField] private Rigidbody rb;

    [Header("Config"), Space] 
    [SerializeField] private SO_Data ballBump;
    private float _speed;
    public float speed
    {
        get => _speed;
        set => _speed = value;
    }

    private void Start()
    {
        Invoke(nameof(FreezeYMovement),2f);
    }

    #region GameMechanics

    public void ApplyForce(float force, Vector3 direction,ForceMode forceMode)
    {
        rb.AddForce(direction*force,forceMode);
    }

    private void FreezeYMovement()
    {
        rb.constraints = RigidbodyConstraints.FreezePositionY;
    }
    
    private void OnCollisionEnter(Collision collision)
    {
        if(!collision.gameObject.CompareTag("Ball"))return; // handle collision between two Balls
        var dir = (collision.transform.position-transform.position).normalized;
        dir.y = 0;
        ApplyForce(ballBump.baseValue,dir,ForceMode.VelocityChange);
    }

    #endregion

    #region Pooling

    private ObjectPool pool;

    public void InvokeBackToPool(float time)
    {
        Invoke(nameof(BackToPool),time);
    }

    public void BackToPool()
    {
        rb.velocity=Vector3.zero;
        rb.constraints = RigidbodyConstraints.None;
        gameObject.SetActive(false);
        gameObject.transform.SetParent(pool.transform);
    }

    public void SetPool(ObjectPool _pool)
    {
        pool = _pool;
    }

    #endregion
}