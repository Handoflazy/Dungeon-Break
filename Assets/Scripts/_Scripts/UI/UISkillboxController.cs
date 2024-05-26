using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UISkillboxController : MonoBehaviour
{
    public Image skillBox;

    public Image imageCooldown;

    public TextMeshProUGUI cooldownTimer;

    public IEnumerator UpdateCDSkill(float CD)
    {
        cooldownTimer.gameObject.SetActive(true);
        while (!Mathf.Approximately(imageCooldown.fillAmount, 1))
        {
            imageCooldown.fillAmount += 1 / CD * Time.deltaTime;
            CooldownTimer(CD - CD*imageCooldown.fillAmount);
            yield return null;
        }
        cooldownTimer.gameObject.SetActive(false);
        imageCooldown.fillAmount = 0;
    }

    public void CooldownTimer(float CD)
    {
        cooldownTimer.text = CD.ToString("F1").ToString();
    }
}
