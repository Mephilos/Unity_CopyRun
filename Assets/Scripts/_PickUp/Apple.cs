using UnityEngine;

public class Apple : PickUp
{
    [SerializeField] float adjustMoveSpeedAmount = 2f;
    LevelGenerator levelGenerator;
    void Start()
    {
        levelGenerator = FindFirstObjectByType<LevelGenerator>();
    }
    protected override void OnPickUp()
    {
        levelGenerator.ChangeMoveSpeed(adjustMoveSpeedAmount);
        Debug.Log("Power UP");
    }
}
