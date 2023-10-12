using System;
using UnityEngine;

public class Player:Actor
{
    [Header("Components"),Space] 
    [SerializeField] private PlayerController Controller;
    [SerializeField] private ScoreLine playerScoreLine;
    
    [Header("Data"),Space] 
    public PlayerData playerData;
    public bool isSelected = false;
    

    public void Init(int id,int score,Color color)
    {
        playerData = new PlayerData(id,score,color);
        playerScoreLine.score = score;
        playerScoreLine.scoreCard.SetScore(score);
        playerScoreLine.scoreCard.SetColorImage(color);
        playerScoreLine.scoreCard.gameObject.SetActive(true);
        playerScoreLine.OnPlayerDead += HandleDeath;
        isSelected = true;
    }

    private void HandleDeath()
    {
        //TODO Death
    }
}

public class PlayerData
{
    private int ID;
    private int Score;
    private Color color;

    public PlayerData(int _id,int _score,Color _color)
    {
        ID = _id;
        Score = _score;
        color = _color;
    }
    public Color Color => color;
}