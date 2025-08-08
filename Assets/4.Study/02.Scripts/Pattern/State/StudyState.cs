using Unity.VisualScripting;
using UnityEngine;

public class StudyState : MonoBehaviour
{
    public IState state = new IdleState();

    private IState idleState, moveState, attackState;

    private void Awake()
    {
        idleState  = gameObject.AddComponent<IdleState>();
        moveState = gameObject.AddComponent<MoveState>();
        attackState = gameObject.AddComponent<AttackState>();

        state = idleState;
    }

    private void Start()
    {
        state.StateEnter();
    }

    private void OnDestroy()
    {
        state.StateExit();
    }

    private void Update()
    {
        #region 기능 테스트
        state?.StateUpdate();

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            SetState(idleState);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            SetState(moveState);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            SetState(attackState);
        }

        #endregion

    }

    public void SetState(IState newState)
    {
        if(state != newState)
        {
            //상태 변경 전
            state.StateExit();

            state = newState; //상태 변경

            //상태 변경 후
            state.StateEnter();
        }
    }

}
