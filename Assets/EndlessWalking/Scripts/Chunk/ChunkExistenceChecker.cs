using System.Collections.Generic;
using UnityEngine;

public class ChunkExistenceChecker
{
    public bool ChunkExists(List<Vector3> generatedChunksPositionList, float x, float z)
    {
        Vector3 positionToCheck = new Vector3(x, 0, z);
        return generatedChunksPositionList.Contains(positionToCheck);
    }
}
