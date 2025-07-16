using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Vector3 dir;
    private float speed = 6f;

    public GameObject explosionFactory;

    private void Start()
    {
        int ranValue = UnityEngine.Random.Range(0, 10);

        if (ranValue < 3) // 30�ۼ�Ʈ
        {
            GameObject target = GameObject.Find("Player");
            dir = (target.transform.position - transform.position).normalized; // �÷��̾ �ٶ󺸴� ���Ⱚ

        }
        else // 70�ۼ�Ʈ
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
        //����
        GameObject smObject = GameObject.Find("Score Manager");
        ScoreManager sm = smObject.GetComponent<ScoreManager>();
        
        var score = sm.GetScore() + 1;
        sm.SetScore(score);
        

        //��ƼŬ ����
        GameObject explosion = Instantiate(explosionFactory);
        explosion.transform.position = transform.position;
        
        //�ı� ���
        Destroy(collision.gameObject);
        Destroy(gameObject);
    }
}
