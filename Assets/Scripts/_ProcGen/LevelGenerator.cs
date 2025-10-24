using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    [Header ("References")]
    [SerializeField] List<GameObject> chunkPrefabs;
    [SerializeField] Transform chunkParent;
    [SerializeField] GameObject checkPointChunk;
    [SerializeField] CameraController cameraController;

    [Header ("LevelSetting")]
    [SerializeField] int startingChunksAmount = 12;
    [SerializeField] float chunkLength = 10f;
    [SerializeField] float moveChunkSpeed = 8f;
    [SerializeField] float minMoveSpeed = 4f;
    [SerializeField] float maxMoveSpeed = 16f;
    [SerializeField] float minGravity = -6f;
    [SerializeField] float maxGravity = -20f;

    int checkPointSpawnIntervel = 8;
    int chunkCounter = 0;
    ScoreManager scoreManager;
    List<GameObject> chunks = new List<GameObject>();
    void Start()
    {
        scoreManager = FindFirstObjectByType<ScoreManager>();
        SpawningChunks();
    }

    void Update()
    {
        MoveChunks();
    }

    public void ChangeMoveSpeed(float speedAmount)
    {
        float newMoveSpeed = moveChunkSpeed + speedAmount;
        newMoveSpeed = Mathf.Clamp(newMoveSpeed, minMoveSpeed, maxMoveSpeed);

        if (newMoveSpeed != moveChunkSpeed)
        {
            float newGravity = Physics.gravity.z - speedAmount;
            newGravity = Mathf.Clamp(newGravity, minGravity, maxGravity);
            Physics.gravity = new Vector3(Physics.gravity.x, Physics.gravity.y, newGravity);
            cameraController.ChangeFOV(speedAmount);
        }
    }

    void SpawningChunks()
    {
        for (int i = 0; i < startingChunksAmount; i++)
        {
            SpawningChunk();
        }
    }

    void SpawningChunk()
    {

        float spawnPositionZ = CalculateSpawnPositionZ();

        Vector3 chunkSpawnPos = new Vector3(transform.position.x, transform.position.y, spawnPositionZ);

        GameObject chunkToSpawn = SelectSpawnChunk();

        GameObject newChunkGO = Instantiate(chunkToSpawn, chunkSpawnPos, Quaternion.identity, chunkParent);

        chunks.Add(newChunkGO);

        Chunk newChunk = newChunkGO.GetComponent<Chunk>();
        newChunk.Initialize(this, scoreManager);
        chunkCounter++;
    }

    GameObject SelectSpawnChunk()
    {
        if (chunkCounter % checkPointSpawnIntervel == 0 && chunkCounter != 0)
        {
            return checkPointChunk;
        }
        else
        {
            return chunkPrefabs[Random.Range(0, chunkPrefabs.Count)];
        }
    }

    float CalculateSpawnPositionZ()
    {
        float spawnPositionZ;
        if (chunks.Count == 0)
        {
            spawnPositionZ = transform.position.z;
        }
        else
        {
            spawnPositionZ = chunks[chunks.Count - 1].transform.position.z + chunkLength;
        }

        return spawnPositionZ;
    }

    void MoveChunks()
    {
        for (int i = 0; i < chunks.Count; i++)
        {
            GameObject chunk = chunks[i];
            chunk.transform.Translate(-transform.forward * (moveChunkSpeed * Time.deltaTime));

            if (chunk.transform.position.z <= Camera.main.transform.position.z - chunkLength)
            {
                chunks.Remove(chunk);
                Destroy(chunk);
                SpawningChunk();
            }
        }
    }
}
