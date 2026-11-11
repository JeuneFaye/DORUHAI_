using UnityEngine;
using UnityEngine.AI;
using TMPro;

public class MoveCharacterInput : MonoBehaviour
{
    [SerializeField] NavMeshAgent agent;
    [SerializeField] Camera mainCamera;

    [SerializeField] TextMeshProUGUI characterName;

    private void Update()
    {
        Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Input.GetMouseButtonDown(0)) 
        {
            if (Physics.Raycast(ray, out hit))
            {
                NavMeshAgent newAgent = hit.transform.GetComponent<NavMeshAgent>();
                if (newAgent != null)
                {
                    agent = newAgent;
                    characterName.text = newAgent.GetComponent<Character>().Name;
                }
            }
        }
        if (Input.GetMouseButtonDown(1))
        {
            Physics.Raycast(ray, out hit);

            agent.destination = hit.point;
        }
    }
}
