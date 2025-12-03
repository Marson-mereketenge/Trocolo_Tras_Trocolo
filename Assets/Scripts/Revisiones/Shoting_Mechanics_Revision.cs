using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class Shoting_Mechanics_Revision: MonoBehaviour
{
    [SerializeField] ParticleSystem particles;
    [SerializeField] float shootDelay = 0.15f; //cantidad de retardo para playear las vfx
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
    public void Shoot(GameObject target, float weaponRange, float damageAmount)
    {
        if (target == null)
        {
            Debug.LogWarning("Null target");
            return;
        }
        Vector3 targetPos = target.transform.position; //esta variable la va a usar el script de la IA del enemigo para poder ejecutar el ataque

        if (!IsOnLoS(target, weaponRange))
        {
            particles.Play();
            Debug.Log($"{name}: objetivo fuera de linea de tiro");
            return;

        }
        StartCoroutine(ShootingRoutine(target, damageAmount));
    }

    IEnumerator ShootingRoutine(GameObject target, float damageAmount)
    {
        if (particles != null) 
        {
            particles.Play();
        }
        yield return new WaitForSeconds(shootDelay); //aplica la cantidad de retardo para efectuar las vfx
        
        Character chr = target.GetComponent<Character>();
        if (chr != null) 
        {
            chr.TakeDamage(damageAmount);
        }

        if (unit != null)
        {
            unit.FinishAction();
        }
    }

    public bool IsOnLoS(GameObject target, float weaponRange) //Comprueba que el raycast es correcto (dirección rango y hit correspondientes al objetivo)
    {
        if (target == null)
        {
            return false;
        }
        Vector3 origin = transform.position + Vector3.up * 0.5f; /*con esto elevamos la posición de la linea de tiro para no dar en
        el suelo, en este caso Vector3.up = new Vector3 (0,1,0) (solo elevamos en el eje y) y es un vector normalizado*/
        Vector3 direction = (target.transform.position - origin); //vector de direccion que vamos a usar para el raycast
        float distance = direction.magnitude;
        if (distance > weaponRange) // si la distancia es mayor que el el rango del arma, no tiene linea de tiro 
        {
            return false;
        }
        direction.Normalize();// pa normalizar el vector resultante que he llamado dirección pq no sabía que nombre ponerle

        RaycastHit hit;
        if (Physics.Raycast(transform.position, direction, out hit, weaponRange))
        {
            if (hit.collider != null && (hit.collider.gameObject == target)) //si el primer objetivo del raycast es el target, tiene LoS 
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        return false;
    }
}
