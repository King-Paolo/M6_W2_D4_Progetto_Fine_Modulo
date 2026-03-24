using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_LifeBar : MonoBehaviour
{
    [SerializeField] private Image _fillableLifebar;

    public void UpdateGraphics(int hp, int maxHp)
    {
        _fillableLifebar.fillAmount = (float)hp / maxHp;
    }
}
