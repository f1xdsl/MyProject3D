using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponActions : MonoBehaviour
{
    // Start is called before the first frame update
    Transform weapon;
    Transform wristR;
    Transform weaponPoint;

    private void Awake() {
        weapon = GameObject.Find("Bow").transform;
        wristR = GameObject.Find("Wrist_R").transform;
        weaponPoint = GameObject.Find("WeaponPoint").transform;
    }

    public void DisarmWeapon(){
        weapon.SetParent(weaponPoint, true);
        weapon.localPosition = new Vector3(-0.00208949158f, 0.00815751031f, 0.0512175895f);
        weapon.localEulerAngles = new Vector3(357.647339f, 178.109634f, 189.126587f);
    }
}
