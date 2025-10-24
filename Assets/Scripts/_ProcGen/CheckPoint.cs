using UnityEngine;
using TMPro;

public class CheckPoint : MonoBehaviour
{
    [SerializeField] TMP_Text addTimeText;
    float addTime = 5f;
    float obstacleTime = 0.1f;
    GameManager gameManager;
    ObstacleSpawner obstacleSpawner;
    
    void Start()
    {
        addTimeText.text = addTime.ToString();
        gameManager = FindFirstObjectByType<GameManager>();
        obstacleSpawner = FindFirstObjectByType<ObstacleSpawner>();
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(ProjectConstants.PLAYER_TAG))
        {
            gameManager.IncreaseTime(addTime);
            obstacleSpawner.DecreaseObstacleRespawnTime(obstacleTime);
        }
    }
}
