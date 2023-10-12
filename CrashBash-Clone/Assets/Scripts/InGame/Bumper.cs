using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bumper : MonoBehaviour
{
    [Header("Components"), Space] 
    
    
    [Header("Config"), Space] 
    [SerializeField] private SO_Data bumpData;
    [SerializeField] private Enm_BumpDirectionType bumpDirectionType;
    [SerializeField] private ForceMode forceMode;
    

    private void OnCollisionEnter(Collision collision)
    {
        if(!collision.collider.CompareTag("Ball"))return;
        
        //Get Hit Point
        var hitPointPosition = collision.GetContact(0).point; //On collision We always have atleast one contact point
        
        //Get Bump Direction
        Vector3 dir = GetDirection(collision.transform,hitPointPosition);
        
        Ball ball = collision.gameObject.GetComponent<Ball>();
        ball.ApplyForce(bumpData.baseValue,dir,forceMode);
    }

    
    private Vector3 GetDirection(Transform subject,Vector3 hitPoint)
    {
        Vector3 dir = new Vector3();
        switch (bumpDirectionType)
        {
            case Enm_BumpDirectionType.Reverse:
                dir=(subject.position-hitPoint).normalized;
                break;
            case Enm_BumpDirectionType.Reflect:
                dir=(hitPoint-subject.position).normalized;
                dir = Vector3.Reflect(dir, Vector3.right);
                break;
        }
        dir.y = 0;
        return dir;
    }
}

public enum Enm_BumpDirectionType
{
    Reverse = 0,
    Reflect = 1
}
