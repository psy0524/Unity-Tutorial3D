using UnityEngine;

public class Bullet : MonoBehaviour
{
    
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Destroy(collision.gameObject); // ������Ʈ �ı�
            Destroy(collision.gameObject, 10f); // ������Ʈ ���� �ı�
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        
    }

    private void OnCollisionExit(Collision collision)
    {
        
    }
}
