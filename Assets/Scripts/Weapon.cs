using UnityEngine;

[CreateAssetMenu (fileName = "Weapon", menuName = "ScriptableObject/Weapon", order = 1)]
public class Weapon : ScriptableObject
{
    [SerializeField] float weaponRange;
    [SerializeField] float weaponDamage;
    [SerializeField] float magazineCapacity;
    [SerializeField] float maxAmmo;
    void Start()
    {
        
    }

    
    void Update()
    {
        
    }
}
