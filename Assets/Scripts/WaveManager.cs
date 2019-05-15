using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaveManager : MonoBehaviour
{
    public float timeBetweenWaves = 5f;
    public float timer;
    public Transform enemy;
    private int waveCounts=0;
    public Text timerText, waveCountText;

    void Start()
    {
        timer = timeBetweenWaves;
    }

    void spawnEnemy()
    {
        Instantiate(enemy, spawnPoint.points[0].position, spawnPoint.points[0].rotation);
    }

    IEnumerator spawnNewWave()
    {
        Debug.Log("New wave...");
        for (int i = 0; i <= waveCounts; i++)
        {
            spawnEnemy();
            yield return new WaitForSeconds(0.25f);
        }

    }

    void Update()
    {
        timer -= Time.deltaTime;
        timerText.text = Mathf.Ceil(timer).ToString();
        waveCountText.text = "Wave: " + (waveCounts).ToString();
        if (timer<=0f)
        {
            StartCoroutine(spawnNewWave());
            waveCounts++;
            Stats.rounds++;
            timeBetweenWaves += 1;
            timer = timeBetweenWaves;
        }
        
    }
}
