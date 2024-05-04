using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using static UnityEngine.Rendering.DebugUI;

public class SliderBar : MonoBehaviour
{
    public Slider slider;
    [SerializeField] Gradient gradient;
    public Image fill;
    [SerializeField] private TextMeshProUGUI valueText;

    protected void Awake()
    {
        slider = GetComponent<Slider>();
        fill.color = gradient.Evaluate(slider.normalizedValue);
    }
    public void SetMaxValue(int maxValue)
    {
        slider.maxValue = maxValue;
        slider.value = maxValue;
        fill.color = gradient.Evaluate(1.0f);
        UpdateValueText();
    }
  
    public void SetValue(int Value)
    {
        slider.value = Value;
        fill.color = gradient.Evaluate(slider.normalizedValue);
        UpdateValueText();

    }
    public void UpdateValueText()
    {
        valueText.text = slider.value + "/" + slider.maxValue;
    }

    public void IncreaseMaxHealth(int increaseMaxValue)
    {
        slider.maxValue += increaseMaxValue;
        SetValue((int)slider.value + increaseMaxValue);
    }
}
