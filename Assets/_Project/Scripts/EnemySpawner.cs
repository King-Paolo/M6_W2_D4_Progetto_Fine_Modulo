using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [Header("Enemy SpawnManager Points")]
    [SerializeField] private Transform[] _spawnPoints;
    [SerializeField] private EnemyPool _enemyPool;
    [SerializeField] private GameObject[] _dialoguesMenu;

    private void Start()
    {
        GameManager.Instance.DialoguesMenu(_dialoguesMenu[0]);
    }
    public void FirstWave()
    {
        SpawnEnemy(3);
        GameManager.Instance.DialoguesMenu(_dialoguesMenu[1]);
        Debug.Log("ATTENTO! STANNO ARRIVANDO!");
    }
    public void SecondWave()
    {
        SpawnEnemy(7);
        GameManager.Instance.DialoguesMenu(_dialoguesMenu[2]);
        Debug.Log("Ne arrivano altri, resisti! Dovrebbe esserci uno Shotgun nel parco. Potrebbe tornarti utile!");
    }
    public void ThirdWave()
    {
        SpawnEnemy(20);
        GameManager.Instance.DialoguesMenu(_dialoguesMenu[3]);
        Debug.Log("Ma quanti sono!? ATTENTO FRANK! Prendi il Fucile, nel parcheggio e falli fuori!");
    }
    public void LastWave()
    {
        SpawnEnemy(50);
        GameManager.Instance.DialoguesMenu(_dialoguesMenu[4]);
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

