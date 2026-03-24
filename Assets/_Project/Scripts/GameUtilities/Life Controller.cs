using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class LifeController : MonoBehaviour
{
    [SerializeField] private int _hp;
    [SerializeField] private int _maxHp;
    [SerializeField] private AnimationParamHandler _animParam;
    [SerializeField] private UnityEvent<int, int> _onHpChanged;

    private bool _isDead;

    //public float Hp { get { return _hp; } }
    public bool IsDead => _isDead;

    private void Awake()
    {
        _hp = _maxHp;
    }

    private void OnEnable()
    {
        _isDead = false;

        if (!CompareTag("Player"))
        {
            _hp = _maxHp;
            _animParam.SetHealthParam(false);
        }
    }
    private void SetHp(int hp)
    {
        _hp = Mathf.Clamp(hp, 0, _maxHp);

        if (_hp == 0 && !_isDead)
        {
            _isDead = true;
            _animParam.SetHealthParam(_hp == 0);
            StartCoroutine(DeathTimer());
        }

        if (CompareTag("Player"))
        {
            _onHpChanged.Invoke(_hp, _maxHp);
            GameManager.Instance.GameOver();
        }
    }

    public void TakeDamage(int damage) => SetHp(_hp - damage);

    IEnumerator DeathTimer()
    {
        yield return new WaitForSeconds(0.8f);

        if (CompareTag("Player"))
        {
            Destroy(gameObject);
        }
        else
        {
            gameObject.SetActive(false);
        }
    }
}