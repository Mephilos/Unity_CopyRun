using UnityEngine;
using TMPro;
using System;
using NUnit.Framework;
public class GameManager : MonoBehaviour
{
    [SerializeField] PlayerController playerController;
    [SerializeField] TMP_Text timeText;
    [SerializeField] GameObject gameOverText;
    [SerializeField] float startTime = 5f;

    float timeLeft;
    bool isGameOver;
    public bool GameOver => isGameOver;

    void Start()
    {
        timeLeft = startTime;
    }

    void Update()
    {
        if (isGameOver) return;
        DecreaseTime();
        PlayerGameOver();
    }
    public void IncreaseTime(float addTime)
    {
        timeLeft += addTime;
    }
    void DecreaseTime()
    {
        timeLeft -= Time.deltaTime;
        timeText.text = timeLeft.ToString("F1");
    }

    void PlayerGameOver()
    {
        if (timeLeft <= 0)
        {
            isGameOver = true;
            timeLeft = 0;
            Time.timeScale = 0.2f;
            playerController.enabled = false;
            gameOverText.SetActive(true);
        }
    }

}
