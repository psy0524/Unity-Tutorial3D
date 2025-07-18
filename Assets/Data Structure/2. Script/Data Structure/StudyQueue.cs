using System.Collections.Generic;
using UnityEngine;

public class StudyQueue : MonoBehaviour
{
    public Queue<int> queue = new Queue<int>();

    private void Start()
    {
        for (int i = 1; i <= 10; i++)
        {
            queue.Enqueue(i);
        }

        int output = queue.Dequeue(); //값을 뽑음
        Debug.Log(output);

        Debug.Log(queue.Peek());

        queue.Contains(5); // 값 5가 포함되어 있는지 확인
        queue.Clear(); // 모든값 삭제

        Debug.Log(queue.Count); // 개수 확인
    }
}
