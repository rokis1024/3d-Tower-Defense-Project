using System.Collections;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{

    public Transform enemyPrefab;
    public Transform spawner;

    public float waveTimer = 5f;
    public float countDown = 2f;
    public float timeBetweenEnemies = 0.5f;
    private int waveNumber = 1;

    void Update()
    {
        if (countDown <= 0)
        {
            StartCoroutine(SpawnWave());
            countDown = waveTimer;
        }
        else
            countDown -= Time.deltaTime;
    }

    IEnumerator SpawnWave ()
    {
        for (int i = 0; i < waveNumber; i++)
        {
            SpawnEnemy();
            yield return new WaitForSeconds(timeBetweenEnemies);
        }
        waveNumber++;
    }

    void SpawnEnemy()
    {
        Instantiate(enemyPrefab, spawner.position, spawner.rotation);
    }

}
