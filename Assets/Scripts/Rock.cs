using UnityEngine;
using Unity.Cinemachine;
using System.Collections;

public class Rock : MonoBehaviour
{
    [SerializeField] ParticleSystem collisionPartcleSystem;
    [SerializeField] float shakeModifer = 10f;
    [SerializeField] AudioSource audioSource;

    CinemachineImpulseSource cinemachineImpulseSource;

    float rockSFXcd = 1f;
    bool isRockSFXcd = false;
    void Awake() 
    {
        cinemachineImpulseSource = GetComponent<CinemachineImpulseSource>();
    }

    void OnCollisionEnter(Collision other)
    {
        FireImpulse();
        CollisionFX(other);
    }

    private void FireImpulse()
    {

        float distance = Vector3.Distance(transform.position, Camera.main.transform.position);
        float shakeIntensity = (1f / distance) * shakeModifer;
        shakeIntensity = Mathf.Min(shakeIntensity, 1f);

        cinemachineImpulseSource.GenerateImpulse(shakeIntensity);
    }
    void CollisionFX(Collision other)
    {
        if (isRockSFXcd) return;
        isRockSFXcd = true;
        StartCoroutine(RockSFXCooldownRoutine());
        audioSource.Play();
        
        
        ContactPoint contactPoint = other.contacts[0];
        collisionPartcleSystem.transform.position = contactPoint.point;
        collisionPartcleSystem.Play();
    }

    IEnumerator RockSFXCooldownRoutine()
    {
        yield return new WaitForSeconds(rockSFXcd);
        isRockSFXcd = false;
    }
}
