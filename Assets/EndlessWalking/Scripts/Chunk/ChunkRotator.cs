using UnityEngine;

public class ChunkRotator
{
    // The value of the starting rotation position of a chunk when the entrance is facing...
    private const float _valueOnNorthEntrance = 180f; // Notrh
    private const float _valueOnSouthEntrance = 0f; // South
    private const float _valueOnEastEntrance = 90f; // East
    private const float _valueOnWestEntrance = 270f; // West

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
