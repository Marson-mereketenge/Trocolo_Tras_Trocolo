using System;
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
            StartCoroutine(MoveAndEnd(destinationHit));
        }
    }
    IEnumerator MoveAndEnd(Vector3 destinationHit)
    {
        if (agent == null)
        {
            Debug.Log("Agente no inicializado en ClickToMove");
            yield break;
        }
        agent.isStopped = false;
        agent.SetDestination(destinationHit);

        float timer = 0f;
        while (agent.pathPending && timer < maxMoveWaitTime) //esperamos a que calcule el pathing
        {
            timer += Time.deltaTime;
            yield return null;
        }
        while ((!agent.pathPending) && (agent.remainingDistance > agent.stoppingDistance + arrivalThreshold) 
        && timer < maxMoveWaitTime)
        {
            timer += Time.deltaTime;
            yield return null;
        }
        agent.isStopped = true;// detiene el agente

        if (agent.hasPath == false || agent.remainingDistance <= agent.stoppingDistance + arrivalThreshold)
        {
            if (unit != null)
            {
                unit.FinishMovement();
            }
        }
        else //esto por si no llega o por si se acaba el tiempo de llegada
        {
            Debug.Log($"{name}: no llego al destino");
            if (unit != null)
            {
                unit.FinishMovement();
            }
        }
    }    
}

