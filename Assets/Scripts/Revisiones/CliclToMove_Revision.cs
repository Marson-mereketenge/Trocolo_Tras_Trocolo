using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
[RequireComponent(typeof(NavMeshAgent))]
public class ClickToMove_Revision : MonoBehaviour
{
    
    [SerializeField] public Transform destinoDumie;
    [SerializeField] float arrivalThreshold = 0.2f;
    [SerializeField] float maxMoveWaitTime = 10f; // seguridad para no quedarse atascado
    NavMeshAgent agent;
    Rigidbody rb;
    Animator animator;
    Unit unit;
    void OnEnable()
    {
        rb = GetComponent<Rigidbody>();
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        unit = GetComponent<Unit>();

        if (agent == null)
        {
            Debug.LogError("NavMeshAgent requerido en ClickToMove");
        }
        if (rb != null)
        {
            rb.isKinematic = true;
        }
        if (agent != null)
        { 
            agent.updatePosition = true; //perminitimos que el navMesh gestione la posición.
        }
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            if (unit == null || !unit.isFriendly || unit.hasActed)
            {
                return;
            }
            HandleCkick();
        }
    }
    private void HandleCkick()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, 100f))
            { 
                Vector3 destinationHit = hit.point;
                if (destinationHit != null)
                {
                    destinoDumie.position = destinationHit;
                }
            /*StartCoroutine(Move(destinationHit));*/
            }
    }
    /*if (Input.GetMouseButtonDown(1))
        {

            HandleCkick();
            Unit unit = GetComponent<Unit>();
            unit.FinishMovement();
        }
        animator.SetFloat("ForwardMovement", agent.velocity.magnitude);*/
    /*private void HandleCkick()
    {
        RaycastHit hit;
        if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 100f))
        {
            destinoDumie.position = hit.point;
            agent.destination = destinoDumie.position;
        }
    }*/
    /*private void OnAnimatorMove()
    {
        Vector3 position = animator.rootPosition;
        position.y = agent.nextPosition.y;
        transform.position = position;
        agent.nextPosition = transform.position;
    }*/

}

