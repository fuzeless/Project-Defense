using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    public static bool isGameEnded;
    public GameObject gameOverUI;

    private void Start()
    {
        isGameEnded = false;
    }

    private void Update()
    {
        if (isGameEnded) return;
        if (Input.GetKeyDown("e"))
        {
            isGameEnded = true;
            initGameEnd();
        }
        if (Stats.lives <= 0)
        {
            isGameEnded = true;
            initGameEnd();
        }
    }

    void initGameEnd()
    {
        gameOverUI.SetActive(true);
    }
}
