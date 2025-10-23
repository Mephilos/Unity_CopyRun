using System.Collections;
using UnityEngine;

public class PlayerCollisionHandler : MonoBehaviour
{
    [SerializeField] Animator animator;
    [SerializeField] float HitCooldownTime = 1f;
    bool hitFlag = false;
    
    void Start()
    {
        animator = GetComponentInChildren<Animator>();
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
