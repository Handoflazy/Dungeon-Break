using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
 public class PlayerID : ScriptableObject
{
    
    public SpriteRenderer sprite;
    public string playerName;
    public PlayerEvents playerEvents;
    public int maxHealth =120;
    public int maxDuration = 120;
}
