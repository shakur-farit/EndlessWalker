using UnityEngine;

public class ObstacleSpawner
{
    // The distance from the center of chunk within which obstacles will be generated.
    private int _spawnRadius = 3;

    public void SpawnObstacle(ObstacleSO obstacleSO, float chunkXPosition, float chunkZPosition)
    {
        float randomXPosition = Random.Range(chunkXPosition - _spawnRadius, 
            chunkXPosition + _spawnRadius + 1);
        float randomZPosition = Random.Range(chunkZPosition - _spawnRadius, 
            chunkZPosition + _spawnRadius + 1);

        Vector3 spawnPosition = new Vector3(randomXPosition, 0f, randomZPosition); 

        PoolingManager.Instance.UseObject(obstacleSO.Prefab, spawnPosition,Quaternion.identity);
    }
}
