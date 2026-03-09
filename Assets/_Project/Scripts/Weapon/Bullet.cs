using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _damage;

    private Vector2 _direction;
    private Rigidbody2D _rb;

    public void Set(Vector2 direction)
    {
        _direction = direction;
    }

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        Destroy(gameObject, 2f);
    }

    private void FixedUpdate()
    {
        _rb.MovePosition(_rb.position + _direction * (_speed * Time.fixedDeltaTime));
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        LifeController enemy = collision.gameObject.GetComponent<LifeController>();

        if (collision.gameObject.CompareTag("Enemy"))
        {
            enemy.TakeDamage(_damage);
            Destroy(gameObject);
        }

        if (collision.gameObject.CompareTag("Walls"))
        {
            Destroy(gameObject);
        }
    }
}
