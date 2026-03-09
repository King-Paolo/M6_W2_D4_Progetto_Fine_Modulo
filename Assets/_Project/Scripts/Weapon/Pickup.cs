using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    [SerializeField] private Gun _gunPrefab;
    [SerializeField] private Spawn _zombieSpawn;
    [SerializeField] private AudioClip _sfx;

    private AudioSource _audioSource;

    private void Awake()
    {
        if (_audioSource == null) _audioSource = GetComponent<AudioSource>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (_audioSource != null)
            {
                _audioSource.clip = _sfx;
                _audioSource.Play();
            }

            _zombieSpawn.StartWave();

            Gun gun = Instantiate(_gunPrefab);
            gun.transform.position = collision.transform.position;

            gun.Equip();
            Destroy(gameObject, _sfx.length);
        }
    }
}


