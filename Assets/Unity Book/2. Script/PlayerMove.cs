using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float moveSpeed = 6f;

    private void Update()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        Vector3 dir = new Vector3(h, v, 0).normalized;
        transform.position += dir * moveSpeed * Time.deltaTime;
    }
}
