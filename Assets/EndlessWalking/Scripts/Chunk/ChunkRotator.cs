using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ChunkRotator
{
    public Quaternion GetValueToRotate(ChunkSO chunk, float dependingOnSpawnSideRotate)
    {
        Quaternion valueToRotate = Quaternion.identity;

        Quaternion chunkCurrentRotatePosition = chunk.prefab.transform.rotation;

        switch (chunk.entranceConfig.entranceAmount.Length)
        {
            case 1:
                valueToRotate = RotationWithOneEntrance(chunk, dependingOnSpawnSideRotate);
                break;
        }

        return valueToRotate;
    }

    private Quaternion RotationWithOneEntrance(ChunkSO chunk, float dependingOnSpawnSideRotate)
    {
        EntranceSide entranceSide = chunk.entranceConfig.entranceAmount[0];

        Quaternion rotation = Quaternion.identity;

        switch (entranceSide)
        {
            case EntranceSide.North:
                rotation = Quaternion.Euler(0f, 180f + dependingOnSpawnSideRotate, 0f);
                break;

            case EntranceSide.South:
                rotation = Quaternion.Euler(0f, 0f + dependingOnSpawnSideRotate, 0f);
                break;

            case EntranceSide.East:
                rotation = Quaternion.Euler(0f, 90f + dependingOnSpawnSideRotate, 0f);
                break;

            case EntranceSide.West:
                rotation = Quaternion.Euler(0f, 270f + dependingOnSpawnSideRotate, 0f);
                break;
        }

        return rotation;
    }
}
