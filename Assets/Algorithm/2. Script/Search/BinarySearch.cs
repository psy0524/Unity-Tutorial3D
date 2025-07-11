using UnityEngine;

public class BinarySearch : MonoBehaviour
{
    private int[] array = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 }; // ���ĵ� �����͸� Ž�� ����
    private int target = 7;

    private void Start()
    {
        int result = BSearch(); // Target�� �ε��� ���� ã�� ��
        Debug.Log($"Ÿ����{result}�� �ڸ��� �ֽ��ϴ�.");
    }

    private int BSearch()
    {
        int left = 0; // ó�� left
        int right = array.Length - 1; // ó�� right

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
