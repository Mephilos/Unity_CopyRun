using System.Collections;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    [SerializeField] GameObject obstaclePrefab;
    [SerializeField] float ObstacleSpawnTime = 1f;

    int ObstaclesSpawned = 0;

    void Start()
    {
        StartCoroutine(SpawnObstacleRoutine());
    }
    
    IEnumerator SpawnObstacleRoutine()
    {
        while (ObstaclesSpawned < 5)
        {
            yield return new WaitForSeconds(ObstacleSpawnTime);
            Instantiate(obstaclePrefab, transform.position, Random.rotation);
            ObstaclesSpawned++;
        }
    }
}
