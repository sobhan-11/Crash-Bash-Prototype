using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class BallSpawner : MonoBehaviour
{
    [Header("Components"), Space] [SerializeField]
    private ObjectPool pool;

    [Header("Config"), Space] [SerializeField]
    private List<Column> columns;
    [SerializeField] private float spawnIntervalTime;
    [SerializeField] private float spawnInitialForce;

    
    #region Spawn
    
    public void StartSpawn()
    {
        StartCoroutine(SpawnBallRoutin());
    }
    
    
    private IEnumerator SpawnBallRoutin()
    {
        while (true)
        {
            Spawn();
            yield return new WaitForSeconds(spawnIntervalTime);
        }
    }
    
    private void Spawn()
    {
        Ball ball = pool.GetObject<Ball>();
        if(!ball)return;
        ball.transform.position = GetRandomColumnForSpawn().spawnPlace.position;
        ball.gameObject.SetActive(true);
        SetRandomDirection(ball);
    }

    private Column GetRandomColumnForSpawn()
    {
        int randomIndex = Random.Range(0, columns.Count - 1);
        return columns[randomIndex];
    }

    private void SetRandomDirection(Ball ball)
    {
        var dir = (transform.position - ball.transform.position).normalized;
        dir.y = 0;
        dir = Quaternion.AngleAxis(Random.Range(-30,30), Vector3.up) * dir;
        ball.ApplyForce(spawnInitialForce,dir,ForceMode.Force);
    }

    #endregion
}

[Serializable]
public class Column
{
    public GameObject column;
    public Transform spawnPlace;
}