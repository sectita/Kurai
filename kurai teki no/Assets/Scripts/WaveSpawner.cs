using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{
    //
    public float lineOfSite;
    private Transform playerRange;
    //
    public enum SpawnState { SPAWNING, WAITING, COUNTING };

    [System.Serializable]
    public class Wave
    {
        public string name;
        public Transform enemy;
        public int count;
        public float rate;

    }
    public Wave[] waves;
    private int nextWave = 0;

    public Transform[] spawnPoints;

    public float timeBtwWaves = 3f;
    private float waveCountdown;
    private float searchCoutDown = 1f;

    private SpawnState state = SpawnState.COUNTING;

    void Start()
    {
        playerRange = GameObject.FindGameObjectWithTag("Player").transform;
        
        if (spawnPoints.Length == 0)
        {
            Debug.LogError("No spawn points referenced.");
        }
        waveCountdown = timeBtwWaves;
    }
    void Update()
    {
        
        if (state == SpawnState.WAITING)
        {
            //check enemies still alive
            if(!EnemyIsAlive() == false)
            {
                //begin new round
                WaveCompleted();
                
                return;
            }
            else
            {
                
                return;
            }

        }

        if(waveCountdown <= 0)
        {
            if(state != SpawnState.SPAWNING)
            {
                //start spawning
                
                StartCoroutine( SpawnWave (waves[nextWave]) );
            }
        }
        else
        {
            waveCountdown -= Time.deltaTime;
        }
    }

    void WaveCompleted()
    {
        Debug.Log("Wave Completed:");

        state = SpawnState.COUNTING;
        waveCountdown = timeBtwWaves;

        if(nextWave + 1 > waves.Length - 1)

        {
            
            nextWave = 0;
            Debug.Log("completed all waves looping.."); // game end state
        }
        else
        {
            
            nextWave++;
        }

    }

    bool EnemyIsAlive()
    {
        searchCoutDown -= Time.deltaTime;
        if(searchCoutDown <= 0f)
        {
            searchCoutDown = 1f;
            if(GameObject.FindGameObjectsWithTag("Enemy").Length == 0) //GameObject.FindGameObjectWithTag("Enemy") == null
            {
                
                return false;
            }
        }
         return true;
    }
    IEnumerator SpawnWave( Wave _wave)
    {
        
        Debug.Log("SpawningWave:" + _wave.name);
        state = SpawnState.SPAWNING;

        for(int i = 0; i < _wave.count; i++)
        {
            SpawnEnemy(_wave.enemy);
            
            yield return new WaitForSeconds(1f / _wave.rate);
        }
        //spawn
        state = SpawnState.WAITING;
        
        yield break;
    }

    void SpawnEnemy (Transform _enemy)
    {
        //spawn enemy
        Debug.Log("SpawningEnemy:" + _enemy.name);

        
        Transform _sp = spawnPoints[Random.Range(0, spawnPoints.Length)];
        float distanceFromPlayer = Vector2.Distance(playerRange.position, _sp.position);
        if (distanceFromPlayer < lineOfSite)
        {
            
            Instantiate(_enemy, _sp.position, _sp.rotation);
        }
    }

    //void GizmosFun()
    //{
    //    Transform _spLine = spawnPoints[Random.Range(0, spawnPoints.Length)];
    //    float distanceFromPlayer = Vector2.Distance(playerRange.position, _spLine.position);
    //    if (distanceFromPlayer < lineOfSite)
    //    {
    //        for (int i = 0; i < spawnPoints.Length; i++)
    //        {
    //            //spawners[i].GetComponent<GameObject>().SetActive(true);
    //        }
    //    }
    //    else if (distanceFromPlayer > lineOfSite)
    //    {
    //        for (int i = 0; i < spawnPoints.Length; i++)
    //        {
    //            //spawners[i].GetComponent<GameObject>().SetActive(false);
    //        }
    //    }
    //}

    public void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Transform _spLine = spawnPoints[Random.Range(0, spawnPoints.Length)];
        Gizmos.DrawWireSphere(_spLine.position, lineOfSite);
    }
}
