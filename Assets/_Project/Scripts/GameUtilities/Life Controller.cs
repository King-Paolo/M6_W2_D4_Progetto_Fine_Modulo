using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;

public class LifeController : MonoBehaviour
{
    [SerializeField] private float _hp;

    private AnimationParamHandler _animParam;

    public float Hp { get { return _hp; } }

    private void Start()
    {
        _animParam = GetComponent<AnimationParamHandler>();
    }

    private void SetHp(float hp)
    {
        _hp = Mathf.Max(0, hp);
        if (_hp == 0)
        {
            _animParam.SetHealthParam(_hp == 0);
            Destroy(gameObject, 0.8f);

            if (CompareTag("Player"))
            {
                Debug.Log("FRANK!!! NOOOO!! Sei stato sconfitto!");
            }
        }

        if (CompareTag("Player"))
        {
            Debug.Log("Hp rimanenti" + _hp);
        }
    }

    public void TakeDamage(float damage) => SetHp(_hp - damage);
}