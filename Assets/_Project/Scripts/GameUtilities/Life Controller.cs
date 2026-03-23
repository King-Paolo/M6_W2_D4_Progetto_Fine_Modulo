using System.Collections;
using UnityEngine;

public class LifeController : MonoBehaviour
{
    [SerializeField] private float _hp;
    [SerializeField] private float _maxHp;

    private AnimationParamHandler _animParam;
    private bool _isDead;

    public float Hp { get { return _hp; } }
    public bool IsDead => _isDead;

    private void Awake()
    {
        _hp = _maxHp;

        if(_animParam != null)
        _animParam = GetComponent<AnimationParamHandler>();
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
    private void SetHp(float hp)
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
            Debug.Log("Hp rimanenti" + _hp);  // da aggiungere UI
        }
    }

    public void TakeDamage(float damage) => SetHp(_hp - damage);

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