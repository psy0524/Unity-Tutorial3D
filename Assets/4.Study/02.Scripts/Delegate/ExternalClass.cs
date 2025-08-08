using UnityEngine;

public class ExternalClass : MonoBehaviour
{
    private void Start()
    {
        StudySingleton.Instance.number = 10;
    }
}
