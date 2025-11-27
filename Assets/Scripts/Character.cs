using UnityEngine;

public class Character : MonoBehaviour
{
    [Header("Characetr Main")]
    [SerializeField] string characterName;
    protected int level; //"protected" es una variable privada solo para los scripts que no hereden de esta clase
    [Header("Character Stats")]
    float currentHealth;
    [SerializeField] float maxHealth;
    [SerializeField] float baseAtackDMG;
    [SerializeField] protected float armorValue;

    void Start()
    { 
        characterName = gameObject.name;
        currentHealth = maxHealth;
        baseAtackDMG = 10f;
        armorValue = 5f;
    }

    void TakeDamage(float damageAmount)
    {
        float finalDamage = damageAmount - armorValue;
        currentHealth -= damageAmount;
        IsAlive();
    }
    void IsAlive()
    {
        if (currentHealth <= 0)
        {
            Debug.Log(characterName + "ta morto");
            Destroy(gameObject);
        }
    }
}
