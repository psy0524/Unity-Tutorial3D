using UnityEngine;

public class LocalData : MonoBehaviour
{
    private int score;

    private void Start()
    {
        
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            score++;
            
            //���� ������ ����
            PlayerPrefs.SetInt("score", score);
            int loadScore = PlayerPrefs.GetInt("score");

            PlayerPrefs.SetFloat("Volume", 0.5f);
            PlayerPrefs.SetString("UserName", "John");

            PlayerPrefs.DeleteKey("UserName");
            PlayerPrefs.DeleteAll();

            PlayerPrefs.Save(); // ����� �� �ڵ� ����


        }
    }
}
