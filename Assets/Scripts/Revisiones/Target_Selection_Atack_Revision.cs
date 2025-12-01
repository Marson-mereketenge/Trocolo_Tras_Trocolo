using UnityEngine;

public class Target_Selection_Atack_Revision : MonoBehaviour
{
    [Header ("Refs")]
    [SerializeField] Weapon weapon;
    [SerializeField] Shoting_Mechanics shooter;
    [SerializeField] GameObject[] targetButtons;
    private void Awake()
    {
        if (shooter == null) // si vemos que no tiene relación con el script Shooting_Mechanics busca en los padres del objeto
        { 
            shooter = GetComponentInParent<Shoting_Mechanics>();
        }
        if (weapon == null)
        {
            Debug.Log("Weapon no asignada en este script, CUIDAO");
        }
    }
}
