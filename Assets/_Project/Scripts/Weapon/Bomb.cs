using System.Collections;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    [SerializeField] private AudioClip _sfx;
    [SerializeField] private int _damage;
    [SerializeField] private ParticleSystem _particleSystem;

    private AudioSource _audioSource;
    private bool _canBeActivate = true;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && _canBeActivate)
        {
            if (_audioSource == null) _audioSource = GetComponent<AudioSource>();

            if (_audioSource != null)
            {
                _audioSource.clip = _sfx;
                _audioSource.Play();
            }

            GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");

            foreach (GameObject enemy in enemies)
            {
                LifeController zombie = enemy.GetComponent<LifeController>();

                if (zombie != null)
                {
                    zombie.TakeDamage(_damage);
                }
            }
            Instantiate(_particleSystem, transform);
            _canBeActivate = false;
            GameManager.Instance.TriggerDelayVictory(1.5f);
        }
    }
}
