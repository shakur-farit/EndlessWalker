using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ObstacleList_", menuName = "Scriptable Objects/Obstacle List")]
public class ObstacleListSO : ScriptableObject
{
    public List<ObstacleSO> obstacleList = new List<ObstacleSO>();
}
