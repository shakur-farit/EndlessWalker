using System.Collections.Generic;
using UnityEngine;

public class CurrentChunkPositionFinder
{
    private Transform player;

    public CurrentChunkPositionFinder(Transform playerTransform)
    {
        player = playerTransform;
    }

    public Vector3 FindPlayerCurrentChunkPosition(List<Vector3> generatedChunksPositionList)
    {
        Vector3 playerPosition = player.position;
        float closestDistance = float.MaxValue;
        Vector3 closestChunkPosition = Vector3.zero;

        foreach (Vector3 chunkPosition in generatedChunksPositionList)
        {
            float distance = Vector3.Distance(playerPosition, chunkPosition);
            if (distance < closestDistance)
            {
                closestDistance = distance;
                closestChunkPosition = chunkPosition;
            }
        }

        return closestChunkPosition;
    }
}
