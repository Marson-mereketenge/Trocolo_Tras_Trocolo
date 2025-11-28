using System;
using System.Collections;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(Unit))]
[RequireComponent(typeof(Shoting_Mechanics))]
public class Enemy_AI : MonoBehaviour
{
    private Unit unit;
    private Shoting_Mechanics shoting;
    [SerializeField]private float visionRange = 15f;
    private float attackRange;
    NavMeshAgent agent;
    void Awake() 
    {
        agent = GetComponent<NavMeshAgent>();
        unit = GetComponent<Unit>();
        shoting = GetComponent<Shoting_Mechanics>();
    }
    void Update()
    {
        if (unit.isFriendly) //compruebo que la IA es anemiga
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
    IEnumerator DoEnemyTurn() 
    {
        //1. buscar al FriendlyCharacter más cercano para atacarle
        Unit target = FindClosestFriendlyUnit();
        
        /*if (target == null)// Si la IA no tiene enemigos, salta turno 
        {
            Debug.Log(unit.characterName + "no ncesita chambear");
            unit.FinishAction();
            yield break;
        }*/

        //2. comprobamos si está en la linea de vision de ataque y le ataco
        float distToTarget = Vector3.Distance(transform.position, target.transform.position);

        if (distToTarget <= attackRange && haslineOfSight(target))
        {
            Debug.Log("Te meto un puño");
            yield return AttackTarget(target);
        }
        else //3. Muevo al personaje para que este cerca para atacar o dentro de la linea de vision
        {
            yield return MovesTowardsTarget(target.transform.position);

            //4.Vuelvo  a disparar al personaje
            distToTarget = Vector3.Distance(transform.position, target.transform.position);
            if (distToTarget <= attackRange && !haslineOfSight(target))
            { 
                yield return AttackTarget(target);
            }
        }

    }

    
    private bool haslineOfSight(Unit target) //calculamos si nuestra IA tiene linea de accion directa con su enemigo
    {
        return shoting.IsOnLoS(target.transform.position, attackRange);
    }
    IEnumerator AttackTarget(Unit target)
    {
        Debug.Log(unit.characterName + "se está liando a piñas con" + target.characterName);

        Vector3 lookDirection = target.transform.position - transform.position;
        lookDirection.y = 0;
        if (lookDirection != Vector3.zero)//rota al enemigo en la dirección en la que esté el FriendlyCharacter
        {
            transform.rotation = Quaternion.LookRotation(lookDirection);
        }

        shoting.Shoot(transform.position, attackRange);
        unit.hasActed = true;

        yield return new WaitForSeconds(1f); //Espera 1 segundo para simular el ataque.
    }
    private IEnumerator MovesTowardsTarget(Vector3 targetPosition)
    {
        Debug.Log(unit.characterName + "está sambeando do Brasil hacia el enemigo");

        agent.destination = targetPosition;
        yield return new WaitForSeconds(5); //Espera 5 segundo para simular el movimiento.
        unit.FinishMovement();
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
