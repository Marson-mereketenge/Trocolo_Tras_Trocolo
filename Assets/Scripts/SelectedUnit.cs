using UnityEngine;

public class SelectedUnit : MonoBehaviour
{
    public static SelectedUnit Instance;
    public Unit selectedUnit;

    private void Awake()
    {
        Instance = this;
    }
    private void Update()
    {
        if (!TurnManager.Instance.isFriendlyTurn)
        {
            return;
        }
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, 100f))
            { 
                Unit unit = hit.collider.GetComponent<Unit>();
                if (unit != null && unit.isFriendly && !unit.hasActed)
                    {
                        SelectUnit(unit);
                    Debug.Log("Estas controlando a:" + unit.name);
                    }
                else
                {
                    DeselectUnit();
                }
            }
        }
    }
    private void SelectUnit(Unit unit)
    {
        selectedUnit = unit;
    }
    private void DeselectUnit()
    {
        if (selectedUnit != null)
        {
            Debug.Log("Ya no tienes el control de:" + selectedUnit.name);
            selectedUnit = null;
        }
    }

}
