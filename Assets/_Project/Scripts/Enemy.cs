using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _damage;

    private AnimationParamHandler _animParam;
    private GameObject _player;
    private LifeController _enemy;

    private void Awake()
    {
        _animParam = GetComponent<AnimationParamHandler>();
        _player = GameObject.Find("Player");
        _enemy = GetComponent<LifeController>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (_enemy.IsDead) return;

        LifeController player = collision.gameObject.GetComponent<LifeController>();

        if (collision.gameObject.CompareTag("Player") && player != null)
        {
            player.TakeDamage(_damage);
            Destroy(gameObject);      // lascio il nemico in vita(?)
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
