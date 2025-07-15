using UnityEngine;

public class SelectionSort : MonoBehaviour
{
    private int[] array = { 5, 2, 8, 6, 15, 4, 0 };

    private void Start()
    {
        Debug.Log($"정렬 전 : {string.Join(", ", array)}");

        Selection(array);
        Debug.Log($"정렬 후 : {string.Join(", ", array)}");
    }

    private void Selection(int[] array)
    {
        int n = array.Length;

        //인덱스 값 선택
        for (int i = 0; i < n-1; i++) // i : 선택한 인덱스
        {
            int minIdx = i;
            
            //뒤에 있는 값들과 비교
            for (int j = i; j < n; j++) // j : 비교할 인덱스
            {
                if (array[j] < array[minIdx])
                {
                    minIdx = j;
                }
            }

            int temp = array[i];
            array[i] = array[minIdx];
            array[minIdx] = temp;

        }
    }
}
