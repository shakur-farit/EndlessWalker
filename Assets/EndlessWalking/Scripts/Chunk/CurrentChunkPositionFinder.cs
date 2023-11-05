using System.Collections.Generic;
using UnityEngine;

public class CurrentChunkPositionFinder
{
    public Vector3 FindChunkOnPlayerPosition(List<Vector3> generatedChunksPositionList,
        Transform playerTransform)
    {
        Vector3 playerPosition = playerTransform.position;
        float closestDistance = float.MaxValue;
        Vector3 chunkPosition = Vector3.zero;

        foreach (Vector3 chunkPos in generatedChunksPositionList)
        {
            float distance = Vector3.Distance(playerPosition, chunkPos);
            if (distance < closestDistance)
            {
                closestDistance = distance;
                chunkPosition = chunkPos;
            }
        }

        return chunkPosition;
    }
}
