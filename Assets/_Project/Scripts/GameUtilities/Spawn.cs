using System.Collections;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    [SerializeField] private EnemySpawner _enemySpawner;
    [SerializeField] private WeaponSpawner _weaponSpawner;

    public void StartWave()
    {
        StartCoroutine(SpawnWave());
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

