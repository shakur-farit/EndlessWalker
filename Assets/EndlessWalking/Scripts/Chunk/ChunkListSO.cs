using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ChunkList_", menuName = "Scriptable Objects/Chunk List")]
public class ChunkListSO : ScriptableObject
{
    [Tooltip("Populate with Chunk SO objects")]
    public List<ChunkSO> ChunkList = new List<ChunkSO>();
}
