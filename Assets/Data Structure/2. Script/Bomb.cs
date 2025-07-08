using System.Collections;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    private Rigidbody bombRb;
    public float bombTime = 4f;
    public float bombRange = 10f;
    public LayerMask layerMask;
    private void Awake()
    {
        bombRb = GetComponent<Rigidbody>();
    }

    // 원하는 타이밍에 폭파 효과

    IEnumerator Start()
    {
        yield return new WaitForSeconds(bombTime);

        BombForce();
    }

    private void BombForce()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, 10f, layerMask);

        foreach (var collider in colliders)
        {
            Rigidbody rb = collider.GetComponent<Rigidbody>();
            rb.AddExplosionForce(500f, transform.position, bombRange, 1f);
        }
        Destroy(gameObject);
    }
}
