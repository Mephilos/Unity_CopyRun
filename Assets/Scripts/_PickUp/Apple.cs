using UnityEngine;

public class Apple : PickUp
{
    [SerializeField] float adjustMoveSpeedAmount = 2f;
    LevelGenerator levelGenerator;
    public void Initialize(LevelGenerator levelGenerator)
    {
        this.levelGenerator = levelGenerator; 
    }
    protected override void OnPickUp()
    {
        levelGenerator.ChangeMoveSpeed(adjustMoveSpeedAmount);
        Debug.Log("Power UP");
    }
}
