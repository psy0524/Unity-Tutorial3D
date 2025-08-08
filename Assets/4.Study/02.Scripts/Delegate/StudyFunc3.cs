using System;
using UnityEngine;

public class StudyFunc3 : MonoBehaviour
{
    public int hp = 100;

    public Func<int> GetHP;

    public Func<float, float> GetRemainHp;

    public Func<string> GetAction;

    private void Start()
    {
        GetHP = () => hp; // 그냥 체력
        GetRemainHp = (dmg) => hp - dmg; // 데미지 받은 이후의 체력

        GetAction = () =>
        {
            if (GetHP() > 50)
                return "공격";
            else if (GetHP() > 20)
                return "도망";
            else
                return "죽음";
        };
    }
}
