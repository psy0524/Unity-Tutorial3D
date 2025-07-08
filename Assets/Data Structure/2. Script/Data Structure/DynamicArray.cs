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

        //list1.Remove(5); // 값 5를제거
        //list1.RemoveAt(9); // 인덱스 10번 자리에 입는 값을 제거
        //list1.RemoveRange(1, 3); // 인덱스 1번에서 3개까지 제거
        //list1.Clear(); // 리스트 요소 전부 제거

        //list1.RemoveAll(x => x > 5); // 현재 List 안에서 x > 5 값은 모두 제거

        //list1.Sort(); // 오른차순 정렬

        if (list1.Contains(10)) // List에서 10이라는 값이 있으면 true
        {
            Debug.Log("값 10이 존재 O");
        }
        else
        {
            Debug.Log("값 10이 존재 X");
        }
    }
}
