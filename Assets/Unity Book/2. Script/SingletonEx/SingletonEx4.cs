using UnityEngine;

public class SingletonEx4 : MonoBehaviour // 게으른 초기화 방식
{
    private static SingletonEx4 instance; // 내부 변수
    public static SingletonEx4 Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new SingletonEx4();
            }

            return instance;
        }
    }
}
