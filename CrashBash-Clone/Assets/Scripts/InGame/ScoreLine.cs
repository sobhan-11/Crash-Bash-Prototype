using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreLine : MonoBehaviour
{
    [Header("Components"), Space] 
    public ScoreCard scoreCard;
    public int score;

    [Header("Events")] 
    public Action OnPlayerDead;
    
    #region ScoreDetection

    private void OnTriggerEnter(Collider other)
    {
        if(!other.CompareTag("Ball")) return;
        //Handle Passed Ball
        var ball = other.GetComponent<Ball>();
        ball.InvokeBackToPool(3f);
        //Handle Score
        score--;
        if(score<0) return;        
        if(score==0) 
            OnPlayerDead?.Invoke();
        scoreCard.SetScore(score);
    }

    #endregion
}
