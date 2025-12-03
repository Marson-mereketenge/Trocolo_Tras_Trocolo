using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class EnemyAI_Revision : MonoBehaviour
{
    [SerializeField] float visionRange = 15f;
    [SerializeField] float attackRange = 3.5f;
    [SerializeField] float stoppingMargin = 0.5f;
    [SerializeField] float moveWait = 0.25f;

    Unit unit;
    NavMeshAgent agent;

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        unit = GetComponent<Unit>();
        if (agent == null)
        {
            Debug.LogError("NavMeshAgent requerido para la IA");
        }
    }
}
