using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float _speed;

    private float _horizontal;
    private float _vertical;
    private Rigidbody2D _rb;
    private AnimationParamHandler _animParam;

    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _animParam = GetComponent<AnimationParamHandler>();
        Debug.Log("Frank, questi zombie sono dappertutto, vai a prendere la pistola vicino alla mia auto, nel parcheggio");
    }

    private void Update()
    {
        _horizontal = Input.GetAxis("Horizontal");
        _vertical = Input.GetAxis("Vertical");
    }

    void FixedUpdate()
    {
        Vector2 direction = new Vector2(_horizontal, _vertical);

        if (direction.sqrMagnitude > 1)
            direction = direction.normalized;

        _rb.MovePosition(_rb.position + direction * (_speed * Time.fixedDeltaTime));

        if (_horizontal != 0 || _vertical != 0)
        {
            _animParam.SetHorizontalSpeedParam(_horizontal);
            _animParam.SetVerticalSpeedParam(_vertical);
        }
    }
}
