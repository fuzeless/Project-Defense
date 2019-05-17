using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
    public void defaultSpeed()
    {
        Time.timeScale = 1f;
    }
    public void doubleSpeed()
    {
        Time.timeScale = 2f;
    }
    public void tripleSpeed()
    {
        Time.timeScale = 3f;
    }

}
