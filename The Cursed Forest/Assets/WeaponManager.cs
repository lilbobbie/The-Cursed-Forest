using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Weapon
{
    Staff,
    Sword,
    Spear
}

public class WeaponManager : MonoBehaviour
{
    //Singleton code
    public static WeaponManager Instance;
    private void Awake()
    {
        // If there is an instance, and it's not me, delete myself.

        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }

    //Class code
    public GameObject staff;
    public GameObject sword;
    public GameObject spear;
    private GameObject currentWeapon;


    public void UpdateWeapon(Weapon weapon)
    {
        switch (weapon)
        {
            case Weapon.Staff:
                currentWeapon.SetActive(false);
                staff.SetActive(true);
                currentWeapon = staff;
                break;
            case Weapon.Sword:
                currentWeapon.SetActive(false);
                sword.SetActive(true);
                currentWeapon = sword;
                break;
            case Weapon.Spear:
                currentWeapon.SetActive(false);
                spear.SetActive(true);
                currentWeapon = spear;
                break;
            default:
                break;
        }
    }
    public GameObject GetWeapon()
    {
        return currentWeapon;
    }
}
