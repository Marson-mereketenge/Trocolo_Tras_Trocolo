using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class Shoting_Mechanics : MonoBehaviour
{
    [SerializeField] ParticleSystem particles;
    [SerializeField] float shootDelay = 0.15f; //retardo para playear las vfx
    Unit unit;
    private void Awake()
    {
        unit = GetComponent<Unit>();
        if (particles == null)
        {
            Debug.LogWarning($"{name}: particles no asignado en Shoting_Mechanics");
        }
    }

    // Intenta disparar al target. Se valida línea de visión y rango antes de aplicar efecto y notificar a la unidad.
    public void Shoot(Vector3 enemyPosition, float weaponRange)
    {
        if (IsOnLoS(enemyPosition, weaponRange))
        {
            particles.Play();
            Debug.Log("Enemigo en linea de tiro");
            unit.FinishAction();

        }
        else
        {
            Debug.Log("Prueba otra vez");
        }
    }
    public bool IsOnLoS(Vector3 enemyPosition, float weaponRange)
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, enemyPosition, out hit, weaponRange))
        {
            Character character = hit.collider.GetComponent<Character>();
            if (character != null)
            {
                return true;
            }
        }
        return false;
    }
}
