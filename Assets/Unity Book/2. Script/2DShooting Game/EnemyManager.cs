using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : Singleton<EnemyManager>
{
    public int poolSize = 10;

    public Queue<GameObject> enemyObjectPool;
    public Transform[] SpawnPoints;
    
    private float currentTime;
    public float createTime = 1f;
    private float minTime = 1f;
    private float maxTime = 5f;

    public GameObject enemyFactory;

    private void OnEnable()
    {
        createTime = Random.Range(minTime,maxTime);

        //enemyObjectPool = new GameObject[poolSize];
        //enemyObjectPool = new List<GameObject>();
        enemyObjectPool = new Queue<GameObject>();

        for(int i = 0; i < poolSize; i++)
        {
            GameObject enemy = Instantiate(enemyFactory);

            //enemyObjectPool[i] = enemy;
            //enemyObjectPool.Add(enemy);
            enemyObjectPool.Enqueue(enemy);
            enemy.SetActive(false);
        }
    }

    private void Update()
    {
        currentTime += Time.deltaTime;

        if (currentTime > createTime) //랜덤한 시간이 될 때 마다 랜덤한 위치에 Enemy 생성
        {
            if(enemyObjectPool.Count > 0)
            {
                currentTime = 0f;
                createTime = Random.Range(minTime, maxTime);
                enemyObjectPool.Dequeue();

                GameObject enemy = enemyObjectPool.Dequeue();

                int ranIndex = Random.Range(0, SpawnPoints.Length);
                Transform spawnPoint = SpawnPoints[ranIndex];

                enemy.transform.position = spawnPoint.position;
                enemy.SetActive(true);
            }
            //if (enemyObjectPool.Count > 0)
            //{
            //    currentTime = 0f;
            //    createTime = Random.Range(minTime, maxTime);

            //    GameObject enemy = enemyObjectPool[0];
            //    enemyObjectPool.Remove(enemy);

            //    int ranIndex = Random.Range(0, SpawnPoints.Length);
            //    Transform spawnPoint = SpawnPoints[ranIndex];

            //    enemy.transform.position = spawnPoint.position;
            //    enemy.SetActive(true);

            //}
            //for(int i = 0; i < poolSize;i++)
            //{
            //    GameObject enemy = enemyObjectPool[i];
            //    if (enemy.activeSelf == false)
            //    {
            //        int ranIndex = Random.Range(0, SpawnPoints.Length);
            //        Transform spawnPoint = SpawnPoints[ranIndex];

            //        enemy.transform.position = spawnPoint.position;
            //        enemy.SetActive(true);

            //        break;
            //    }
            //}
        }
    }
}
