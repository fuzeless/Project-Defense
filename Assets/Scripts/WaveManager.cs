using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaveManager : MonoBehaviour
{
    public static int numOfOnScreenEnemies;
    public float timeBetweenWaves = 5f;
    public float timer;
    //public Transform enemy;
    private int waveCounts=0;
    public Text timerText, waveCountText;
    public WaveProperties[] waves;
    public GameObject gameWinOverlay;

    void Start()
    {
        timer = timeBetweenWaves;
        numOfOnScreenEnemies = 0;
        waveCounts = 0;
    }

    void spawnEnemy(GameObject enemy)
    {
        Instantiate(enemy, spawnPoint.points[0].position, spawnPoint.points[0].rotation);
        numOfOnScreenEnemies++;
    }

    IEnumerator spawnNewWave()
    {

        Stats.rounds++;
        Debug.Log("New wave...");
        WaveProperties wave = waves[waveCounts];
        for (int i = 0; i <= wave.count; i++)
        {
            spawnEnemy(wave.enemy);
            yield return new WaitForSeconds(1f/wave.rate);
        }
        waveCounts++;
    }

    void Update()
    {
        if (numOfOnScreenEnemies > 0)
            return;
        if (waveCounts == waves.Length || Input.GetKeyDown("p"))
        {
            gameWinOverlay.SetActive(true);
            this.enabled = false;
        }
        if (timer<=0f)
        {
            StartCoroutine(spawnNewWave());

            timer = timeBetweenWaves;
            return;
        }
        timer -= Time.deltaTime;
        timerText.text = Mathf.Ceil(timer).ToString();
        waveCountText.text = "Wave: " + (waveCounts).ToString();
    }
}
