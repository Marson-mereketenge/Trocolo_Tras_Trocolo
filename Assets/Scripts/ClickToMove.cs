using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
[RequireComponent(typeof(NavMeshAgent))]
public class ClickToMove : MonoBehaviour
{
    Rigidbody rb;
    Vector3 destination;
    [SerializeField] public Transform destinoDumie;
    NavMeshAgent agent;
    Animator animator;
    void OnEnable()
    {
        rb = GetComponent<Rigidbody>();
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();

        agent.updatePosition = false;
        if (agent == null) Debug.LogError("NavMeshAgent requerido en ClickToMove");
    }
    void Update()
    {
    
        
        if (Input.GetMouseButtonDown(1))
        {
 
            HandleCkick();
            Unit unit = GetComponent<Unit>();
            unit.FinishMovement();
        }
        animator.SetFloat("ForwardMovement", agent.velocity.magnitude);
    }

    private void HandleCkick()
    {
        RaycastHit hit;
        if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 100f))
        {
            destinoDumie.position = hit.point;
            agent.destination = destinoDumie.position;
        }
    }
    private void OnAnimatorMove()
    {
        Vector3 position = animator.rootPosition;
        position.y = agent.nextPosition.y;
        transform.position = position;
        agent.nextPosition = transform.position;
    }
}
