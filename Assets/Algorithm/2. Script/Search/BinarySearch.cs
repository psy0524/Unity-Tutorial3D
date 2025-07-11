using UnityEngine;

public class BinarySearch : MonoBehaviour
{
    private int[] array = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 }; // 정렬된 데이터만 탐색 가능
    private int target = 7;

    private void Start()
    {
        int result = BSearch(); // Target의 인덱스 값을 찾는 것
        Debug.Log($"타겟은{result}번 자리에 있습니다.");
    }

    private int BSearch()
    {
        int left = 0; // 처음 left
        int right = array.Length - 1; // 처음 right

        while(left <= right)
        {
            int mid = (left + right) / 2;

            if (array[mid] == target)
            {
                return mid;
            }
            else if(array[mid] < target)
            {
                left = mid + 1;
            }
            else
            {
                right = mid - 1;
            }
        }
        return -1;
    }
}
