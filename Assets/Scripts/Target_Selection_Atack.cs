using UnityEngine;

public class Target_Selection_Atack : MonoBehaviour
{
    [SerializeField] GameObject Target_1;
    [SerializeField] GameObject Target_2;
    [SerializeField] GameObject characterShooting;
    Shoting_Mechanics shoot;
    Weapon weapon;
    private void Awake()
    {
        weapon = GetComponent<Weapon>();
        shoot = GetComponent<Shoting_Mechanics>();
    }
    public void ShootTarget1()
    {
        shoot.Shoot(Target_1.transform.position, weapon.weaponRange);
    }
    public void ShootTarget2()
    {
        shoot.Shoot(Target_2.transform.position, weapon.weaponRange);
    }
}
