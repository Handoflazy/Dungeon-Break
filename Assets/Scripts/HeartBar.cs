using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeartBar : MonoBehaviour
{
    public Slider slider;
    [SerializeField] Gradient gradient;
    public Image fill;
    private void Awake()
    {
        
        slider = GetComponent<Slider>();
        fill.color = gradient.Evaluate(slider.normalizedValue);
    }
    // Start is called before the first frame update
    public void SetMaxHearth(int maxHealth)
    {
        slider.maxValue = maxHealth;
        fill.color = gradient.Evaluate(1.0f);
    }
  
    public void SetHealth(int health)
    {
        slider.value = health;
        fill.color = gradient.Evaluate(slider.normalizedValue);
    }
}
