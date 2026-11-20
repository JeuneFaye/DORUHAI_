using UnityEngine;

public class MouseObjectClick : MonoBehaviour
{
    public Camera mainCamera;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousePosition = Input.mousePosition;
            Ray ray = mainCamera.ScreenPointToRay(mousePosition);

            RaycastHit hit;

            bool selectedObject = Physics.Raycast(ray, out hit);

            if (selectedObject)
            {
                Debug.Log($"The object {hit.transform.name} is selected.");
            }
        }
    }
}
