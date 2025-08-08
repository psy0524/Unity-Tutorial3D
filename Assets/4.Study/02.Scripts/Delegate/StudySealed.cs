using UnityEngine;

public abstract class ParentClass : MonoBehaviour
{
    public abstract void Method();

}

// sealed 키워드는 클래스를 상속하지 못하게 만듦
public class StudySealed : ParentClass
{
    public sealed override void Method()
    {
        // 부모 클래스의 함수 기능을 가져오는 방법
        Debug.Log("Override Method");
    }
}
