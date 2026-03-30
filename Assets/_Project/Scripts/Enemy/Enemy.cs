using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private int _damage;

    [Header("Audio Settings")]
    [SerializeField] private float _minGrowlDelay = 3f;
    [SerializeField] private float _maxGrowlDelay = 8f;

    private float _nextGrowlTime;
    private AnimationParamHandler _animParam;
    private GameObject _player;
    private LifeController _enemy;
    private EnemySFX _enemySFX;

    private void Awake()
    {
        _animParam = GetComponent<AnimationParamHandler>();
        _player = GameObject.FindGameObjectWithTag("Player");
        _enemy = GetComponent<LifeController>();
        _enemySFX = GetComponent<EnemySFX>();
    }

    private void Start()
    {
        SetNextGrowlTime();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (_enemy.IsDead) return;

        LifeController player = collision.GetComponent<LifeController>();

        if (collision.CompareTag("Player") && player != null)
        {
            player.TakeDamage(_damage);
        }
    }

    private void FixedUpdate()
    {
        if (_enemy.IsDead) return;

        if (_player != null)
        {
            transform.position = Vector2.MoveTowards(transform.position, _player.transform.position, _speed * Time.deltaTime);

            Vector2 direction = _player.transform.position - transform.position;

            _animParam.SetHorizontalSpeedParam(direction.x);
            _animParam.SetVerticalSpeedParam(direction.y);

            Growling();
        }
        else
        {
            _animParam.SetHorizontalSpeedParam(0);
            _animParam.SetVerticalSpeedParam(0);
        }
    }

    private void Growling()
    {
        if (Time.time >= _nextGrowlTime)
        {
            if (_enemySFX != null)
            {
                _enemySFX.PlayGrowl();
            }
            SetNextGrowlTime();
        }
    }

    private void SetNextGrowlTime()
    {
        _nextGrowlTime = Time.time + Random.Range(_minGrowlDelay, _maxGrowlDelay);
    }
}
