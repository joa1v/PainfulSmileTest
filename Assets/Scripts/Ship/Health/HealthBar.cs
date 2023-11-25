using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Image _barFill;
    [SerializeField] private HealthPoints _healthPoints;

    private void OnEnable()
    {
        _healthPoints.OnHealthPointsChanged += SetValue;
    }

    private void OnDisable()
    {
        _healthPoints.OnHealthPointsChanged -= SetValue;
    }

    public void SetValue(int value, int maxValue)
    {
        float fill = Mathf.InverseLerp(0, maxValue, value);
        _barFill.fillAmount = fill;
    }
}
