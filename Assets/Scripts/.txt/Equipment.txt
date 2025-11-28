using UnityEngine;

[CreateAssetMenu (fileName = "Equipment", menuName = "ScriptableObject/Equipment", order = 2)]
public class Equipment : ScriptableObject
{
    [SerializeField] float maxDurability;
    [SerializeField] float currentDurability;
    [SerializeField] float movementReduction;
    [SerializeField] float Armor;
    

}
