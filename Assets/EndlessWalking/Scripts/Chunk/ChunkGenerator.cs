using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class ChunkGenerator : MonoBehaviour
{
    public ChunkListSO chunkListSO;
    public Transform player;
    public float chunkWidth = 10f;
    public float radiusToGenerate = 5f;

    public List<Vector3> generatedChunksPositionList = new List<Vector3>();

    private ChunkSpawner chunkSpawner;
    private ObstacleGenerator obstacleGenerator;
    private CurrentChunkPositionFinder playerChunkPositionFinder;
    private ChunkExistenceChecker chunkExistenceChecker;

    private void Start()
    {
        playerChunkPositionFinder = new CurrentChunkPositionFinder(player);
        chunkExistenceChecker = new ChunkExistenceChecker();

        SpawnChunk(0f, 0f, 0f);
    }

    private void Update()
    {
        TryToSpawn();
    }

    private void TryToSpawn()
    {
        Vector3 playerPosition = player.position;
        Vector3 currentChunkPosition = playerChunkPositionFinder.
            FindPlayerCurrentChunkPosition(generatedChunksPositionList);

        if (playerPosition.x > currentChunkPosition.x + radiusToGenerate &&
            !chunkExistenceChecker.ChunkExists(generatedChunksPositionList,
            currentChunkPosition.x + chunkWidth,
            currentChunkPosition.z))
        {
            SpawnChunk(currentChunkPosition.x + chunkWidth, currentChunkPosition.z, 90f);
        }
        else if (playerPosition.x < currentChunkPosition.x - radiusToGenerate &&
            !chunkExistenceChecker.ChunkExists(generatedChunksPositionList,
            currentChunkPosition.x - chunkWidth,
            currentChunkPosition.z))
        {
            SpawnChunk(currentChunkPosition.x - chunkWidth, currentChunkPosition.z, 270f);
        }
        else if (playerPosition.z > currentChunkPosition.z + radiusToGenerate &&
            !chunkExistenceChecker.ChunkExists(generatedChunksPositionList,
            currentChunkPosition.x,
            currentChunkPosition.z + chunkWidth))
        {
            SpawnChunk(currentChunkPosition.x, currentChunkPosition.z + chunkWidth, 0f);
        }
        else if (playerPosition.z < currentChunkPosition.z - radiusToGenerate &&
            !chunkExistenceChecker.ChunkExists(generatedChunksPositionList,
            currentChunkPosition.x,
            currentChunkPosition.z - chunkWidth))
        {
            SpawnChunk(currentChunkPosition.x, currentChunkPosition.z - chunkWidth, 180f);
        }
    }

    private void SpawnChunk(float chunkXPosition, float chunkZPosition, float dependingOnSpawnSideRotate)
    {
        ChunkSO chunk = GetChunk();

        if (chunk == null)
            return;

        Quaternion chunkRotation = Quaternion.identity;
        

        if (chunk.hasBorders)
        {
            ChunkRotator chunkRotator = new ChunkRotator();
            chunkRotation = chunkRotator.GetValueToRotate(chunk, dependingOnSpawnSideRotate);
        }

        chunkSpawner = new ChunkSpawner();

        chunkSpawner.SpawnChunk(chunk.prefab, generatedChunksPositionList,
            chunkXPosition, chunkZPosition, chunkRotation);

        obstacleGenerator = new ObstacleGenerator();
        obstacleGenerator.SpawnObstacle(chunk, chunkXPosition, chunkZPosition);
    }

    public ChunkSO GetChunk()
    {
        List<ChunkSO> chunks = chunkListSO.chunkList;
        int randomIndex = Random.Range(0, chunks.Count - 1);
        Debug.Log(chunks[randomIndex].name);
        return chunks[randomIndex];
    }
}
