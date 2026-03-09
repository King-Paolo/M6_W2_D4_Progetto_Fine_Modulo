using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _damage;

    private AnimationParamHandler _animParam;
    private LifeController _enemy;

    private void Awake()
    {
        _enemy = GetComponent<LifeController>();
        _animParam = GetComponent<AnimationParamHandler>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        LifeController player = collision.gameObject.GetComponent<LifeController>();

        if (collision.gameObject.CompareTag("Player"))
        {
            player.TakeDamage(_damage);
            Destroy(gameObject);      // lascio il nemico in vita(?)
        }
    }

    private void FixedUpdate()
    {
        GameObject player = GameObject.Find("Player");   // DA LEVARE!!!

        if (player != null)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.transform.position, _speed * Time.deltaTime);

            Vector2 direction = player.transform.position - transform.position;

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
