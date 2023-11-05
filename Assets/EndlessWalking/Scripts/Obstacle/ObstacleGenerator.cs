using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleGenerator
{
    public void SpawnObstacle(ChunkSO chunkSO, float chunkXPosition, float chunkZPosition)
    {
        List<ObstacleSO> obstacleList = chunkSO.obstacles.obstacleList;

        if (obstacleList.Count <= 0)
            return;

        int randomIndex = Random.Range(0, obstacleList.Count - 1);

        ObstacleSpawner spawner = new ObstacleSpawner();

        spawner.SpawnObstacle(obstacleList[randomIndex], chunkXPosition, chunkZPosition);
    }

}
