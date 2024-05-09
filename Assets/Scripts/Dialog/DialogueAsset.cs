using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="Dialog/Text")]
public class DialogueAsset : ScriptableObject 
{
    [TextArea]
    public string[] dialogue;


}
