using UnityEngine;

public class SingletonEx3 : MonoBehaviour // 즉시 초기화 방식
{
    private static SingletonEx3 instance = new SingletonEx3(); // 내부 변수 (사용 X)
    public static SingletonEx3 Instance
    {
        get
        {
            if(instance == null)
            {
                instance = new SingletonEx3();
            }

            return instance;
        }
    }

}
