using System.Collections.Generic;
using UnityEngine;

public class DynamicArray : MonoBehaviour
{
    public List<int> list1 = new List<int>();

    private void Start()
    {
        //list1.Add(10);
        
        for(int i = 1; i <= 10; i++)
        {
            list1.Add(i);
        }

        //list1.Remove(5); // �� 5������
        //list1.RemoveAt(9); // �ε��� 10�� �ڸ��� �Դ� ���� ����
        //list1.RemoveRange(1, 3); // �ε��� 1������ 3������ ����
        //list1.Clear(); // ����Ʈ ��� ���� ����

        //list1.RemoveAll(x => x > 5); // ���� List �ȿ��� x > 5 ���� ��� ����

        //list1.Sort(); // �������� ����

        if (list1.Contains(10)) // List���� 10�̶�� ���� ������ true
        {
            Debug.Log("�� 10�� ���� O");
        }
        else
        {
            Debug.Log("�� 10�� ���� X");
        }
    }
}
