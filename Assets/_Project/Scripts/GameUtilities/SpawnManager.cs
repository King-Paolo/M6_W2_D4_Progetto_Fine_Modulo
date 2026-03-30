using System.Collections;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public static SpawnManager Instance;

    [SerializeField] private EnemySpawner _enemySpawner;
    [SerializeField] private WeaponSpawner _weaponSpawner;

    private Coroutine _waveCoroutine;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
    }

    public void StartWave()
    {
        if (_waveCoroutine != null) return;

        _waveCoroutine = StartCoroutine(SpawnWave());
    }

    public IEnumerator SpawnWave()
    {
        yield return new WaitForSeconds(3);

        _enemySpawner.FirstWave();

        yield return new WaitForSeconds(15);

        _enemySpawner.SecondWave();
        _weaponSpawner.SpawnShotgun();

        yield return new WaitForSeconds(30);

        _enemySpawner.ThirdWave();
        _weaponSpawner.SpawnAssaultRifle();

        yield return new WaitForSeconds(30);

        _enemySpawner.LastWave();
        _weaponSpawner.SpawnBombSignal();
    }
}

