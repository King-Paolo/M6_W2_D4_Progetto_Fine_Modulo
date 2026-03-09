using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationParamHandler : MonoBehaviour
{
    private Animator _anim;
    [SerializeField] string _horizontalSpeedParamName = "hSpeed";
    [SerializeField] string _verticalSpeedParamName = "vSpeed";
    [SerializeField] string _healthParamName = "isDead";
    void Awake()
    {
        _anim = GetComponentInChildren<Animator>();
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
        _anim.SetBool(_healthParamName, isDead);
    }
}
