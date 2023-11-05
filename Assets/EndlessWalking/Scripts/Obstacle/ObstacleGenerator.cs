using System.Collections.Generic;
using UnityEngine;

public class ObstacleGenerator
{
    ObstacleSpawner spawner = new ObstacleSpawner();

    public void SpawnObstacle(ChunkSO chunkSO, float chunkXPosition, float chunkZPosition)
    {
        List<ObstacleSO> obstacleList = chunkSO.ObstacleList.ObstacleList;

        if (obstacleList.Count <= 0)
            return;

        int randomIndex = Random.Range(0, obstacleList.Count - 1);

        spawner.SpawnObstacle(obstacleList[randomIndex], chunkXPosition, chunkZPosition);
    }

}
