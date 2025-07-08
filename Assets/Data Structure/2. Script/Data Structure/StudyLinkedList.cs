using System.Collections.Generic;
using UnityEngine;

public class StudyLinkedList : MonoBehaviour
{
    public LinkedList<int> linkedList  = new LinkedList<int>();
    string str;
    private void Start()
    {
        for(int i = 1; i <= 10; i++)
        {
            linkedList.AddLast(i); // 1~에서 10까지 추가
        }

        linkedList.AddFirst(100);
        linkedList.AddLast(200);

        var node = linkedList.AddFirst(1);
        linkedList.AddBefore(node, 300); // 노드 앞에 추가
        linkedList.AddAfter(node, 400); // 노드 뒤에 추가

        
        foreach (int i in linkedList)
        {
            str += i.ToString() + " / ";
        }
        Debug.Log(str);
    }
}
