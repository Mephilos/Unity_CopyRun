using System.Collections.Generic;
using UnityEngine;

public class Chunk : MonoBehaviour
{
    [SerializeField] GameObject fencePrefab;
    [SerializeField] GameObject ApplePrefab;
    [SerializeField] GameObject CoinPrefab;
    [SerializeField] float appleSpawnChance = 0.3f;
    [SerializeField] float coinSpawnChance = 0.6f;
    [SerializeField] float[] lanes = { -3f, 0f, 3f };
    [SerializeField] List<int> availableLanes = new List<int> { 0, 1, 2 };
    [SerializeField] float CoinSeperationLength = 2f;

    void Start()
    {
        SpawnFences();
        SpawnApple();
        SpawnCoins();
    }

    private void SpawnCoins()
    {
        if (Random.value > coinSpawnChance || availableLanes.Count <= 0) return;
        
        int selectLane = SelectLane();

        int maxCoinsToSpawn = 6;
        int spawnCount = Random.Range(0, maxCoinsToSpawn);
        
        float chunkPosZStartPos = transform.position.z - (CoinSeperationLength * 2f);
        
        for (int i = 0; i < spawnCount; i++)
        {
            float spawnPosZ = chunkPosZStartPos + (CoinSeperationLength * i);

            Vector3 coinSpawnPosition = new Vector3(lanes[selectLane], transform.position.y, spawnPosZ);
            Instantiate(CoinPrefab, coinSpawnPosition, Quaternion.identity, this.transform);
        }
    }

    void SpawnFences()
    {
        if (availableLanes.Count <= 0) return;

        int fenceToSpawn = Random.Range(0, lanes.Length);

        for (int i = 0; i < fenceToSpawn; i++)
        {
            int selectLane = SelectLane();

            Vector3 fenceSpawnPosition = new Vector3(lanes[selectLane], transform.position.y, transform.position.z);
            Instantiate(fencePrefab, fenceSpawnPosition, Quaternion.identity, this.transform);
        }
    }

    void SpawnApple()
    {   
        if (Random.value > appleSpawnChance || availableLanes.Count <= 0) return;

        int selectLane = SelectLane();

        Vector3 applePrefabPosition = new Vector3(lanes[selectLane], transform.position.y, transform.position.z);
        Instantiate(ApplePrefab, applePrefabPosition, Quaternion.identity, this.transform);
    }

    int SelectLane()
    {

        int randomLanesIndex = Random.Range(0, availableLanes.Count);
        
        int selectLane = availableLanes[randomLanesIndex];
        availableLanes.RemoveAt(randomLanesIndex);
        return selectLane;
    }
}
