using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class DamageManager : MonoBehaviour
{
    public int DamageCount = 10;
    private int _health;
    private bool gameOver;
    public TextMeshProUGUI text;
    void Start()
    {
        _health = 100;
        gameOver = false;
    }

    public void Damage(int DamageCount){
        _health -= DamageCount;
        text.text = "" + _health;
        if(_health <= 0)
            SceneManager.LoadScene("SampleScene");

    }

    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.tag == "EnemyWeapon")
            Damage(DamageCount);
    }
}
