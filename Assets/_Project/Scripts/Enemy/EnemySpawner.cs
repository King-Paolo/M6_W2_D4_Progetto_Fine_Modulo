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
        SpawnEnemy(5);
        GameManager.Instance.DialoguesMenu(_dialoguesMenu[1]);
    }
    public void SecondWave()
    {
        SpawnEnemy(10);
        GameManager.Instance.DialoguesMenu(_dialoguesMenu[2]);
    }
    public void ThirdWave()
    {
        SpawnEnemy(30);
        GameManager.Instance.DialoguesMenu(_dialoguesMenu[3]);
    }
    public void LastWave()
    {
        SpawnEnemy(70);
        GameManager.Instance.DialoguesMenu(_dialoguesMenu[4]);
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

