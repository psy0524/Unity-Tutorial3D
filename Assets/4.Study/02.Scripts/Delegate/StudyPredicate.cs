using System;
using UnityEngine;

public class StudyPredicate : MonoBehaviour
{
    public Predicate<int> myPredicate;

    // 매개변수 한개만 사용 가능
    public int level = 10;

    private void Start()
    {
        myPredicate = n => n <= 10;
        string msg = myPredicate(level) ? "초보자 사냥터 입장 가능" : "초비자 사냥터 입장 불가능";

        Debug.Log(msg);
    }

    private void LevelCheck(int level)
    {
        if(level <= 30)
        {
            Debug.Log("초보자 사냥터 입장 가능");
        }
        else
        {
            Debug.Log("초보자 사냥터 입장 불가능");
        }
    }
}
