using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField] private float _fireRate;
    [SerializeField] private float _fireRange;
    [SerializeField] private int _bulletIndex;
    [SerializeField] private AudioClip _sfx;
    [SerializeField] private BulletPool _bulletPool;
    [SerializeField] private ParticleSystem _particleSystem;

    private float _lastTimeShot;
    private bool _isEquipped;
    private AudioSource _audioSource;
    private Transform _player;
    private SpriteRenderer _sr;

    public bool IsEquipped => _isEquipped;

    private void Awake()
    {
        if (_audioSource == null)
        {
            _audioSource = GetComponent<AudioSource>();
        }

        if (_bulletPool == null)
        {
            _bulletPool = FindObjectOfType<BulletPool>();
        }

        if (_sr == null)
        {
            _sr = GetComponentInChildren<SpriteRenderer>();
        }
    }

    private void Update()
    {
        if (_isEquipped && _player != null)
        {
            transform.position = _player.transform.position;

            GameObject target = FindNearestEnemy();

            if (target != null)
            {
                float directionX = target.transform.position.x - transform.position.x;
                _sr.flipX = (directionX < 0);

                if (Time.time - _lastTimeShot > _fireRate)
                {
                    _lastTimeShot = Time.time;
                    Shoot(target);
                    _particleSystem.Play();
                }
            }
        }
    }

    public GameObject FindNearestEnemy()
    {
        GameObject[] enemys = GameObject.FindGameObjectsWithTag("Enemy");
        Vector2 player = new Vector2(transform.position.x, transform.position.y);

        float distance;
        float minDistance = _fireRange;
        GameObject nearestEnemy = null;

        foreach (GameObject enemy in enemys)
        {
            distance = Vector2.Distance(player, enemy.transform.position);
            if (distance < minDistance)
            {
                nearestEnemy = enemy;
                minDistance = distance;
            }
        }
        return nearestEnemy;
    }

    public void Shoot(GameObject target)
    {
        if (target == null) return;

        Vector2 direction = target.transform.position - transform.position;
        direction.Normalize();

        GameObject bullet = _bulletPool.GetBullet(_bulletIndex);
        bullet.transform.position = transform.position;
        bullet.GetComponent<Bullet>().Set(direction);

        if (_audioSource != null)
        {
            _audioSource.clip = _sfx;
            _audioSource.Play();
        }
    }

    public void Equip()
    {
        _isEquipped = true;
    }

    public void SetBulletPool(BulletPool pool)
    {
        _bulletPool = pool;
    }

    public void SetPlayer(Transform player)
    {
        _player = player;
    }
}
