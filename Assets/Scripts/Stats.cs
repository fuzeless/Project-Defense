using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Stats : MonoBehaviour
{
    public int initCash = 200;
    public static int cash;
    public int initLives = 10;
    public static int lives;
    public static int rounds;
    public Text cashText, livesText;

    // Start is called before the first frame update
    void Start()
    {
        cash = initCash;
        lives = initLives;
        rounds = 0;
    }

    // Update is called once per frame
    void Update()
    {
        cashText.text = "$" + cash.ToString();
        livesText.text = "Lives: " + lives.ToString();
    }
}
