using UnityEngine;
using Unity.VisualScripting;

public class UISelectionTogle : MonoBehaviour
{
    [SerializeField] GameObject[] elementsUIToToggle;
    void Update()
    {
        if (SelectedUnit.Instance.selectedUnit == null)
        {
            deactivateALLUI();
            return;
        }

        var selectedUnit = SelectedUnit.Instance.selectedUnit;
        deactivateALLUI();


        switch (selectedUnit.name)
        {
            case null:
                for (int i = 0; i < elementsUIToToggle.Length; i++)
                {
                    deactivateALLUI();
                }
                break;
            case "Ellen":
                deactivateALLUI();
                if (elementsUIToToggle.Length > 0)
                    elementsUIToToggle[0].SetActive(true);
                break;

            case "Chomper":
                deactivateALLUI();
                if (elementsUIToToggle.Length > 1)
                    elementsUIToToggle[1].SetActive(true);
                break;

            default:
                break;
        }
    }

    void deactivateALLUI()
    {
        for (int i = 0; i < elementsUIToToggle.Length; i++)
        {
            elementsUIToToggle[i].SetActive(false);
        }

    }
}