using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
public class PlayerManager : MonoBehaviour
{
    private static int _health;
    private static bool gameOver;
    public TextMeshProUGUI text;
    // Start is called before the first frame update
    void Start()
    {
        _health = 100;
        gameOver = false;
    }

    // Update is called once per frame
    void Update()
    {
        text.text = "" + _health;
        if(gameOver)
            SceneManager.LoadScene("SampleScene");

    }

    public static void Damage(int DamageCount){
        _health -= DamageCount;
        if(_health <= 0)
            gameOver = true;

    }
}
