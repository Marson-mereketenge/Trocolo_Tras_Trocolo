using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UIElements;
using UnityEngine.Video;

[RequireComponent(typeof(NavMeshAgent))]
public class EnemyAI_Revision : MonoBehaviour
{
    [SerializeField] float visionRange = 15f;
    [SerializeField] float attackRange = 3.5f;
    [SerializeField] float stoppingMargin = 0.5f;
    [SerializeField] float moveWait = 0.25f;
    Shoting_Mechanics_Revision shoot;
    ClickToMove_Revision clickToMove;

    Unit unit;
    NavMeshAgent agent;

    /*private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        unit = GetComponent<Unit>();
        if (agent == null)
        {
            Debug.LogError("NavMeshAgent requerido para la IA");
        }
    }
    void Update()
    {
        if (unit.isFriendly) //compruebo que la IA es enemiga
        {
            return;
        }
        if (TurnManager.Instance.isFriendlyTurn) // compruebo que no sea el turno del jugador unit.hasActed = true
        {
            return;
        }
        if (!unit.hasActed) //si es el turno del enemigo y este no ha actuado
        {
            StartCoroutine(DoEnemyTurn());
        }
    }

    IEnumerator DoEnemyTurn(List<Unit> friendlies)
    {
        if (unit == null)
        {
            yield break;
        }
        
        Unit target = FindClosestFriendlyUnit(friendlies);// Busacar la friendly unit más cercana
        if (target == null) 
        {
            Debug.Log("No hay enemigos para la IA cerca");
            unit.FinishAction();
            yield break;
        }
        
        float distToTarget = Vector3.Distance(transform.position, target.transform.position);
        bool hasLoS = HasLineOfSight(target.gameObject, Mathf.Max(visionRange, attackRange));
        if (distToTarget <= attackRange && hasLoS)// si está en rango de ataque y tiene linea de vision, entonces ataca
        {
            AttackTarget(target);
            yield break;
        }
        else// mover a una posicion que se encuentre a rango de ataque
        {
            Vector3 desiredPos = CalculateRangePosition(target.transform.position, attackRange - stoppingMargin);
            yield return MoveTowardsEnemy(desiredPos);

            yield return new WaitForSeconds(moveWait);// mini espera y recalcular

            distToTarget = Vector3.Distance(transform.position, target.transform.position);
            hasLoS = HasLineOfSight(target.gameObject, attackRange);
            if (distToTarget <= attackRange && hasLoS)
            {
                AttackTarget(target);
                yield break;
            }
            else //si no puede hacer nada por lo que sea, que cosuma la acción
            {
                unit.FinishAction();
                yield break;
            }
        }
    }
    private Unit FindClosestFriendlyUnit(List<Unit> friendlies)
    {
        Unit bestOption = null;
        float bestDist = float.MaxValue;
        foreach (var frnd in friendlies)
        {
            if (frnd == null || !frnd.isFriendly)
            {
                continue;
            }

            float obDist = Vector3.Distance (transform.position, frnd.transform.position);
            if (obDist < bestDist && obDist <= visionRange) 
            {
                bestOption = frnd;
                bestDist = obDist;
            }
        }
        return bestOption;
    }
    private bool HasLineOfSight(GameObject target, float v)
    {
        return shoot.IsOnLoS(target, attackRange);
    }
    private Vector3 CalculateRangePosition(Vector3 targetPosition, float desiredDistance)
    {
        Vector3 dir = (transform.position - targetPosition);
        dir.y = 0;
        if (dir.sqrMagnitude < 0.01f)
        {
            dir = -transform.forward;
        }
        dir.Normalize();
        return targetPosition + dir * Mathf.Abs(desiredDistance);
    }
    IEnumerator MoveTowardsEnemy(Vector3 Pos)
    {
        return clickToMove.MoveAndEnd(Pos);
    }
    private void AttackTarget(Unit target)
    {
        throw new NotImplementedException();
        //return unit.Atack();
    }*/
}
