using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class CrossBow : MonoBehaviour
{
    // 화살을 발사하는 기능
    // -화살
    // -발사할 위치
    // -화살이 날아가는 기능

    public GameObject arrowPrefab;
    public Transform shootTf;
    public bool isShoot;

    // 누군가를 감지하는 기능
    /// -직선상으로 감지
    ///  - 감지했을 때 화살을 새어
    ///  - 생성한 화살이 날아감
    private void Update()
    {
        Ray ray = new Ray(shootTf.position, shootTf.forward);
        RaycastHit hit; // 레이저 닿은 대상

        bool isTargeting = Physics.Raycast(ray, out hit);

        Debug.DrawRay(transform.position, transform.forward, Color.green);

        if (isTargeting && !isShoot)
        {
            StartCoroutine(ShootRoutine());
            
        }
    }

    IEnumerator ShootRoutine()
    {
        isShoot = true;

        GameObject arrow = Instantiate(arrowPrefab, transform);
        Quaternion rot = Quaternion.Euler(new Vector3(90, 0, 0));
        arrow.transform.SetPositionAndRotation(shootTf.position, rot);

        yield return new WaitForSeconds(3f);
        isShoot = false;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawRay(shootTf.position, shootTf.forward);
    }
}
