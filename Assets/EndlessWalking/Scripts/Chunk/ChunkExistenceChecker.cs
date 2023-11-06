using System.Collections.Generic;
using UnityEngine;

public class ChunkExistenceChecker
{
    public bool IsChunkExists(List<Vector3> generatedChunksPositionList, 
        float chunkXPosition, float chunkZPosition)
    {
        Vector3 positionToCheck = new Vector3(chunkXPosition, 0, chunkZPosition);
        return generatedChunksPositionList.Contains(positionToCheck);
    }
}
