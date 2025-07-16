using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float fireSpeed = 5f;
    
    private void Update()
    {
        Vector3 dir = Vector3.up;
        transform.position += dir * fireSpeed * Time.deltaTime;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Destroy(collision.gameObject); // ������Ʈ �ı�
            //Destroy(collision.gameObject, 10f); // ������Ʈ ���� �ı�
        }
    }

}
