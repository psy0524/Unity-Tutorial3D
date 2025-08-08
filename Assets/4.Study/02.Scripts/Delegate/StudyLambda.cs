using UnityEngine;

public class StudyLambda : MonoBehaviour
{
    public delegate void MyDelegate(string s);
    public MyDelegate myDelegate;


    private void Start()
    {
        myDelegate += (n) =>
        {
            OnLog(n);
            Debug.Log(n);
        };
        
        myDelegate?.Invoke("Lambda");
    }

    private void OnLog(string msg)
    {
        Debug.Log("Hello Unity");
    }
}
