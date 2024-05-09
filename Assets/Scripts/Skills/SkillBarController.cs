using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class SkillBarController : MonoBehaviour
{
    public Image skillBox1;
    public Image skillBox2;
    public Image skillBox3;

    public Image imageCooldownMoveskill;
    public Image imageCooldownFirstskill;
    public Image imageCooldownSecondskill;

    public TextMeshProUGUI cooldownTimer1;
    public TextMeshProUGUI cooldownTimer2;
    public TextMeshProUGUI cooldownTimer3;

    private void Update()
    {
        
    }

    public IEnumerator UpdateCDMoveSkill( float CD)
    {
        cooldownTimer1.gameObject.SetActive(true);
        while(!Mathf.Approximately(imageCooldownMoveskill.fillAmount, 1))
        {
            imageCooldownMoveskill.fillAmount += 1 / CD * Time.deltaTime;
            CooldownTimer(CD - CD*imageCooldownMoveskill.fillAmount, cooldownTimer1);
            yield return null;
        }
        cooldownTimer1.gameObject.SetActive(false);
        imageCooldownMoveskill.fillAmount = 0;
        
    }
    public IEnumerator UpdateCDFirstSkill(float CD)
    {
        cooldownTimer2.gameObject.SetActive(true);
        while (!Mathf.Approximately(imageCooldownFirstskill.fillAmount, 1))
        {
            imageCooldownFirstskill.fillAmount += 1 / CD * Time.deltaTime;
            CooldownTimer(CD - CD*imageCooldownFirstskill.fillAmount, cooldownTimer2);
            yield return null;
        }
        cooldownTimer2.gameObject.SetActive(false);
        imageCooldownFirstskill.fillAmount = 0;
    }

    public IEnumerator UpdateCDSecondSkill(float CD)
    {
        cooldownTimer3.gameObject.SetActive(true);
        while (!Mathf.Approximately(imageCooldownSecondskill.fillAmount, 1))
        {
            imageCooldownSecondskill.fillAmount += 1 / CD * Time.deltaTime;
            CooldownTimer(CD - CD*imageCooldownSecondskill.fillAmount, cooldownTimer3);
            yield return null;
        }
        cooldownTimer3.gameObject.SetActive(false);
        imageCooldownSecondskill.fillAmount = 0;
    }

    public void CooldownTimer(float CD, TextMeshProUGUI textMesh) 
    {
        textMesh.text = CD.ToString("F1").ToString();
    }
}
