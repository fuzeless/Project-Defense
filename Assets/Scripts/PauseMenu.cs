using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject ui;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown("p"))
        {
            resume();
        }
    }
    public void Retry()
    {
        SceneManager.LoadScene(1);
    }
    public void resume()
    {
        ui.SetActive(!ui.activeSelf);
        if (ui.activeSelf)
        {
            Time.timeScale = 0f;
        }
        else Time.timeScale = 1f;
    }
    public void Quit()
    {
        SceneManager.LoadScene(0);
    }
}
