using UnityEngine;
using UnityEngine.AI;

public class AnimateCharacter : MonoBehaviour
{
    [SerializeField] Animator animator;

    //public bool test = false;
    NavMeshAgent agent;

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        animator.SetBool("Moving", agent.velocity.magnitude > 0.1f);
        //animator.SetBool("Moving", test);
    }
}
