using UnityEngine;

public class Shoting_Mechanics : MonoBehaviour
{
    [SerializeField] ParticleSystem particles;
    Unit unit;
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
