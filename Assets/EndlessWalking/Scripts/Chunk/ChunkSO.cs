using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Chunk_", menuName = "Scriptable Objects/Chunk")]
public class ChunkSO : ScriptableObject
{
    public GameObject Prefab = null;
    public ObstacleListSO ObstacleList = null;
    public bool HasBorders = false;
    public EntranceConfig EntranceConfig = new EntranceConfig();
    
}

[System.Serializable]
public class EntranceConfig
{
    public EntranceSide[] EntranceAmount;
}
