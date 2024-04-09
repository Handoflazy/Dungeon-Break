using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderBar : MonoBehaviour
{
    public Slider slider;
    [SerializeField] Gradient gradient;
    public Image fill;


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
    }
  
    public void SetValue(int Value)
    {
        slider.value = Value;
        fill.color = gradient.Evaluate(slider.normalizedValue);
    }
}
