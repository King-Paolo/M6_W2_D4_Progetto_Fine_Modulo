using UnityEngine;

public class Bomb : MonoBehaviour
{
    [SerializeField] private AudioClip _sfx;
    [SerializeField] private float _damage;

    private AudioSource _audioSource;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
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
            Debug.Log("Ottimo lavoro Frank, li abbiamo sterminati!");
            Destroy(gameObject, _sfx.length);
        }
    }
}
