using UnityEngine;

public class Unit : MonoBehaviour
{
    [Header ("Propiedade di la Unitad")]
    [SerializeField] public string characterName;

    public bool hasActed = false;
    public bool hasAtacked = false;
    public bool hasMoved = false;
    public bool isFriendly;
    ClickToMove clickTomove;
    Shoting_Mechanics shooting;
    //GameObject targetSelection; 
    [SerializeField] private Target_Selection_Atack referencia;
    Target_Selection_Atack ShootTarget;
    public void Awake()//Esto es pa que no me deje clickar fuera de turno o al darle al play.
    {
        clickTomove = GetComponent<ClickToMove>();
        shooting = GetComponent<Shoting_Mechanics>();
        clickTomove.enabled = false;
    }
    public void Run()
    {
        if (isFriendly) // Si es una unidad aliada, dejala moverse y cambiale la posici�n en el momento correcto.
        {
            clickTomove.enabled = true;
            clickTomove.destinoDumie.position = transform.position;
            Debug.Log (characterName + " esta scouting.");
        }
        else 
        {
            Debug.Log(characterName + " esta bailando salsa"); //Um firi fassendo barras
        }
        if (hasMoved || hasActed) //Aqu� si uno de los dos ha ocurrido la funcion acaba.
        {
            return;
        }
    }
    /*public void Atack()
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
            Debug.Log(characterName + " esta liandose a pi�as malignas");
        }
        Debug.Log(characterName + " esta liandose a pi�as");
        FinishAtack();
    }*/
    public void AtackObjctive1()
    {
        if (hasActed || hasAtacked)
        {
            return;
        }
        if (isFriendly && referencia != null)
        {
            shooting.enabled = true;
            ShootTarget = ShootTarget1;
        }
        else
        {
            Debug.Log ("Olvidates arrastrar el xcript TSAtack al inspector o la unidad no es Friendly");
        }
        Debug.Log(characterName + " esta liandose a pi�as");
        FinishAtack();
    }
    public void AtackObjctive2()
    {
        if (hasActed || hasAtacked)
        {
            return;
        }
        if (isFriendly && referencia != null)
        {
            shooting.enabled = true;
            ShootTarget = ShootTarget2;
        }
        else
        {
            Debug.Log ("Olvidates arrastrar el xcript TSAtack al inspector o la unidad no es Friendly");
        }
        Debug.Log(characterName + " esta liandose a pi�as");
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
