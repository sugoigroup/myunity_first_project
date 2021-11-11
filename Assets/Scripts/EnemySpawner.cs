﻿using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour
{

    [SerializeField]
    private GameObject enemyPrefab;
    [SerializeField]
    private StageData stageData;
    [SerializeField]
    private float spawnTime;


    private void Awake()
    {
        StartCoroutine("SpawnEnemy");

    }
    private IEnumerator SpawnEnemy()
    {
        while (true)
        {
            float positionX = Random.Range(stageData.LimitMin.x, stageData.LimitMax.x);
            Instantiate(enemyPrefab, new Vector3(positionX,stageData.LimitMax.y + 1.0f, 0.0f), Quaternion.identity);
            yield return new WaitForSeconds(spawnTime);
        }
    }
}
