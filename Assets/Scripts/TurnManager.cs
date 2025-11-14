using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnManager : MonoBehaviour
{
    public static TurnManager Instance;

    [Header("Lista do Unidao")]
    public List<Unit> enemyUnits = new List<Unit>();
    public List<Unit> friendlyUnits = new List<Unit>();
    public bool isFriendlyTurn = true;

    private void Awake()
    {
        Instance = this;
    }
    private void Start()
    {
        FriendlyTurn();
    }
    private void FriendlyTurn() //Inicia el turno de las unidades aliadas.
    {
        isFriendlyTurn = true;
        ResetUnits(friendlyUnits);
        Debug.Log ("He empezado el turno aliado");
    }
    private void EnemyTurn() //Inicia el turno de las unidades enemigas.
    {
        isFriendlyTurn = false;
        ResetUnits(enemyUnits);
        Debug.Log ("He empezado el turno enemigo");
        StartCoroutine(EnemyTurnAutoPass());
    }
    private void ResetUnits(List<Unit> units) //Devuelve a las unidades a sus estado base.
    {
        foreach (Unit unit in units)
        {
            unit.hasActed = false; 
        }
    }
    private bool AllUnitsActed(List<Unit> units) //Se chequea si las unidades de la lista han actuado o no.
    {
        foreach (var itm in units)
        {
            if (!itm.hasActed)
            {
                return false;
            }
        }
        return true;
    }
    public void TurnEnded() //Finaliza el turno de las unidades y cambias a las unidades contrarias.
    {
        if (isFriendlyTurn)
        {
            if(!AllUnitsActed (friendlyUnits))
                EnemyTurn();
        }
        else 
        {
            if (!AllUnitsActed(enemyUnits))
                FriendlyTurn();
        }
    }
    private IEnumerator EnemyTurnAutoPass() //Tras un tiempo determinado pasas del turno enemigo al aliado.
    {
        yield return new WaitForSeconds(3f);
        FriendlyTurn();
    }
}
