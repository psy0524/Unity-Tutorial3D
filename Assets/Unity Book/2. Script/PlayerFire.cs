using Unity.VisualScripting;
using UnityEngine;

public class PlayerFire : MonoBehaviour
{
    public GameObject bulletFactory;
    public GameObject firePosition;

    private void Start()
    {
        bulletFactory = Resources.Load<GameObject>("Bullet"); // 리소스 폴더에서 총알 프리팹 로드
    }

    private void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            GameObject bullet = Instantiate(bulletFactory);
            bullet.transform.position = firePosition.transform.position;
            bullet.transform.rotation = firePosition.transform.rotation;

            //bullet.transform.SetPositionAndRotation(위치, 회전); // 위치와 회전을 한번에 적용하는 기능
            //bullet.transform.SetParent(부모); // 부모 오브젝트 설정
        }
        
    }

}
