using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SliderWithText : MonoBehaviour
{
    [SerializeField] private Slider _slider;
    [SerializeField] private TextMeshProUGUI _textValue;

    public Slider Slider => _slider;
    public float Value
    {
        get => _slider.value;
        set
        {
            SetText(value);
            _slider.value = value;
        }
    }

    private void Awake()
    {
        _slider.onValueChanged.AddListener(SetText);
    }
    private void SetText(float value)
    {
        _textValue.text = value.ToString();
    }
}
