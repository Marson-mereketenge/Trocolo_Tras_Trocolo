using UnityEngine;

public class Unit : MonoBehaviour
{
    [Header ("Propiedade di la Unitad")]
    [SerializeField] public string characterName;

    public bool hasActed = true;
    public bool hasAtacked = false;
    public bool hasMoved = false;
    public bool isFriendly;
    ClickToMove clickTomove;
    Shoting_Mechanics shooting;
    GameObject targetSelection;
    public void Awake()//Esto es pa que no me deje clickar fuera de turno o al darle al play.
    {
        clickTomove = GetComponent<ClickToMove>();
        shooting = GetComponent<Shoting_Mechanics>();
        clickTomove.enabled = false;
    }
    public void Run()
    {
        if (hasMoved || hasActed) //Aquí si uno de los dos ha ocurrido la funcion acaba.
        {
            return;
        }
        if (isFriendly) // Si es una unidad aliada, dejala moverse y cambiale la posición en el momento correcto.
        {
            clickTomove.enabled = true;
            clickTomove.destinoDumie.position = transform.position;
            Debug.Log (characterName + " esta scouting.");
        }
        else 
        {
            Debug.Log(characterName + " esta bailando salsa"); //Um firi fassendo barras
        }
    }
    public void Atack()
    {
        if (hasActed || hasAtacked)
        {
            return;
        }

        if (isFriendly)
        {
            shooting.enabled = true;
            targetSelection.SetActive(true);
        }
        else
        {
            Debug.Log(characterName + " esta liandose a piñas malignas");
        }
        Debug.Log(characterName + " esta liandose a piñas"); 
        FinishAtack();
    }
    public void EndTurn()
    {
        if (hasActed)
        {
            return;
        }
        Debug.Log(characterName + " dice que ya no puede mas");
        FinishAction();
    }
    public void FinishMovement() 
    {
        clickTomove.enabled = false;
        hasMoved = true;
    }
    public void FinishAtack()
    {
        hasAtacked = true;
    }
    public void FinishAction()
    {
        hasActed = true;
        TurnManager.Instance.TurnEnded();
    }
}
