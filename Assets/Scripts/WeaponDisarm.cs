using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponDisarm : MonoBehaviour
{
    // Start is called before the first frame update
    public void DisarmWeapon(){
        GameObject.Find("Bow").transform.SetParent(GameObject.Find("WeaponDisarmPoint").transform, true);
    }
}
