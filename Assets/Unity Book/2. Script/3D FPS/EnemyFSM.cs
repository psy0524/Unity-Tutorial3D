using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;

public class EnemyFSM : MonoBehaviour
{
    private enum EnemyState { Idle, Move, Attack, Return, Damaged, Die}
    private EnemyState m_State;

    public float findDistance = 8f; // 탐지거리
    private Transform player; // 타겟
    public float attackDistance = 3f; // 공격 가능 거리
    public float moveSpeed = 5f; // 이동 속도
    private CharacterController cc;

    private float currentTime = 0f; // 타이머
    private float attackDelay = 2f; // 공격 딜레이

    public int attackPower = 3;
    public int hp = 15;
    public int maxHp = 15;
    public Slider hpSlider;

    private Vector3 originPos;
    private Quaternion originRot;
    public float moveDistance = 20f;

    private Animator anim;
    NavMeshAgent smith;

    private void Start()
    {
        m_State= EnemyState.Idle;

        player = GameObject.Find("Player").transform;

        cc = GetComponent<CharacterController>();

        originPos = transform.position;
        originRot = transform.rotation;

        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

        anim = transform.GetComponentInChildren<Animator>(); // 자식에게 해당 컴포넌트가 있는지 찾기
        smith = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        switch (m_State)
        {
            case EnemyState.Idle:
                Idle();
                break;
            case EnemyState.Move:
                Move();
                break;
            case EnemyState.Attack:
                Attack();
                break;
            case EnemyState.Return:
                Return();
                break;
            case EnemyState.Damaged:
                //Damaged();
                break;
            case EnemyState.Die:
                //Die();
                break;
        }
        hpSlider.value = (float)hp / (float)maxHp;
    }

    private void Idle()
    {
        if(Vector3.Distance(transform.position, player.position) < findDistance)
        {
            anim.SetTrigger("IdleToMove");
            m_State = EnemyState.Move;
            Debug.Log("상태 전환 : Idle -> Move");
        }
    }

    private void Move()
    {
        if( Vector3.Distance(transform.position, originPos) > moveDistance)
        {
            m_State = EnemyState.Return;
            Debug.Log("상태 전환 : Move -> Return");
        }
        
        else if(Vector3.Distance(transform.position, player.position) > attackDistance) // 타겟이 공격 거리보다 먼 경우 -> 이동
        {
            //Vector3 dir = (player.position - transform.position).normalized;

            //cc.Move(dir * moveSpeed * Time.deltaTime);
            //transform.forward = dir; // 이동 방향을 정면으로 적용

            //내비게이션 에이전트의 이동을 멈추고 경로를 초기화한다.(공격 도중에 플레이어가 움직이면 공격하면서 움직일 수 있기 때문에)
            smith.isStopped = true;
            smith.ResetPath();
            
            //내비게이션으로 접근하는 최소 거리를 공격 가능 거리로 설정한다.
            smith.stoppingDistance = attackDistance;

            //내비게이션의 목적지를 플레이어의 위치로 설정한다.
            smith.SetDestination(player.position);
        }
        
        else
        {
            currentTime = attackDelay;
            anim.SetTrigger("MoveToAttackDelay");
            m_State = EnemyState.Attack;
            Debug.Log("상태 전환 : Move -> Attack");
        }
    }

    private void Attack()
    {
        if (Vector3.Distance(transform.position, player.position) < attackDistance) // 공격 범위 내에 있는 경우 공격 실행
        {
            currentTime += Time.deltaTime;
            if (currentTime >= attackDelay)
            {
                currentTime = 0f;
                //player.GetComponent<PlayerMoveFPS>().DamageAction(attackPower);
                anim.SetTrigger("StartAttack");
                Debug.Log("공격");
            }
        }
        else // 공격 범위 밖에 있을 경우 -> Move 전환
        {
            currentTime = 0f;
            anim.SetTrigger("AttackToMove");
            m_State = EnemyState.Move;
            Debug.Log("상태 전환 : Attack -> Move");
        }
    }

    public void AttackAction()
    {
        player.GetComponent<PlayerMoveFPS>().DamageAction(attackPower);
    }

    private void Return()
    {
        if( Vector3.Distance(transform.position, originPos) > 0.1f) // 원래 위치가 아닌 경우 -> 원래 위치로 이동
        {
            //Vector3 dir = (originPos - transform.position).normalized;
            //cc.Move(dir * moveSpeed * Time.deltaTime);
            //transform.forward = dir;

            smith.SetDestination(originPos);
            smith.stoppingDistance = 0;
        }
        else
        {
            // 내비게이션 에이전트의 이동을 멈추고 경로를 초기화한다.
            smith.isStopped = true;
            smith.ResetPath();
            
            transform.position = originPos;
            transform.rotation = originRot;
            hp = 15;
            anim.SetTrigger("MoveToIdle");
            m_State = EnemyState.Idle;
            Debug.Log("상태 전환 : Return -> Idle");
        }
    }

    public void HitEnemy(int hitDamage)
    {
        if(m_State == EnemyState.Damaged || m_State == EnemyState.Die || m_State == EnemyState.Return) { return; }

        hp -= hitDamage;

        smith.isStopped = true ;
        smith.ResetPath();
        if(hp > 0)
        {
            anim.SetTrigger("Damaged");
            m_State = EnemyState.Damaged;
            Debug.Log("상태 전환 : Any State -> Damaged");
            Damaged();
        }
        else
        {
            anim.SetTrigger("Die");
            m_State = EnemyState.Die;
            Debug.Log("상태 전환 : Any State -> Die");
            Die();
        }
    }

    private void Damaged()
    {
        StartCoroutine(DamageProcess());
    }

    IEnumerator DamageProcess()
    {
        yield return new WaitForSeconds(1f); // 피격 애니메이션 시간만큼 대기

        m_State = EnemyState.Move;
        Debug.Log("상태 전환 : Damage -> Move");
    }

    private void Die()
    {
        StopAllCoroutines();

        StartCoroutine(DieProcess());
    }

    IEnumerator DieProcess()
    {
        cc.enabled = false;

        yield return new WaitForSeconds(2f);

        Debug.Log("소멸");
        Destroy(gameObject);
    }
}
