using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ObstacleList_", menuName = "Scriptable Objects/Obstacle List")]
public class ObstacleListSO : ScriptableObject
{
    [Tooltip("Populate with Obstale SO object")]
    public List<ObstacleSO> ObstacleList = new List<ObstacleSO>();
}
