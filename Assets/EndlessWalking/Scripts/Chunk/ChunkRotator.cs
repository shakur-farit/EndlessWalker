using System.Collections.Generic;
using UnityEngine;

public class ChunkRotator
{
    // A dictionary where the keys are EntranceSide values and the values are the corresponding rotation angles.
    private readonly Dictionary<EntranceSide, float> _entranceSideAngles = 
        new Dictionary<EntranceSide, float>
    {
        { EntranceSide.North, 180f },
        { EntranceSide.South, 0f },
        { EntranceSide.East, 90f },
        { EntranceSide.West, 270f }
    };

    public Quaternion GetValueToRotate(ChunkSO chunk, float valueToActualRotate)
    {
        EntranceSide[] sides = chunk.EntranceConfig.EntranceAmount;
        EntranceSide randomEntranceSide = sides[Random.Range(0, sides.Length - 1)];

        float angle = _entranceSideAngles[randomEntranceSide] + valueToActualRotate;
        Quaternion rotation = Quaternion.Euler(0f, angle, 0f);

        return rotation;
    }
}
