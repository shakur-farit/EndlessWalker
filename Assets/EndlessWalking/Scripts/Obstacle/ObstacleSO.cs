using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Obstacle_", menuName = "Scriptable Objects/Obstacle")]
public class ObstacleSO : ScriptableObject
{
    public string obstacleName;
    public GameObject prefab;
}
