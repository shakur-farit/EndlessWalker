using UnityEngine;

[CreateAssetMenu(fileName = "Obstacle_", menuName = "Scriptable Objects/Obstacle")]
public class ObstacleSO : ScriptableObject
{
    public string ObstacleName;
    public GameObject Prefab;
}
