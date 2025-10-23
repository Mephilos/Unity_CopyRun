using UnityEngine;
using TMPro;
public class ScoreManager : MonoBehaviour
{
    [SerializeField] TMP_Text scoreText;

    int currentScore = 0;
    public void IncreseScore(int score)
    {
        currentScore += score;
        scoreText.text = currentScore.ToString();
    }
}
