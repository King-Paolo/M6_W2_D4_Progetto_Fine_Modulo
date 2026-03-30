using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class LifeController : MonoBehaviour
{
    [SerializeField] private int _hp;
    [SerializeField] private int _maxHp;
    [SerializeField] private AnimationParamHandler _animParam;
    [SerializeField] private UnityEvent<int, int> _onHpChanged;
    [SerializeField] private ParticleSystem _particleSystem;

    private bool _isDead;

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

            if (CompareTag("Player"))
            {
                GameManager.Instance.TriggerDelayGameOver(1);
            }
        }

        if (CompareTag("Player"))
        {
            _onHpChanged.Invoke(_hp, _maxHp);
        }
    }

    public void TakeDamage(int damage) => SetHp(_hp - damage);

    public IEnumerator DeathTimer()
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

    public IEnumerator GameOver()
    {
        yield return new WaitForSeconds(1);
        GameManager.Instance.GameOver();
    }
}