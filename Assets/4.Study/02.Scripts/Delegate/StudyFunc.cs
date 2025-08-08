using System;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;

public class StudyFunc : MonoBehaviour
{
    // 여러개의 매개변수를 넣을 수 있고 반환타입 있는 경우 Func 사용
    // 접근제한자 Func<매개변수, 매개변수, 반환타입> 변수명
    public enum Buff { A, B, C }
    public Buff buff;

    public Buff currentBuff;
    public int currentDmg;
    
    public Func<Buff, int, int> myFunc;

    private void Start()
    {
        myFunc = CalculateDamage;
        myFunc?.Invoke(currentBuff, currentDmg);
    }

    private int CalculateDamage(Buff buff, int dmg)
    {
        int result = 0;
        switch (buff)
        {
            case Buff.A:
                result = 10;
                break;
            case Buff.B:
                result = -20;
                break;
            case Buff.C:
                result = 100; 
                break;
        }

        return dmg * result;
    }

    

}
