using System.Collections.Generic;
using UnityEngine;

public class StudyStack : MonoBehaviour
{
    public Stack<int> stack = new Stack<int>();
    public int[] array = new int[3] { 1, 2, 3 };
    public int[] array2;
    private void Start()
    {
        stack = new Stack<int>(array);

        Debug.Log(stack.ToString());

        array2 = stack.ToArray();
        
        Debug.Log(array2.ToString());
        
        
        //for(int i = 1; i <= 10; i++)
        //{
        //    stack.Push(i); // 1 ~ 10���� ���� Stack�� �߰�
        //}

        //Debug.Log(stack.Pop()); // ������ ���� ����
        //Debug.Log(stack.Count);
        //Debug.Log(stack.Peek()); // ������ ���� Ȯ�θ� �� �̱� X
        //Debug.Log(stack.Count);
        //Debug.Log(stack.Pop()); // 
        //Debug.Log(stack.Count);
    }
}
