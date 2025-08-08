using UnityEngine;

public class StudyEvent : MonoBehaviour
{
    public delegate void InputKeyHandler(string msg);
    public event InputKeyHandler onInputKey;

    private void Start()
    {
        onInputKey += InputKeyEvent;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            onInputKey?.Invoke("Hello Unity");
        }
    }

    private void InputKeyEvent(string msg)
    {
        Debug.Log(msg);
    }
}
