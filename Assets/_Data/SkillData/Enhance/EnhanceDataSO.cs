using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Skill / Enhance")]
public class EnhanceDataSO : ScriptableObject
{
    [field: SerializeField]
    public GameObject EnhancePrefab { get; set; }

    [field: SerializeField, Range(5, 10)]
    public int enhanceTime { get; set; }

    [field: SerializeField, Range(2, 5)]
    public int speedFactor { get; set; }
}
