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

        //Camera up and down
        Vector3 upAndDownControl = new Vector3(0, 0 , 0);
        if (Input.GetKey(KeyCode.W)) upAndDownControl.y = +1f;
        if (Input.GetKey(KeyCode.S)) upAndDownControl.y = -1f;
        
        Vector3 upAndDown = transform.up * upAndDownControl.y;
        float moveSpeed = 40f;
        transform.position += upAndDownControl * moveSpeed * Time.deltaTime;


        //Camera Rotation
        float cameraRotation = 0f;
        if (Input.GetKey(KeyCode.Q)) cameraRotation = +1f;
        if (Input.GetKey(KeyCode.E)) cameraRotation = -1f;

        float rotationSpeed = 80f;
        transform.eulerAngles += new Vector3(0, cameraRotation * rotationSpeed * Time.deltaTime, 0);
    }

    public void OnDrag(InputAction.CallbackContext ctx)
    {
        if (ctx.started)
        {
            origin = GetMousePosition();
        }
        isDragging = ctx.started || ctx.performed;
    }
    //Dragging function
    private void LateUpdate()
    {
        if (!isDragging) return;

        difference = GetMousePosition() - transform.position;
        transform.position = origin - difference;
    }

    //Mouse position to point and click
    private Vector3 GetMousePosition()
    {
        Vector3 MousePos = Mouse.current.position.ReadValue();
        MousePos.z = 24;
        return mainCamera.ScreenToWorldPoint(MousePos);

    }

    //Scroll reference
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
