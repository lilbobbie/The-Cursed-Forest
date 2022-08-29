using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Wave
{
    public string name;

    public List<Transform> enemy;

    public int count;

    public float rate;
}

public class WaveSpawner : MonoBehaviour
{
    public enum SpawnState
    {
        Spawning,
        Waiting,
        Counting,
        Finished
    }

    public Wave[] waves;
    private int nextWave = 0;

    public Transform[] spawnPoints;

    public float timeBetweenWaves = 20f;
    private float waveCountdown;

    private float searchCountdown = 1f;

    private SpawnState state = SpawnState.Counting;

    private void Start()
    {
        waveCountdown = timeBetweenWaves;
    }

    private void Update()
    {
        if(state == SpawnState.Waiting)
        {
            // Check if enemies are still alive
            if (!EnemyIsAlive())
            {
                // Begin a new round
                WaveCompleted();
            }
            else
            {
                return;
            }
        }

        if(state == SpawnState.Finished)
        {
            GameManager.Instance.UpdateGameState(GameState.Victory);
        }

        if(waveCountdown <= 0 && state != SpawnState.Spawning && state != SpawnState.Finished)
        {
            //Start spawning wave
            GameManager.Instance.UpdateGameState(GameState.Play);
            StartCoroutine(SpawnWave(waves[nextWave]));
        }
        else
        {
            waveCountdown -= Time.deltaTime;
        }
    }

    IEnumerator SpawnWave(Wave _wave)
    {
        Debug.Log("Spawniing Wave: " + _wave.name);
        state = SpawnState.Spawning;

        //Spawn
        for (int i = 0; i < _wave.count; i++)

        {

            SpawnEnemy(_wave.enemy[Random.Range(0, _wave.enemy.Count)]); // replace the "4" with the number of enemies in your array

            yield return new WaitForSeconds(1f / _wave.rate);

        }


        state = SpawnState.Waiting;

        yield break;
    }

    bool EnemyIsAlive()
    {
        searchCountdown -= Time.deltaTime;
        if(searchCountdown <= 0f)
        {
            searchCountdown = 1f;
            if (GameObject.FindGameObjectsWithTag("Enemy").Length == 0)
            {
                return false;
            }
        }
        return true;
    }

    void SpawnEnemy(Transform _enemy)
    {
        //Spawn enemy
        _enemy.GetComponentInChildren<Canvas>().worldCamera = Camera.main;
        Transform _sp = spawnPoints[Random.Range(0, spawnPoints.Length)];
        Instantiate(_enemy, _sp.position, _sp.rotation);
        Debug.Log("Spawning enemy: " + _enemy.name);
    }

    void WaveCompleted()
    {
        Debug.Log("Wave Completed");
        GameManager.Instance.UpdateGameState(GameState.Shop);
        state = SpawnState.Counting;
        waveCountdown = timeBetweenWaves;

        if(nextWave + 1 > waves.Length - 1)
        {
            state = SpawnState.Finished;
        }
        else
        {
            nextWave++;
        }

    }
}
