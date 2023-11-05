using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ChunkList_", menuName = "Scriptable Objects/Chunk List")]
public class ChunkListSO : ScriptableObject
{
    public List<ChunkSO> chunkList = new List<ChunkSO>();
}