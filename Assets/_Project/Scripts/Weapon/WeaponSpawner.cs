using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSpawner : MonoBehaviour
{
    [Header("Weapons SpawnManager Points")]
    [SerializeField] private Transform _spawnPointAssaultRifle;
    [SerializeField] private Transform _spawnPointShotgun;
    [SerializeField] private Transform _bombTargetPoint;

    [Header("Weapons prefabs")]
    [SerializeField] private Gun _assaultRiflePreFab;
    [SerializeField] private Gun _shotgunPreFab;

    public void SpawnShotgun()
    {
        Instantiate(_shotgunPreFab, _spawnPointShotgun.position, _spawnPointShotgun.rotation);
    }

    public void SpawnAssaultRifle()
    {
        Instantiate(_assaultRiflePreFab, _spawnPointAssaultRifle.position, _spawnPointAssaultRifle.rotation);
    }

    public void SpawnBombSignal()
    {
        Instantiate(_bombTargetPoint);
    }
}
