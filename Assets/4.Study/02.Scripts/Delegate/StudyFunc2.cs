using NUnit.Framework;
using System;
using System.Collections.Generic;
using UnityEngine;

public class StudyFunc2 : MonoBehaviour
{
    public List<Func<int, int, int>> funcList = new List<Func<int, int, int>>();

    private void Start()
    {
        funcList.Add((a, b) => a + b);
        funcList.Add((a, b) => a - b);
        funcList.Add((a, b) => a * b);

        foreach (var func in funcList)
        {
            int result = func.Invoke(10, 20);
            Debug.Log(result);
        }
    }

    private int AddMethod(int a, int b)
    {
        return a + b;
    }

    private int MinusMethod(int a, int b)
    {
        return a - b;
    }

    private int MultiplyMethod(int a, int b)
    {
        return a * b;
    }
}
