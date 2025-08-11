using UnityEngine;
using UnityEngine.InputSystem;

namespace NewInputSystem
{
    public class PlayerController0 : MonoBehaviour
    {
        private CharacterController cc;

        public float speed = 5f;

        private Vector2 moveInput;

        public InputActionAsset inputActionAsset;

        private InputAction jumpAction;
        private InputAction moveAction;
        private InputAction attackAction;
        private InputAction interactionAction;

        private void Start()
        {
            moveAction = InputSystem.actions.FindAction("Move");
            jumpAction = InputSystem.actions.FindAction("Jump");
            interactionAction = InputSystem.actions.FindAction("Interaction");
            attackAction = InputSystem.actions.FindAction("Attack");

            cc = GetComponent<CharacterController>();
        }

        private void Update()
        {
            moveInput = moveAction.ReadValue<Vector2>();

            if (moveInput != Vector2.zero)
            {
                Debug.Log("Move : " + moveAction.ReadValue<Vector2>());

                var dir = new Vector3(moveInput.x, 0, moveInput.y).normalized;

                cc.Move(dir * speed * Time.deltaTime);
            }

            if (jumpAction.WasPressedThisFrame())
            {
                Debug.Log("Jump");
            }

            if (attackAction.IsPressed())
            {
                Debug.Log("Attack");
            }

            if (interactionAction.IsPressed())
            {
                Debug.Log("Interaction");
            }
        }

    }
}