/*using Unity.Cinemachine;
using UnityEngine;
using UnityEngine.Rendering;

public class CameraController : MonoBehaviour
{
    Vector3 moveVector = Vector3.zero;

    [SerializeField] float cameraMoveSpeed = 5f;
    [SerializeField] float rotationSpeed = 2f;
    [SerializeField] CinemachineCamera virtualCamera;
    float targetFOV;
    [SerializeField] float minFOV = 35f;
    [SerializeField] float maxFOV = 60f;
    [SerializeField] float zoomSensitivity = 5f;
    Vector3 rotation;

    private void Update()
    {
        CameraMove();
        RotateCamera();
        ZoomCamera();
    }

    private void ZoomCamera()
    {
        targetFOV += Input.mouseScrollDelta.y * zoomSensitivity;
        targetFOV = Mathf.Clamp(targetFOV, minFOV, maxFOV);
        virtualCamera.Lens.FieldOfView = targetFOV;
    }

    private void RotateCamera()
    {
        rotation = Vector3.zero;
        if (Input.GetKey(KeyCode.Q))
        {
            rotation.y = rotationSpeed * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.E))
        {
            rotation.y = -(rotationSpeed * Time.deltaTime);
        }
        transform.eulerAngles += rotation;
    }
    private void CameraMove()
    {
        moveVector.z = Input.GetAxisRaw("Horizontal");
        moveVector.x = Input.GetAxisRaw("Vertical");

        moveVector = transform.right * moveVector.z + transform.forward * moveVector.x;

        transform.position += moveVector * Time.deltaTime * cameraMoveSpeed;
    }
} */
