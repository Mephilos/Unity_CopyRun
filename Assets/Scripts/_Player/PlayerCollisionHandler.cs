using System.Collections;
using UnityEngine;

public class PlayerCollisionHandler : MonoBehaviour
{
    [SerializeField] float HitCooldownTime = 1f;
    [SerializeField] float adjustMoveSpeedAmount = -2f;
    LevelGenerator levelGenerator;
    Animator animator;
    bool hitFlag = false;
    
    void Start()
    {
        animator = GetComponentInChildren<Animator>();
        levelGenerator = FindFirstObjectByType<LevelGenerator>();

        hitFlag = true;
        StartCoroutine(HitCooldown());
    }
    void OnCollisionEnter(Collision collision)
    {
        HitTrigger();
        Debug.Log("hit");
    }
    void HitTrigger()
    {
        if (hitFlag == true) return;

        if (hitFlag == false)
        {
            levelGenerator.ChangeMoveSpeed(adjustMoveSpeedAmount);
            animator.SetTrigger(ProjectConstants.HIT_ANIM_PLAYER);
            hitFlag = true;
            StartCoroutine(HitCooldown());
        }
    }
    IEnumerator HitCooldown()
    {
        yield return new WaitForSeconds(HitCooldownTime);
        hitFlag = false;
    }
}
