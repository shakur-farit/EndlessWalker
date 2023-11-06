using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Chunk_", menuName = "Scriptable Objects/Chunk")]
public class ChunkSO : ScriptableObject
{
    [Header("References")]
    [Tooltip("Populate with Chunk object prefab")]
    public GameObject Prefab = null;
    [Tooltip("Populate with ObstacleList SO object")]
    public ObstacleListSO ObstacleList = null;
    [Tooltip("Does a chunk have borders")]
    public bool HasBorders = false;
    [Tooltip("A list of entrance sides into the chunk.")]
    public EntranceConfig EntranceConfig = new EntranceConfig();
    
}

[System.Serializable]
public class EntranceConfig
{
    public EntranceSide[] EntranceAmount;
}
