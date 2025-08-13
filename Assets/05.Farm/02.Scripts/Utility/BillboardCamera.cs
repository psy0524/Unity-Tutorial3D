using UnityEngine;

public class BillboardCamera : MonoBehaviour
{
    private Transform mainCamera;
    private void Start()
    {
        mainCamera = Camera.main.transform;
    }

    private void LateUpdate()
    {
        transform.LookAt(mainCamera.transform);
    }
}
