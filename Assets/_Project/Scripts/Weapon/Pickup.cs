using UnityEngine;

public class Pickup : MonoBehaviour
{
    [SerializeField] private Gun _gunPrefab;
    //[SerializeField] private SpawnManager _spawnManager;
    [SerializeField] private AudioClip _sfx;

    private AudioSource _audioSource;
    private Gun _gun;

    private void Awake()
    {
        if (_audioSource == null) _audioSource = GetComponent<AudioSource>();
        _gun = GetComponent<Gun>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !_gun.IsEquipped)
        {
            if (_audioSource != null)
            {
                _audioSource.clip = _sfx;
                _audioSource.Play();
            }

            SpawnManager.Instance.StartWave();

            _gun = Instantiate(_gunPrefab/*, *//*collision.transform*/);
            _gun.SetPlayer(collision.transform);
            _gun.transform.position = collision.transform.position;
            BulletPool pool = FindObjectOfType<BulletPool>();
            _gun.SetBulletPool(pool);

            _gun.Equip();
            Destroy(gameObject, _sfx.length);
        }
    }
}


