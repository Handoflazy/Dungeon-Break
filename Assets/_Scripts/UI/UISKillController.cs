using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UISKillController : MonoBehaviour
{
    public Image expImage;
    public TextMeshProUGUI textLevel;

    [SerializeField]
    public UISkillboxController skillBox1;
    [SerializeField]
    public UISkillboxController skillBox2;
    [SerializeField]
    public UISkillboxController skillBox3;

    public void UpdateExp(float xp, float xpRequired)
    {
        if (expImage != null)
        {
            if (!Mathf.Approximately(expImage.fillAmount, 1))
            {
                expImage.fillAmount = xp / xpRequired;
            }
            else
            {
                expImage.fillAmount = 0;
            }
        }
    }
    public void SetLevel(float level)
    {
        textLevel.text = level.ToString();
    }

}
