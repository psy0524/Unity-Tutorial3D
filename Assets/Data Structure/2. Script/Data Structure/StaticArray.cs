using Unity.Android.Gradle.Manifest;
using UnityEngine;

public class StaticArray : MonoBehaviour
{
    public int[] array1; // 배열 선언
    public int[] array2 = {10, 20, 30, 40 }; // 배열 선언과 초기화
    public int[] array3 = new int[4]; // 배열 선언 및 공간 할당
    public int[] array4 = new int[4] {1, 2, 3, 4}; // 배열 선언 및 공간 할당 + 초기화

    private void Start()
    {
        int number = array1[3];
    }
}


