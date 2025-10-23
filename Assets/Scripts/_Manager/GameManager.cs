using UnityEngine;
using TMPro;
using System;
public class GameManager : MonoBehaviour
{
    [SerializeField] TMP_Text timeText;
    [SerializeField] GameObject gameOverText;
    [SerializeField] float startTime = 5f;

    float timeLeft;

    void Start()
    {
        timeLeft = startTime;
    }

    void Update()
    {
        RemaingTime();
        GameOver();
    }

    void RemaingTime()
    {
        timeLeft -= Time.deltaTime;
        timeText.text = timeLeft.ToString("F1");
    }

    void GameOver()
    {
        if (timeLeft <= 0)
        {
            timeLeft = 0;
            Time.timeScale = 0.2f;
            gameOverText.SetActive(true);
        }
    }
}
