using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using TMPro;

public class BossHealthBArController : MonoBehaviour
{
 
    [SerializeField] private SliderBar bossHealth;

 
 
    public void InitialMaxValueHealthBar(int maxHealth)
    {
        bossHealth.gameObject.SetActive(true);
        bossHealth.SetMaxValue(maxHealth);

    }
 

    public void OnHealthChanged(int currentHealth)
    {

        bossHealth.SetValue(currentHealth);
    }
    public void HideHealthBar()
    {
        gameObject.SetActive(false);
    }

}
