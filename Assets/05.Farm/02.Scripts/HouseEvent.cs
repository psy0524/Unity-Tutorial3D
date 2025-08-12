using Unity.Cinemachine;
using UnityEngine;

public class HouseEvent : MonoBehaviour
{
    [SerializeField] private CinemachineClearShot clearShot;
    [SerializeField] private GameObject houseTop;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            houseTop.SetActive(false);
            clearShot.ChildCameras[0].Priority = 1;
            clearShot.ChildCameras[3].Priority = 10;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            houseTop?.SetActive(true);
            clearShot.ChildCameras[0].Priority = 10;
            clearShot.ChildCameras[3].Priority = 1;
        }
    }
}
