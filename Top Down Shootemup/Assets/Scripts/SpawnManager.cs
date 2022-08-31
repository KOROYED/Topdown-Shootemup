using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{

    public GameObject enemyPrefab;

    private GameManager gameManager;

    public int enemyCount;
    public int waveNumber = 1;

    void Start()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        SpawnEnemyWave(waveNumber);
    }


    void Update()
    {
        enemyCount = FindObjectsOfType<EnemyScript>().Length;
        if(enemyCount == 0 && gameManager.isGameActive == true)
        {
            waveNumber++;
            SpawnEnemyWave(waveNumber);
        }
        if(gameManager.isGameActive == false)
        {
            waveNumber = 0;
        }
    }


    void SpawnEnemyWave(int enemiesToSpawn)
    {
        for (int i = 0; i < enemiesToSpawn; i++)
        {
            
            Instantiate(enemyPrefab, GenerateSpawnPosition(), enemyPrefab.transform.rotation);
        }
    }

    private Vector3 GenerateSpawnPosition()
    {
        float spawnPosX = Random.Range(-15, 16);
        float spawnPosZ = Random.Range(2, 8);
        Vector3 randomPos = new Vector3(spawnPosX, 1, spawnPosZ);

        return randomPos;
    }
}
