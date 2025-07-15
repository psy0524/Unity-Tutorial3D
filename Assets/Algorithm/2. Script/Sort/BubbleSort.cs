using UnityEngine;

public class BubbleSort : MonoBehaviour
{
    private int[] array = { 5, 2, 8, 6, 15, 4, 0 };

    private void Start()
    {
        Debug.Log($"���� �� : {string.Join(", ", array)}");

        Bubble(array);
        Debug.Log($"���� �� : {string.Join(", ", array)}");
    }

    private void Bubble(int[] array)
    {
        int n = array.Length;
        for(int i = 0; i < n - 1; i++)
        {
            for (int j = 0; j < n - 1; j++)
            {
                if (array[j] > array[j + 1])
                {
                    int temp = array[j];
                    array[j] = array[j + 1];
                    array[j + 1] = temp;
                }
            }
        }
    }
}
