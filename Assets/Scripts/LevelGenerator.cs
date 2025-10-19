using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    [SerializeField] GameObject chuckPrefab;
    [SerializeField] int startingChunksAmount = 12;
    [SerializeField] Transform chunkParent;
    [SerializeField] float chunkLength = 10f;

    void Start()
    {
        for (int i = 0; i < startingChunksAmount; i++)
        {
            float spawnPositionZ;

            if (i == 0)
            {
                spawnPositionZ = transform.position.z;
            }

            else
            {
                spawnPositionZ = transform.position.z + (i * chunkLength);
            }

            Vector3 chunkSpawnPos = new Vector3(transform.position.x, transform.position.y, spawnPositionZ);

            Instantiate(chuckPrefab, chunkSpawnPos, Quaternion.identity, chunkParent);
        }
    }
}
