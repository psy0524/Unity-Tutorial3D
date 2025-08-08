using UnityEngine;

public class StudyDelegate : MonoBehaviour
{
    public delegate void TimeStart();
    public TimeStart onTimerStart;

    public delegate void TimeEnd( );
    public TimeEnd onTimerEnd;

    private float timer  = 5f;
    private bool isTimer = true;

    private void OnEnable()
    {
        onTimerStart += StartEvent;
        onTimerEnd += EndEvent;
    }

    private void OnDisable()
    {
        onTimerStart -= StartEvent;
        onTimerEnd -= EndEvent;
    }

    private void Update()
    {
        if (!isTimer)
        {
            timer -= Time.deltaTime;
        }
        
        timer -= Time.deltaTime;

        if(timer <= 0f)
        {
            onTimerEnd?.Invoke();
        }
    }

    private void StartEvent()
    {
        Debug.Log("타이머 시작");
    }

    private void EndEvent()
    {
        Debug.Log("타이머 종료");
    }
}