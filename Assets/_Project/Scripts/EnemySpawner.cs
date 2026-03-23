using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [Header("Enemy Spawn Points")]
    [SerializeField] private Transform[] _spawnPoints;

    [SerializeField] private EnemyPool _enemyPool;

    public void FirstWave()
    {
        SpawnEnemy(2);

        Debug.Log("ATTENTO! STANNO ARRIVANDO!");
    }
    public void SecondWave()
    {
        SpawnEnemy(5);

        Debug.Log("Ne arrivano altri, resisti! Dovrebbe esserci uno Shotgun nel parco. Potrebbe tornarti utile!");
    }
    public void ThirdWave()
    {
        SpawnEnemy(17);

        Debug.Log("Ma quanti sono!? ATTENTO FRANK! Prendi il Fucile, nel parcheggio e falli fuori!");
    }
    public void LastWave()
    {
        SpawnEnemy(30);

        Debug.Log("CE NE SONO TROPPI!! VIENI IN FONDO ALLA STRADA, A DESTRA, SGANCEREMO UNA BOMBA!!");
    }

    private void SpawnEnemy(int zombieSpawned)
    {
        for (int i = 0; i < zombieSpawned; i++)
        {
            Transform spawnPoint = _spawnPoints[Random.Range(0, _spawnPoints.Length)];
            int index = Random.Range(0, 3);
            Vector2 offset = new Vector2(Random.Range(-1.5f, 1.5f), Random.Range(-1.5f, 1.5f));

            GameObject enemy = _enemyPool.GetEnemy(index);
            enemy.transform.position = spawnPoint.position + (Vector3)offset;
        }
    }
}

