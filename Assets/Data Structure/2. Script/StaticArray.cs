using Unity.Android.Gradle.Manifest;
using UnityEngine;

public class StaticArray : MonoBehaviour
{
    public int[] array1; // �迭 ����
    public int[] array2 = {10, 20, 30, 40 }; // �迭 ����� �ʱ�ȭ
    public int[] array3 = new int[4]; // �迭 ���� �� ���� �Ҵ�
    public int[] array4 = new int[4] {1, 2, 3, 4}; // �迭 ���� �� ���� �Ҵ� + �ʱ�ȭ

    private void Start()
    {
        int number = array1[3];
    }
}


