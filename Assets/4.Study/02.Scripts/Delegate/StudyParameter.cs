using UnityEngine;

public partial class StudyPartial : MonoBehaviour
{
    public void MethodB()
    {
        Debug.Log("Method B");
    }
}

public class StudyParameter : MonoBehaviour
{
    public int number = 1;
    public int number2;

    

    void Start()
    {
        StudyPartial studyPartial = new StudyPartial();
        studyPartial.MethodB();
        //NomalParameter(number);

        //ReferenceParameter(ref number);

        //OutParameter(out number2);

        int[] intArray = new int[3] {10, 20, 30};
        ArrayParameter(intArray);

        ParamsParameter(10, 20, 30);
    }
    
    // 일반적인 매개변수 방법 -> Call by Value 값을 직접 부르기
    private void NomalParameter(int num)
    {
        num = 10;
    }

    // 선택적 매개변수 (Default 매개변수)
    private void DefaultParameter(int num = 3)
    {
        number = num;
    }

    // 오버로딩 : 매개변수를 다르게해서, 다른 기능을 구현하는 방법

    private void OverloadingMethod()
    {
        // 기능 A 실행
    }

    private void OverloadingMethod(int num)
    {
        // 기능 B 실행
    }

    private void OverloadingMethod(float num)
    {
        // 기능 C 실행
    }

    // 참조 방식의 매개변수 / 수정의 개념
    
    private void ReferenceParameter(ref int num)
    {
        num = 10;
    }

    // 반환의 개념
    // 초기화 하지 않아도 사용 가능
    private void OutParameter(out int num)
    {
        num = 30;
    }

    // Collection을 매개변수로 넣은 경우
    private void ArrayParameter(int[] numbers)
    {
        foreach(var n in numbers)
        {
            Debug.Log(n);
        }
    }

    // params를 활용한 매개변수
    private void ParamsParameter(params int[] numbers)
    {
        foreach(var n in numbers)
        {
            Debug.Log(n);
        }
    }
}
