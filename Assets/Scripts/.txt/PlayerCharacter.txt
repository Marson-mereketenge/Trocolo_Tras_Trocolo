using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCharacter : Character
{
    float experience;
    Weapon equipedWeapon;
    Equipment equipedEquipment;
    [SerializeField] List<Weapon> weaponList = new List<Weapon>();
    [SerializeField] List<Equipment> equipmentList = new List<Equipment>();
    void Start()
    {
        equipedWeapon = weaponList[0];
        equipedEquipment = equipmentList[0];
    }
    
    void Update()
    {
        
    }
    void EarnExperience(float xpGain)
    { 
        experience += xpGain;
    }

    void LevelUp()
    {
        level++;
    }
}
