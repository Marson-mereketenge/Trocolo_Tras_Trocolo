using UnityEngine;

public class Target_Selection_Atack : MonoBehaviour
{
    [SerializeField] GameObject Target_1;
    [SerializeField] GameObject Target_2;
    [SerializeField] GameObject characterShooting;
    Shoting_Mechanics shoot;
    [SerializeField] Weapon weapon;
    private void Awake()
    {
        shoot = GetComponent<Shoting_Mechanics>();
    }
    public void ShootTarget1()
    {
        if (Target_1 = null)
        {
            Debug.Log ("El enemigo objetivo 1 no está asignado");
        }
        shoot.Shoot(Target_1.transform.position, weapon.range);
    }
    public void ShootTarget2()
    {
        if (Target_2 = null)
        {
            Debug.Log ("El enemigo objetivo 2 no está asignado");
        }
        shoot.Shoot(Target_2.transform.position, weapon.range);
    }
}
