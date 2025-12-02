using UnityEngine;

[CreateAssetMenu (fileName = "Weapon", menuName = "ScriptableObject/Weapon", order = 1)]
public class Weapon : ScriptableObject
{
    [SerializeField] public float range;
    [SerializeField] public float damage;
    [SerializeField] public float magazineCapacity;
    [SerializeField] public float maxAmmo;
    void Start()
    {
        
    }

    
    void Update()
    {
        
    }
}
