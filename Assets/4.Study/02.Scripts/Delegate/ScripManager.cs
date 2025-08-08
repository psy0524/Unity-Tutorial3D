using System;
using UnityEngine;

public class ScripManager : MonoBehaviour
{
    public static Action emergencyStopButton;

    private void Start()
    {
        emergencyStopButton += StopMessage;
    }

    private void StopMessage()
    {
        Debug.Log("긴급 정비 실행");
    }
}
