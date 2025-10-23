using UnityEngine;
using TMPro;
public class ScoreManager : MonoBehaviour
{
    [SerializeField] TMP_Text scoreText;

    int currentScore = 0;
    public void IncreaseScore(int score)
    {
        if (gameObject.GetComponent<GameManager>().GameOver) return;
    
        currentScore += score;
        scoreText.text = currentScore.ToString();
    
    }
}
