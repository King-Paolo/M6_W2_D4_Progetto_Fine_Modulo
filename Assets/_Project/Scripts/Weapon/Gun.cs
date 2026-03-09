using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField] private float _fireRate;
    [SerializeField] private float _fireRange;
    [SerializeField] private Bullet _bulletPrefab;
    [SerializeField] private AudioClip _sfx;

    private float _lastTimeShot;
    private bool _isEquipped;
    private AnimationParamHandler _animParam;
    private AudioSource _audioSource;

    private void Awake()
    {
        _animParam = GetComponent<AnimationParamHandler>();

        if (_audioSource == null)
        {
            _audioSource = GetComponent<AudioSource>();
        }
    }

    private void Update()
    {
        if (Time.time - _lastTimeShot > _fireRate && _isEquipped)
        {
            GameObject enemy = FindNearestEnemy();
            _lastTimeShot = Time.time;
            Shoot();

            if (enemy != null)
            {
                Vector2 direction = enemy.transform.position - transform.position;
                _animParam.SetHorizontalSpeedParam(direction.x);
            }
        }
    }

    public GameObject FindNearestEnemy()
    {
        GameObject[] enemys = GameObject.FindGameObjectsWithTag("Enemy"); // creo un array per cercare tutti i gameObject col tag "enemy" nella scena
        Vector2 player = new Vector2(transform.position.x, transform.position.y); // posizione di partenza (quella del player) per calcolare la distanza dal nemico

        float distance;
        float minDistance = _fireRange;
        GameObject NearestEnemy = null; // faccio un controllo per essere sicuro che il calcolo parta da 0

        foreach (GameObject enemy in enemys)
        {
            distance = Vector2.Distance(player, enemy.transform.position);
            if (distance < minDistance)
            {
                NearestEnemy = enemy;
                minDistance = distance;
            }
        }
        return NearestEnemy;
    }

    public void Shoot()
    {
        GameObject ClosestEnemy = FindNearestEnemy();
        if (ClosestEnemy != null)
        {
            Vector2 direction = ClosestEnemy.transform.position - transform.position; // calcolo la direzione dei colpi
            direction.Normalize();

            Bullet bullet = Instantiate(_bulletPrefab);
            bullet.transform.position = transform.position;
            bullet.Set(direction); //dò il valore della direzione alla funzione

            if (_audioSource != null)
            {
                _audioSource.clip = _sfx;
                _audioSource.Play();
            }
        }
    }

    public void Equip()
    {
        _isEquipped = true;
    }

}
