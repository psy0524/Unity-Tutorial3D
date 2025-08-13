using Unity.Cinemachine;
using UnityEngine;

public class FieldEvent : MonoBehaviour
{
    [SerializeField] private CinemachineClearShot clearShot;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GameManager.Instance.SetCameraState(CameraState.Plantation);
            GameManager.Instance.uiManager.ActivatePlantationUI(true);
        }       
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GameManager.Instance.SetCameraState(CameraState.Outside);
            GameManager.Instance.uiManager.ActivatePlantationUI(false);
        }
    }
}
