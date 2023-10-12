using System;
using System.Collections.Generic;
using UnityEngine;

public class GamePlayManager : SingletonMonobehaviour<GamePlayManager>
{
    [SerializeField] private List<Player> players;
    private List<Player> activePlayers=new();

    [Header("GamePlay Config")] 
    public int initialScore;

    
    #region HandlePlayers
    
    public void StartGame()
    {
        foreach (var player in activePlayers)
        {
            player.gameObject.SetActive(true);
        }
    }

    public void InitSelectedPlayer()
    {
        for (int i = 0; i < players.Count; i++)
        {
            if (!players[i].isSelected)
            {
                players[i].Init(i+1,initialScore,Color.green);
                activePlayers.Add(players[i]);
                return;
            }
            continue;
        }
    }

    #endregion
 

}
