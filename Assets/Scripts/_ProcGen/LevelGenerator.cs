using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    [SerializeField] GameObject chuckPrefab;
    [SerializeField] int startingChunksAmount = 12;
    [SerializeField] Transform chunkParent;
    [SerializeField] float chunkLength = 10f;
    [SerializeField] float moveChunkSpeed = 8f;
    [SerializeField] float minMoveSpeed = 4f;
    [SerializeField] CameraController cameraController;
    List<GameObject> chunks = new List<GameObject>();

    void Start()
    {
        SpawningChunks();
    }

    void Update()
    {
        MoveChunks();
    }
    void SpawningChunks()
    {
        for (int i = 0; i < startingChunksAmount; i++)
        {
            SpawningChunk();
        }
    }

    private void SpawningChunk()
    {
        float spawnPositionZ = CalculateSpawnPositionZ();

        Vector3 chunkSpawnPos = new Vector3(transform.position.x, transform.position.y, spawnPositionZ);

        GameObject newChunk = Instantiate(chuckPrefab, chunkSpawnPos, Quaternion.identity, chunkParent);

        chunks.Add(newChunk);
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

    public void ChangeMoveSpeed(float speedAmount)
    {
        moveChunkSpeed += speedAmount;

        if (moveChunkSpeed < minMoveSpeed)
        {
            moveChunkSpeed = minMoveSpeed;
        }

        Physics.gravity = new Vector3(Physics.gravity.x, Physics.gravity.y, Physics.gravity.z - speedAmount);
        cameraController.ChangeFOV(speedAmount);
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
