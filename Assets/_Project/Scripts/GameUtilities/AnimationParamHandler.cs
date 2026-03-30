using UnityEngine;

public class AnimationParamHandler : MonoBehaviour
{
    [SerializeField] private Animator _anim;
    [SerializeField] private string _horizontalSpeedParamName = "hSpeed";
    [SerializeField] private string _verticalSpeedParamName = "vSpeed";
    [SerializeField] string _healthParamName = "isDead";

    void Awake()
    {
        if (_anim == null)
            _anim = GetComponent<Animator>();
    }

    public void SetHorizontalSpeedParam(float speed)
    {
        _anim.SetFloat(_horizontalSpeedParamName, speed);
    }

    public void SetVerticalSpeedParam(float speed)
    {
        _anim.SetFloat(_verticalSpeedParamName, speed);
    }

    public void SetHealthParam(bool isDead)
    {
        if (_anim == null)
        {
            Debug.LogError("Animator null in SetHealthParam su " + gameObject.name);
            return;
        }

        _anim.SetBool(_healthParamName, isDead);
    }
}
