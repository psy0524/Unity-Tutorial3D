using Unity.Cinemachine;
using UnityEngine;

public class AnimalFieldEvent : MonoBehaviour
{
    [SerializeField] private CinemachineClearShot clearShot;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            clearShot.ChildCameras[0].Priority = 1;
            clearShot.ChildCameras[2].Priority = 10;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            clearShot.ChildCameras[0].Priority = 10;
            clearShot.ChildCameras[2].Priority = 1;
        }
    }
}
