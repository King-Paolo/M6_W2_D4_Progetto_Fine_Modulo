using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private int _damage;

    private AnimationParamHandler _animParam;
    private GameObject _player;
    private LifeController _enemy;

    private void Awake()
    {
        _animParam = GetComponent<AnimationParamHandler>();
        _player = GameObject.FindGameObjectWithTag("Player");
        _enemy = GetComponent<LifeController>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Debug.Log("TRIGGER con: " + collision.name);

        if (_enemy.IsDead) return;

        LifeController player = collision.GetComponent<LifeController>();

        if (collision.CompareTag("Player") && player != null)
        {
            player.TakeDamage(_damage);
        }
    }

    private void FixedUpdate()
    {
        if (_player != null)
        {
            transform.position = Vector2.MoveTowards(transform.position, _player.transform.position, _speed * Time.deltaTime);

            Vector2 direction = _player.transform.position - transform.position;

            _animParam.SetHorizontalSpeedParam(direction.x);
            _animParam.SetVerticalSpeedParam(direction.y);
        }
        else
        {
            _animParam.SetHorizontalSpeedParam(0);
            _animParam.SetVerticalSpeedParam(0);
        }
    }
}
