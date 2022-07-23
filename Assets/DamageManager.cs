using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageManager : MonoBehaviour
{
    public int DamageCount = 10;

    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.tag == "EnemyWeapon")
            PlayerManager.Damage(DamageCount);
    }
}
