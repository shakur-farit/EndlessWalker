using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner
{
    private int spawnRadius = 3;

    public void SpawnObstacle(ObstacleSO obstacleSO, float chunkXPosition, float chunkZPosition)
    {
        float randomXPosition = Random.Range(chunkXPosition - spawnRadius, chunkXPosition + spawnRadius + 1);
        float randomZPosition = Random.Range(chunkZPosition - spawnRadius, chunkZPosition + spawnRadius + 1);
        Vector3 spawnPosition = new Vector3(randomXPosition, 0f, randomZPosition); 
        GameObject obstale = Object.Instantiate(obstacleSO.prefab, spawnPosition, Quaternion.identity);
        Debug.Log("ObsSpwn");
    }
}
