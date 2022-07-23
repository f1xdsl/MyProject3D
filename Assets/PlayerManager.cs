using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
public class PlayerManager : MonoBehaviour
{
    private static int _health;
    private static bool gameOver;
    public static TextMeshProUGUI text;
    void Start()
    {
        _health = 100;
        gameOver = false;
    }

    public static void Damage(int DamageCount){
        _health -= DamageCount;
        text.text = "" + _health;
        if(_health <= 0)
            SceneManager.LoadScene("SampleScene");

    }
}
