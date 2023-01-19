using Cinemachine;
using UnityEngine;

namespace RPG.Core
{
    public class CameraRotate : MonoBehaviour
    {
        [SerializeField] CinemachineVirtualCamera targetCam;
        [SerializeField] Transform camTarget;

        [SerializeField] float rotationSpeed = 20f;

        void Update()
        {
            if (Input.GetKey(KeyCode.Q) || Input.GetMouseButton(1))
            {
                targetCam.transform.RotateAround(camTarget.transform.position, Vector3.down, rotationSpeed * Time.deltaTime);
                Camera.main.transform.LookAt(camTarget);
            }
            if (Input.GetKey(KeyCode.E))
            {
                targetCam.transform.RotateAround(camTarget.transform.position, Vector3.up, rotationSpeed * Time.deltaTime);
                Camera.main.transform.LookAt(camTarget);
            }
        }
    }
}