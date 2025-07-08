using UnityEngine;

public class MultiDimesionalArray : MonoBehaviour // 다차원 배열 (2차원 , 3차원 등등)
{
    public int[,] array1 = new int[3,3];
    public int[,,] array2 = new int[3,3,3];

    private void Start()
    {
        int number1 = array1[0, 0];
        int number2 = array1[1, 0];
        int number3 = array1[2, 2];
    }
}
