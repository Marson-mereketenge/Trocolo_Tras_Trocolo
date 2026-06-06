using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Character : Character
{
    Weapon equipedWeapon;
    Equipment equipedEquipment;
    [SerializeField] List<Weapon> weaponList = new List<Weapon>();
    [SerializeField] List<Equipment> equipmentList = new List<Equipment>();
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
