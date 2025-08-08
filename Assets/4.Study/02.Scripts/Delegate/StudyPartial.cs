using UnityEngine;

// partial 클래스를 분리해서 작성하는 방법

public partial class StudyPartial : MonoBehaviour
{
    void Start()
    {
        MethodA();
    }

    private void MethodA()
    {
        Debug.Log("Mehtod A");
    }
}


