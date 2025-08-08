using System.Reflection;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class StudyUnityEvent : MonoBehaviour
{
    public UnityEvent onUnityEvent;

    private void Start()
    {
        onUnityEvent.AddListener(delegate
        {
            Debug.Log("Hello");
            Debug.Log("Unity");
            Debug.Log("World");
            MethodA();
            MethodB();

            PrintLog("Hello Unity");
        });
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            onUnityEvent?.Invoke();
        }
    }

    private void MethodA()
    {
        Debug.Log("Method A");
    }

    private void MethodB()
    {
        Debug.Log("Method B");
    }

    private void PrintLog(string msg)
    {
        Debug.Log(msg);
    }
}
