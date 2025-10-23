using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class Coin : PickUp
{
    [SerializeField] int coinScore = 100;
    ScoreManager scoreManager;
    
    public void Initialize(ScoreManager scoreManager)
    {
        this.scoreManager = scoreManager;
    }
    protected override void OnPickUp()
    {
        scoreManager.IncreseScore(coinScore);
    }
}
