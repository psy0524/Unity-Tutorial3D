using UnityEngine;

public class StudyString : MonoBehaviour
{
    string str1 = "Hello World";

    public string[] str2 = new string[3] { "Hello", "Unity", "World" };

    private void Start()
    {
        //Debug.Log(str1[0]);
        //Debug.Log(str1[2]);
        
        //Debug.Log(str2[0]);
        //Debug.Log(str2[2]);
        
        //Debug.Log(str1.Length); // ���ڿ��� ����
        //Debug.Log(str1.Trim()); // ���� ���� �յ� ���� ����
        //Debug.Log(str1.Trim('l')); // �յڹ��� '*' ���� : Heo Word
        
        //Debug.Log(str1.Contains("Hello"));
        //Debug.Log(str1.Contains('H'));
        //Debug.Log(str1.ToUpper());
        //Debug.Log(str1.ToLower());

        Debug.Log(str1.Replace("World", "Unity"));
        Debug.Log(str1);

        string text = "Apple,Banana,Orange";

        string[] fruits = text.Split(','); // Ư�� ���ڷ� �ɰ���

        foreach(var fruit in fruits)
        {
            Debug.Log(fruit);
        }

    }
}
