using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private int _damage;

    private Vector2 _direction;
    private Rigidbody2D _rb;
    private float _lifeTimer;
    private float _lifeTime = 2f;

    public void Set(Vector2 direction)
    {
        _direction = direction;
    }

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    private void OnEnable()
    {
        _lifeTimer = 0;
    }

    private void Update()
    {
        _lifeTimer += Time.deltaTime;

        if (_lifeTimer >= _lifeTime)
        {
            gameObject.SetActive(false);
        }
    }

    private void FixedUpdate()
    {
        _rb.MovePosition(_rb.position + _direction * (_speed * Time.fixedDeltaTime));
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        LifeController enemy = collision.gameObject.GetComponent<LifeController>();

        if (enemy != null && collision.gameObject.CompareTag("Enemy"))
        {
            enemy.TakeDamage(_damage);
            gameObject.SetActive(false);
        }

        if (collision.gameObject.CompareTag("Walls"))
        {
            gameObject.SetActive(false);
        }
    }
}
