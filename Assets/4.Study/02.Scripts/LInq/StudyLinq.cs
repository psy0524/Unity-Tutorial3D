using UnityEngine;
using System.Linq;

public class StudyLinq : MonoBehaviour
{
    //var result = from 변수 in Collection
    //             where 조건
    //             select 조건을 통과한 대상

    public int[] numbers = {1, 2, 3, 4, 5};
    
    private void Start()
    {
        //var result = from number in numbers
        //             select number * number;

        //var result = numbers.Where(n => n > 3);

        var result = numbers.Select(n => n * n);

        foreach(var n in result)
        {
            Debug.Log(n);
        }

    }
}
