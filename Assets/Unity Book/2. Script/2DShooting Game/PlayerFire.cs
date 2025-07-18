#define DEBUG_TEST

using System.Collections.Generic;
using UnityEngine;

public class PlayerFire : Singleton<PlayerFire>
{
    public GameObject bulletFactory;
    public GameObject firePosition;

    public int poolSize = 10;
    //public GameObject[] bulletObjectPool;
    //public List<GameObject> bulletObjectPool;
    public Queue<GameObject> bulletObjectPool;
    private void Start()
    {
        bulletFactory = Resources.Load<GameObject>("Bullet"); // 리소스 폴더에서 총알 프리팹 로드

        //bulletObjectPool = new GameObject[poolSize];
        //bulletObjectPool = new List<GameObject>();
        bulletObjectPool = new Queue<GameObject>();
        for (int i = 0; i < poolSize; i++)
        {
            GameObject bullet = Instantiate(bulletFactory);

            //bulletObjectPool[i] = bullet;
            //bulletObjectPool.Add(bullet);
            bulletObjectPool.Enqueue(bullet);


            bullet.SetActive(false);
        }
    }

    private void Update()
    {
#if UNITY_STANDALONE || UNITY_EDITOR
        if (Input.GetButtonDown("Fire1"))
        {
            Debug.Log("마우스 클릭");
            if (bulletObjectPool.Count > 0)
            {
                GameObject bullet = bulletObjectPool.Dequeue();
                bullet.SetActive(true);
                bullet.transform.position = firePosition.transform.position;
            }
            // 리스트 방식
            //if(bulletObjectPool.Count > 0)
            //{
#elif UNITY_ANDROID || UNITY_IOS
        if(Input.GetTouch(0).phase == TouchPhase.Began)
        {
            Debug.Log("손가락 터치");
            if(bulletObjectPool.Count > 0)
            {
                GameObject bullet = bulletObjectPool.Dequeue();
                bullet.SetActive(true);
                bullet.transform.position = firePosition.transform.position;
            }
        }


            //    GameObject bullet = bulletObjectPool[0];
            //    bullet.SetActive(true);
            //    bulletObjectPool.Remove(bullet);

            //    bullet.transform.position = firePosition.transform.position;
            //}
            // 배열 방식
            //for(int i = 0; i < poolSize;i++)
            //{
            //    GameObject bullet = bulletObjectPool[i];
            //    if (!bullet.activeSelf)
            //    {
            //        bullet.SetActive(true);
            //        bullet.transform.position  = firePosition.transform.position;

            //        break;
            //    }
            //} 배열로 오브젝트 풀 사용할 때


        }
#endif
        }
    }
}
