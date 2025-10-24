using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    [SerializeField] List<GameObject> obstaclePrefabs;
    [SerializeField] float ObstacleSpawnTime = 1f;
    [SerializeField] Transform obstacleParent;
    [SerializeField] float spawnWidth = 4f;
    [SerializeField] float minObstacleSpawnTime = .4f;
    void Start()
    {
        StartCoroutine(SpawnObstacleRoutine());
    }
    
    public void DecreaseObstacleRespawnTime(float amount)
    {
        ObstacleSpawnTime -= amount;
        if (ObstacleSpawnTime <= minObstacleSpawnTime) ObstacleSpawnTime = minObstacleSpawnTime;
    }

    IEnumerator SpawnObstacleRoutine()
    {
        while (true)
        {
            GameObject obstaclePrefab = obstaclePrefabs[Random.Range(0, obstaclePrefabs.Count)];
            Vector3 spawnPosition = new Vector3(Random.Range(-spawnWidth, spawnWidth), transform.position.y, transform.position.z);

            yield return new WaitForSeconds(ObstacleSpawnTime);
            Instantiate(obstaclePrefab, spawnPosition, Random.rotation, obstacleParent);
        }
    }
}