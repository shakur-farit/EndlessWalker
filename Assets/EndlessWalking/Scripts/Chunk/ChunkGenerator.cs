using System;
using System.Collections.Generic;
using UnityEngine;

public class ChunkGenerator : MonoBehaviour
{
    [Header("References")]
    [Tooltip("Populate with ChunkList SO object")]
    [SerializeField] private ChunkListSO _chunkListSO;
    [Tooltip("Populate with Player game object")]
    [SerializeField] private Transform _player;

    [Header("Chunk Settings")]
    [Tooltip("Width of the chunk")]
    [SerializeField] private float _chunkWidth = 10f;
    [Tooltip("Distance from the center, crossing which a chunk is created")]
    [SerializeField] private float _radiusToGenerate = 5f;

    private List<Vector3> _generatedChunksPositionList = new List<Vector3>();

    private ChunkSpawner _chunkSpawner;
    private ObstacleGenerator _obstacleGenerator;
    private CurrentChunkPositionFinder _playerChunkPositionFinder;
    private ChunkExistenceChecker _chunkExistenceChecker;
    private ChunkRotator _chunkRotator;

    // Value for the correct rotate at chunk spawned on...
    private const float _valueToNorthSpawn = 180f; // north side
    private const float _valueToSouthSpawn = 0f; // south side
    private const float _valueToEastSpawn = 90f; // east side
    private const float _valueToWestSpawn = 270f; // west side

    private void Start()
    {
        _playerChunkPositionFinder = new CurrentChunkPositionFinder();
        _chunkExistenceChecker = new ChunkExistenceChecker();
        _chunkSpawner = new ChunkSpawner();
        _obstacleGenerator = new ObstacleGenerator();
        _chunkRotator = new ChunkRotator();

        SpawnChunk(0f, 0f, 0f);
    }

    private void Update()
    {
        TryToSpawn();
    }

    private void TryToSpawn()
    {
        Vector3 playerPosition = _player.position;
        Vector3 currentChunkPosition = _playerChunkPositionFinder
            .FindChunkOnPlayerPosition(_generatedChunksPositionList, _player.transform);

        Dictionary<Func<bool>, Action> spawnConditions = new Dictionary<Func<bool>, Action>
    {
        { 
            () => playerPosition.x > currentChunkPosition.x + _radiusToGenerate, 
            () => TrySpawnChunk(currentChunkPosition.x + _chunkWidth, 
            currentChunkPosition.z, _valueToEastSpawn) 
        },
        { 
            () => playerPosition.x < currentChunkPosition.x - _radiusToGenerate, 
            () => TrySpawnChunk(currentChunkPosition.x - _chunkWidth, 
            currentChunkPosition.z, _valueToWestSpawn) 
        },
        { 
             () => playerPosition.z > currentChunkPosition.z + _radiusToGenerate, 
             () => TrySpawnChunk(currentChunkPosition.x, 
             currentChunkPosition.z + _chunkWidth, _valueToSouthSpawn) 
        },
        { 
             () => playerPosition.z < currentChunkPosition.z - _radiusToGenerate, 
             () => TrySpawnChunk(currentChunkPosition.x, 
             currentChunkPosition.z - _chunkWidth, _valueToNorthSpawn) 
        }
    };

        foreach (var condition in spawnConditions)
        {
            if (condition.Key())
            {
                condition.Value();
                break;
            }
        }
    }

    private void TrySpawnChunk(float currentChunkXPosition, 
        float currentChunkZPosition, float valueToActialSideSpawn)
    {
        if (!_chunkExistenceChecker.IsChunkExists(_generatedChunksPositionList, 
            currentChunkXPosition, currentChunkZPosition))
        {
            SpawnChunk(currentChunkXPosition, currentChunkZPosition, valueToActialSideSpawn);
        }
    }

    private void SpawnChunk(float chunkXPosition, float chunkZPosition, float valueToActualRotate)
    {
        ChunkSO chunk = GetChunk();

        if (chunk == null)
            return;

        Quaternion chunkRotation = Quaternion.identity;
        
        if (chunk.HasBorders)
        {
            chunkRotation = _chunkRotator.GetValueToRotate(chunk, valueToActualRotate);
        }

        _chunkSpawner.SpawnChunk(chunk.Prefab, _generatedChunksPositionList,
            chunkXPosition, chunkZPosition, chunkRotation);

        _obstacleGenerator.SpawnObstacle(chunk, chunkXPosition, chunkZPosition);
    }

    public ChunkSO GetChunk()
    {
        List<ChunkSO> chunks = _chunkListSO.ChunkList;

        int randomIndex = UnityEngine.Random.Range(0, chunks.Count - 1);

        return chunks[randomIndex];
    }
}
