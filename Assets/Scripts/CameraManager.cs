using UnityEngine;
using UnityEngine.InputSystem;

public class CameraDrag : MonoBehaviour
{
    private Vector3 origin;
    private Vector3 difference;

    //MOUSE SCROLL VARIABLES
    private float targetFOV = 50;
    [SerializeField] private float zoomMin = 10f;
    [SerializeField] private float zoomMax = 35f;
    [SerializeField] private float zoomSpeed = 35f;

    private Camera mainCamera;
    private bool isDragging;

    private void Awake()
    {
        mainCamera = Camera.main;

    }

    private void Update()
    {
        MouseScroll();
    }

    public void OnDrag(InputAction.CallbackContext ctx)
    {
        if (ctx.started)
        {
            origin = GetMousePosition();
        }
        isDragging = ctx.started || ctx.performed;
    }

    private void LateUpdate()
    {
        if (!isDragging) return;

        difference = GetMousePosition() - transform.position;
        transform.position = origin - difference;
    }

    private Vector3 GetMousePosition()
    {
        Vector3 MousePos = Mouse.current.position.ReadValue();
        MousePos.z = 24;
        return mainCamera.ScreenToWorldPoint(MousePos);

    }

    private void MouseScroll()
    {
        Debug.Log(Input.mouseScrollDelta.y);

        if (Input.mouseScrollDelta.y > 0)
        {
            targetFOV -= 5f;
        }

        if(Input.mouseScrollDelta.y < 0)
        {
            targetFOV += 5f;
        }

        targetFOV = Mathf.Clamp(targetFOV, zoomMin, zoomMax);

        mainCamera.fieldOfView = Mathf.Lerp(mainCamera.fieldOfView, targetFOV, Time.deltaTime * zoomSpeed);

    }

}
