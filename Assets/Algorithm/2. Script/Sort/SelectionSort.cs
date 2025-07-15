using UnityEngine;

public class SelectionSort : MonoBehaviour
{
    private int[] array = { 5, 2, 8, 6, 15, 4, 0 };

    private void Start()
    {
        Debug.Log($"���� �� : {string.Join(", ", array)}");

        Selection(array);
        Debug.Log($"���� �� : {string.Join(", ", array)}");
    }

    private void Selection(int[] array)
    {
        int n = array.Length;

        //�ε��� �� ����
        for (int i = 0; i < n-1; i++) // i : ������ �ε���
        {
            int minIdx = i;
            
            //�ڿ� �ִ� ����� ��
            for (int j = i; j < n; j++) // j : ���� �ε���
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
