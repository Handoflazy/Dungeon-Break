using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.UI;

public class FloatingTextManager : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject textContainer;
    public GameObject textPrefab;

    private List<FloatingText> floatingTexts = new();
    

    private void Update()
    {
        foreach(FloatingText text in floatingTexts)
        {
            text.UpdateFloatingText();
        }
    }
    public void Show(string msg, int fontSize, Color color, Vector3 position, Vector3 motion, float duration)
    {
        FloatingText floatingtxt = GetFloatingText();
        if(floatingtxt == null)
        {
            print("ko co");
        }
        floatingtxt.text.text = msg;
        floatingtxt.text.fontSize = fontSize;
        floatingtxt.text.color = color;

        floatingtxt.origin.transform.position = Camera.main.WorldToScreenPoint(position);
        floatingtxt.motion = motion;
        floatingtxt.duration = duration;

        floatingtxt.Show();
    }
    private FloatingText GetFloatingText()
    {

        
        FloatingText txt = floatingTexts.Find(t => !t.active);
        if(txt == null)
        {

            txt = new FloatingText
            {
                origin = Instantiate(textPrefab)
            };
            txt.origin.transform.SetParent(textContainer.transform);
            txt.text = txt.origin.GetComponent<TextMeshProUGUI>();
            floatingTexts.Add(txt);
        }
        return txt;
    }
    // Update is called once per frame
    
}
