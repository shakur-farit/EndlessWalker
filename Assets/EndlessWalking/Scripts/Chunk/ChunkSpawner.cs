using System.Collections.Generic;
using UnityEngine;

public class ChunkSpawner
{
    public void SpawnChunk(GameObject prefab, List<Vector3> positionList,
        float chunkSpawnXPosition, float chunkSpawnZPosition, Quaternion chunkRotation)
    {
        Vector3 spawnPosition = new Vector3(chunkSpawnXPosition, 0, chunkSpawnZPosition);
        GameObject newChunk = PoolingManager.Instance.UseObject(prefab, spawnPosition, chunkRotation);
        positionList.Add(newChunk.transform.position);
    }
}
