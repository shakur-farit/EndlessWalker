using System.Collections.Generic;
using UnityEngine;

public class ChunkGenerator : MonoBehaviour
{
    [SerializeField] private ChunkListSO _chunkListSO;
    [SerializeField] private Transform _player;
    [SerializeField] private float _chunkWidth = 10f;
    [SerializeField] private float _radiusToGenerate = 5f;

    private List<Vector3> _generatedChunksPositionList = new List<Vector3>();

    private ChunkSpawner _chunkSpawner;
    private ObstacleGenerator _obstacleGenerator;
    private CurrentChunkPositionFinder _playerChunkPositionFinder;
    private ChunkExistenceChecker _chunkExistenceChecker;
    private ChunkRotator _chunkRotator;

    // value for the correct rotate at chunk spawned on...
    private const float _valueOnNorthSpawn = 180f; // north side
    private const float _valueOnSouthSpawn = 0f; // south side
    private const float _valueOnEastSpawn = 90f; // east side
    private const float _valueOnWestSpawn = 270f; // west side

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

        Vector3 currentChunkPosition = _playerChunkPositionFinder.
            FindChunkOnPlayerPosition(_generatedChunksPositionList, _player.transform);

        // Spawn chunk when player go beyond the _radiusToGenerate in a certain direction
        if (playerPosition.x > currentChunkPosition.x + _radiusToGenerate && 
            !_chunkExistenceChecker.ChunkExists
               ( _generatedChunksPositionList,
               currentChunkPosition.x + _chunkWidth,
               currentChunkPosition.z
               )
           )
        {
            SpawnChunk(currentChunkPosition.x + _chunkWidth, currentChunkPosition.z, _valueOnEastSpawn);
        }
        else if (playerPosition.x < currentChunkPosition.x - _radiusToGenerate && 
                !_chunkExistenceChecker.ChunkExists
                   (_generatedChunksPositionList,
                   currentChunkPosition.x - _chunkWidth,
                   currentChunkPosition.z
                   )
                )
        {
            SpawnChunk(currentChunkPosition.x - _chunkWidth, currentChunkPosition.z, _valueOnWestSpawn);
        }
        else if (playerPosition.z > currentChunkPosition.z + _radiusToGenerate &&
                !_chunkExistenceChecker.ChunkExists
                   (_generatedChunksPositionList,
                   currentChunkPosition.x,
                   currentChunkPosition.z + _chunkWidth
                   )
                )
        {
            SpawnChunk(currentChunkPosition.x, currentChunkPosition.z + _chunkWidth, _valueOnSouthSpawn);
        }
        else if (playerPosition.z < currentChunkPosition.z - _radiusToGenerate &&
                 !_chunkExistenceChecker.ChunkExists
                   (_generatedChunksPositionList,
                   currentChunkPosition.x,
                   currentChunkPosition.z - _chunkWidth
                   )
                )
        {
            SpawnChunk(currentChunkPosition.x, currentChunkPosition.z - _chunkWidth, _valueOnNorthSpawn);
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

        int randomIndex = Random.Range(0, chunks.Count - 1);

        return chunks[randomIndex];
    }
}
