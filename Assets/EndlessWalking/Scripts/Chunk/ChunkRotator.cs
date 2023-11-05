using UnityEngine;

public class ChunkRotator
{
    private const float _valueOnNorthEntrance = 180f;
    private const float _valueOnSouthEntrance = 0f;
    private const float _valueOnEastEntrance = 90f;
    private const float _valueOnWestEntrance = 270f;

    public Quaternion GetValueToRotate(ChunkSO chunk, float valueToActualRotate)
    {
        EntranceSide[] sides = chunk.EntranceConfig.EntranceAmount;

        EntranceSide randomEntranceSide = sides[Random.Range(0, sides.Length - 1)];

        Quaternion rotation = Quaternion.identity;

        switch (randomEntranceSide)
        {
            case EntranceSide.North:
                rotation = Quaternion.Euler(0f, _valueOnNorthEntrance + valueToActualRotate, 0f);
                break;

            case EntranceSide.South:
                rotation = Quaternion.Euler(0f, _valueOnSouthEntrance + valueToActualRotate, 0f);
                break;

            case EntranceSide.East:
                rotation = Quaternion.Euler(0f, _valueOnEastEntrance + valueToActualRotate, 0f);
                break;

            case EntranceSide.West:
                rotation = Quaternion.Euler(0f, _valueOnWestEntrance + valueToActualRotate, 0f);
                break;
        }

        return rotation;
    }
}
