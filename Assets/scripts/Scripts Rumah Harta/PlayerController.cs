using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LittleDog
{
    [RequireComponent(typeof(CharacterController))]
    public class PlayerController : MonoBehaviour
    {
        private CharacterController characterController;

        [Header("Movement")]
        public float PlayerSpeed = 12f;

        [Header("Joystick")]
        public FixedJoystick joystick;

        public static bool canMove = true;

        // Total harta
        public int totalMoney = 0;

        void Start()
        {
            characterController = GetComponent<CharacterController>();
            MouseControl();
        }

        void Update()
        {
#if UNITY_EDITOR || UNITY_STANDALONE
            // Tombol ESC hanya untuk PC
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                canMove = !canMove;
                MouseControl();
            }
#endif

            if (!canMove)
                return;

            float X = 0f;
            float Z = 0f;

#if UNITY_EDITOR || UNITY_STANDALONE
            // Input Keyboard
            X = Input.GetAxis("Horizontal");
            Z = Input.GetAxis("Vertical");
#endif

            // Input Joystick
            if (joystick != null)
            {
                X += joystick.Horizontal;
                Z += joystick.Vertical;
            }

            X = Mathf.Clamp(X, -1f, 1f);
            Z = Mathf.Clamp(Z, -1f, 1f);

            Vector3 move = transform.right * X + transform.forward * Z;

            characterController.Move(move * PlayerSpeed * Time.deltaTime);
        }

        public void MouseControl()
        {
#if UNITY_EDITOR || UNITY_STANDALONE
            if (!canMove)
            {
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
            }
            else
            {
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
            }
#endif
        }
    }
}