using FirstVersion;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MineSkill : AbstractSkill
{
    [SerializeField]
    private GameObject mine_Prefab;

    [SerializeField]
    List<MineDataSO> mineDatas = new();

    private void Start()
    {

    }


    protected override void Awake()
    {
        base.Awake();
        cooldown = 5;
    }

    public override void OnUsed()
    {
        GameObject mine = Instantiate(mine_Prefab, transform.position, Quaternion.identity);
        if (mineDatas.Count > 0)
        {
            mine.GetComponent<MineController>().MineData = mineDatas[0];
        }
    }
}
