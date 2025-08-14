using UnityEngine;

public class FollowTarget : MonoBehaviour
{
    private Transform target;

    private void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void LateUpdate()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y, target.position.z);
    }
}
