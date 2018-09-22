using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Actions.Player;
using Actions.Camera;
namespace Actions.InputManager
{

    public class InputManager : MonoBehaviour
    {

        PlayerController player;
        FollowCamera followCamera;
        float horizontalAngle = 0;
        float rotAngle = 180f;
        float verticalAngle = 10f;

        [SerializeField]
        private float xMouseSensitivity;
        [SerializeField]
        private float yMouseSensitivity;


        private void Start()
        {
            player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
            followCamera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<FollowCamera>();
        }

        void Update()
        {
            MoveInput();
            MouseRotation();
            OnClickedMouse();
        }

        void MoveInput()
        {
            Vector2 input = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
            player.MoveInput = input;

        }
        void MouseRotation()
        {
            Vector3 delta = new Vector3(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y"), 0);
            float anglePerPixel = rotAngle / Screen.width;
            horizontalAngle += delta.x * anglePerPixel * xMouseSensitivity;
            horizontalAngle = Mathf.Repeat(horizontalAngle, 360f);
            verticalAngle += delta.y * anglePerPixel * yMouseSensitivity;
            verticalAngle = Mathf.Clamp(verticalAngle, -60, 60);
            followCamera.horizontalAngle = horizontalAngle;
            player.horizontalAngle = horizontalAngle;
            followCamera.verticalAngle = verticalAngle;
        }

        void OnClickedMouse()
        {
            if (Input.GetKeyDown(KeyCode.Mouse0))
                player.Attack();
        }
    }
}