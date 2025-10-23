using System.Collections;
using Unity.Cinemachine;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] float minFOV = 40f;
    [SerializeField] float maxFOV = 100f;
    [SerializeField] float zoomDuration = 1f;
    [SerializeField] float zoomSpeedModifer = 5f;

    CinemachineCamera cinemachineCamera;

    void Awake()
    {
        cinemachineCamera = GetComponent<CinemachineCamera>();
    }

    public void ChangeFOV(float speedAmount)
    {
        StartCoroutine(ChangeFOVRoutine(speedAmount));
    }
    
    IEnumerator ChangeFOVRoutine(float speedAmount)
    {
        float startFOV = cinemachineCamera.Lens.FieldOfView;
        float targetFOV = Mathf.Clamp(startFOV + speedAmount * zoomSpeedModifer, minFOV, maxFOV);

        float elapesedTime = 0f;

        while (elapesedTime < zoomDuration)
        {
            float t = elapesedTime / zoomDuration;
            elapesedTime += Time.deltaTime;

            cinemachineCamera.Lens.FieldOfView = Mathf.Lerp(startFOV, targetFOV, t);
            yield return null;
        }

        cinemachineCamera.Lens.FieldOfView = targetFOV;
    }
}
