using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class AnimalController : MonoBehaviour
{
    private NavMeshAgent agent;
    private Animator anim;

    [SerializeField] private float wanderRaidus = 15f;

    private float minWaitTime = 1f;
    private float maxWaitTime = 5f;

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
    }

    IEnumerator Start()
    {
        while (true)
        {
            SetRandomDestination();
            anim.SetBool("IsWalk", true);

            yield return new WaitUntil(() => !agent.pathPending && agent.remainingDistance <= agent.stoppingDistance);

            anim.SetBool("IsWalk", false);
            float idleTime = Random.Range(minWaitTime, maxWaitTime);
            yield return new WaitForSeconds(idleTime);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            AnimalFieldEvent.failAction?.Invoke();
            Debug.Log("동물 피하기 실패");
        }
    }

    private void SetRandomDestination()
    {
        var randomDir = Random.insideUnitSphere * wanderRaidus;
        randomDir += transform.position;

        NavMeshHit hit;
        if(NavMesh.SamplePosition(randomDir, out hit, wanderRaidus, NavMesh.AllAreas))
        {
            agent.SetDestination(hit.position);
        }
    }
}
