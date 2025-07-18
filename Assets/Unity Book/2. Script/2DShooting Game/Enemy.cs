using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Vector3 dir;
    private float speed = 6f;

    public GameObject explosionFactory;

    private void Start()
    {
        int ranValue = UnityEngine.Random.Range(0, 10);

        if (ranValue < 3) // 30퍼센트
        {
            GameObject target = GameObject.Find("Player");
            dir = (target.transform.position - transform.position).normalized; // 플레이어를 바라보는 방향값

        }
        else // 70퍼센트
        {
            dir = Vector3.down;
        }
    }

    private void Update()
    {
        transform.position += dir * speed * Time.deltaTime;
    }

    private void OnCollisionEnter(Collision collision)
    {
        ////점수
        //GameObject smObject = GameObject.Find("Score Manager");
        //ScoreManager sm = smObject.GetComponent<ScoreManager>();

        //var score = sm.GetScore() + 1;
        //sm.SetScore(score);

        //위의 주석을 한줄로 만든 싱글톤 패턴 코드 (점수 저장 및 불러오기)
        ScoreManager.Instance.Score++;

        //파티클 생성
        GameObject explosion = Instantiate(explosionFactory);
        explosion.transform.position = transform.position;

        //파괴 기능
        if (collision.gameObject.name.Contains("Bullet"))
        {
            //PlayerFire player = GameObject.Find("Player").GetComponent<PlayerFire>();
            //PlayerFire.Instance.bulletObjectPool.Add(collision.gameObject);
            PlayerFire.Instance.bulletObjectPool.Enqueue(collision.gameObject);
            collision.gameObject.SetActive(false);
        }
        else
        {
            Destroy(collision.gameObject);
        }

        // Pool.Add
        //EnemyManager.Instance.enemyObjectPool.Add(gameObject);
        EnemyManager.Instance.enemyObjectPool.Enqueue(gameObject);
        gameObject.SetActive(false);
    }
}
