using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField] private float _fireRate;
    [SerializeField] private float _fireRange;
    [SerializeField] private int _bulletIndex;
    [SerializeField] private AudioClip _sfx;
    [SerializeField] private BulletPool _bulletPool;

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
            _lastTimeShot = Time.time;
            Shoot(FindNearestEnemy());
        }
    }

    public GameObject FindNearestEnemy()
    {
        GameObject[] enemys = GameObject.FindGameObjectsWithTag("Enemy"); // creo un array per cercare tutti i gameObject col tag "enemy" nella scena
        Vector2 player = new Vector2(transform.position.x, transform.position.y); // posizione di partenza (quella del player) per calcolare la distanza dal nemico

        float distance;
        float minDistance = _fireRange;
        GameObject nearestEnemy = null; // faccio un controllo per essere sicuro che il calcolo parta da 0

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

        _animParam.SetHorizontalSpeedParam(direction.x);
    }

    public void Equip()
    {
        _isEquipped = true;
    }
}
