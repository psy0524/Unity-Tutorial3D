using UnityEngine;
using UnityEngine.InputSystem;

public class FPSPlayerRotate : MonoBehaviour
{
    public float rotSpeed = 200f;

    public float mx = 0;

    private void Update()
    {
        if (FPSGameManager.Instance.gState != FPSGameManager.GameState.Run)
        {
            return;
        }
        float mouse_X = Input.GetAxis("Mouse X");

        transform.eulerAngles = new Vector3(0, mx, 0);
    }
    
}
