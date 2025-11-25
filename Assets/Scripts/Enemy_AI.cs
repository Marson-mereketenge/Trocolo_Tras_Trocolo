using System;
using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Unit))]
[RequireComponent(typeof(Shoting_Mechanics))]
public class Enemy_AI : MonoBehaviour
{
    private Unit unit;
    private Shoting_Mechanics shoting;
    [SerializeField]private float visionRange = 15f;
    private float attackRange;

    void Start()
    {
        
    }
    void Awake() 
    {
        unit = GetComponent<Unit>();
        shoting = GetComponent<Shoting_Mechanics>();
    }
    void Update()
    {
        if (unit.isFriendly) //compruebo que la IA es anemiga
        {
            return;
        }
        if (TurnManager.Instance.isFriendlyTurn) // compruebo que no sea el turno del jugador
        {
            return;
        }
        if (!unit.hasActed) //si es el turno del enemigo y este no ha actuado
        {
            StartCoroutine(DoEnemyTurn());
        }
    }
    IEnumerator DoEnemyTurn() 
    {
        //1. buscar al FriendlyCharacter más cercano para atacarle
        Unit target = FindClosestFriendlyUnit();
        
        if (target == null)// Si la IA no tiene enemigos, salta turno 
        {
            Debug.Log(unit.characterName + "no ncesita chambear");
            unit.FinishAction();
            yield break;
        }

        //2. comprobamos si está en la linea de vision de ataque y le ataco
        float distToTarget = Vector3.Distance(transform.position, target.transform.position);

        if (distToTarget <= attackRange && haslineOfSight(target))
        {
            Debug.Log("Te meto un puño");
            yield return AttackTarget(target);
        }

    }

    IEnumerator AttackTarget(Unit target)
    {
        throw new NotImplementedException();
    }

    private bool haslineOfSight(Unit target) //calculamos si nuestra IA tiene linea de accion directa con su enemigo
    {
        throw new NotImplementedException();
    }

    private Unit/*aqui Unit quiere decir el tipo de cosa que estamos devolviendo*/ FindClosestFriendlyUnit() //calcula y devuelve que unidad es la más cercana para atacarla
    {
        Unit closest = null;
        float closestDistance = Mathf.Infinity;

        foreach(Unit friendlyUnit in TurnManager.Instance.friendlyUnits)
        {
            float dist = Vector3.Distance(transform.position, friendlyUnit.transform.position);
            if (dist < closestDistance && dist <= visionRange)
            {
                closestDistance = dist;
                closest = friendlyUnit;
            }
        }
        return closest;
    }
}
