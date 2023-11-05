using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Chunk_", menuName = "Scriptable Objects/Chunk")]
public class ChunkSO : ScriptableObject
{
    public GameObject prefab = null;
    public ObstacleListSO obstacles = null;
    public bool hasBorders = false;
    public EntranceConfig entranceConfig = new EntranceConfig();
    
}

[System.Serializable]
public class EntranceConfig
{
    public EntranceSide[] entranceAmount;
}
