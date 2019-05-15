using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public GameObject tut;
    public void GameStart()
    {
        SceneManager.LoadScene("MainScene");
        Time.timeScale = 1f;
    }
    public void GameQuit()
    {
        Application.Quit();
    }
    public void Tutorial()
    {
        tut.SetActive(true);
    }
}
