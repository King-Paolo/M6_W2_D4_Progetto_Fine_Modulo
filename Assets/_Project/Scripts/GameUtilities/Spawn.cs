using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    [SerializeField] Enemy _enemyPreFab;
    [SerializeField] Enemy _silverEnemyPreFab;
    [SerializeField] Enemy _goldenEnemyPreFab;
    [SerializeField] GameObject _spawnPointAssaultRifle;
    [SerializeField] GameObject _spawnPointShotgun;
    [SerializeField] Gun _assaultRiflePreFab;
    [SerializeField] Gun _shotgunPreFab;
    [SerializeField] Bomb _targetPoint;

    private bool _waveStarted;
    private bool _firstWaveIsSpawned;
    private bool _secondWaveIsSpawned;
    private bool _thirdWaveIsSpawned;
    private bool _lastWaveIsSpawned;
    private int _firsWave = 1;
    private int _secondWave = 5;
    private int _thirdWave = 17;
    private int _lastWave = 30;
    private float _spawnTime;

    private void Update()
    {
        if (_waveStarted)
        {
            SpawnWave();
        }
    }

    public void FirstWave()
    {
        for (int i = 0; i < _firsWave; i++)
        {
            SpawnEnemy();
        }
        Debug.Log("ATTENTO! STANNO ARRIVANDO!");
    }
    public void SecondWave()
    {
        Instantiate(_shotgunPreFab, _spawnPointShotgun.transform.position, _spawnPointShotgun.transform.rotation);

        for (int i = 0; i < _secondWave; i++)
        {
            SpawnEnemy();
        }
        Debug.Log("Ne arrivano altri, resisti! Dovrebbe esserci uno Shotgun nel parco. Potrebbe tornarti utile!");
    }
    public void ThirdWave()
    {
        Instantiate(_assaultRiflePreFab, _spawnPointAssaultRifle.transform.position, _spawnPointAssaultRifle.transform.rotation);

        for (int i = 0; i < _thirdWave; i++)
        {
            SpawnEnemy();
        }
        Debug.Log("Ma quanti sono!? ATTENTO FRANK! Prendi il Fucile, nel parcheggio e falli fuori!");
    }
    public void LastWave()
    {
        Instantiate(_targetPoint);

        for (int i = 0; i < _lastWave; i++)
        {
            SpawnEnemy();
        }
        Debug.Log("CE NE SONO TROPPI!! VIENI IN FONDO ALLA STRADA, A DESTRA, SGANCEREMO UNA BOMBA!!");
    }
    public void SpawnWave()
    {
        if (Time.time - _spawnTime >= 3 && _firstWaveIsSpawned == false)
        {
            FirstWave();
            _firstWaveIsSpawned = true;
        }
        if (Time.time - _spawnTime >= 20 && _secondWaveIsSpawned == false)
        {
            SecondWave();
            _secondWaveIsSpawned = true;
        }
        if (Time.time - _spawnTime >= 50 && _thirdWaveIsSpawned == false)
        {
            ThirdWave();
            _thirdWaveIsSpawned = true;
        }
        if (Time.time - _spawnTime >= 80 && _lastWaveIsSpawned == false)
        {
            LastWave();
            _lastWaveIsSpawned = true;
        }
    }
    public void StartWave()
    {
        _waveStarted = true;
        _spawnTime = Time.time;
    }

    private void SpawnEnemy()
    {
        Instantiate(_enemyPreFab, transform);
        Instantiate(_silverEnemyPreFab, transform);
        Instantiate(_goldenEnemyPreFab, transform);
    }
}

