using UnityEngine;
using TMPro;

public class CheckPoint : MonoBehaviour
{
    [SerializeField] TMP_Text addTimeText;
    float addTime = 5f;
    GameManager gameManager;
    
    void Start()
    {
        addTimeText.text = addTime.ToString();
        gameManager = FindFirstObjectByType<GameManager>();
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(ProjectConstants.PLAYER_TAG))
        {
            gameManager.IncreaseTime(addTime);
        }
    }
}
