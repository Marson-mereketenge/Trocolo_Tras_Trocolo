using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class Target_Selection_Atack_Revision : MonoBehaviour
{
    [Header("Refs")]
    [SerializeField] Weapon weapon;
    [SerializeField] Shoting_Mechanics_Revision shooter;
    [SerializeField] GameObject[] targetButtons;
    private void Awake()
    {
        if (shooter == null) // si vemos que no tiene relación con el script Shooting_Mechanics busca en los padres del objeto
        {
            shooter = GetComponentInParent<Shoting_Mechanics_Revision>();
        }
        if (weapon == null)
        {
            Debug.Log("Weapon no asignada en este script, CUIDAO");
        }
    }
    private void ShootAt(GameObject target)// llamamos al boton de la UI y recibimos el GObj real
    {
        if (shooter == null || weapon == null)
        {
            Debug.Log("CUIDADO aweapon o shooter no asignados");
        }

        shooter.Shoot(target, weapon.range, weapon.damage);// toma estos valores del weapon

        this.gameObject.SetActive(false);// oculta la UI en caso de ser necesario
    }
    private void Start(int indx) //con esto vamos a buscar las referencias de los botones
    {
        if (indx >= 0 && indx < targetButtons.Length)
        {
            ShootAt(targetButtons[indx]);
        }
    }
}
