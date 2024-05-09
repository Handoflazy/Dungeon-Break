using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnhanceSkill : AbstractSkill
{
    public AudioClip activeSound;

    [SerializeField]
    private GameObject enhance_Prefab;

    [SerializeField]
    List<EnhanceDataSO> enhanceDatas = new();

    GameObject enhance = null;

    private BasicGun currentGun;

    private void Start()
    {

    }

    private void Update()
    {
        currentGun = GetComponentInChildren<BasicGun>();
        if (enhance != null)
        {
            Vector3 position = transform.position - new Vector3(0, 0.1f, 0);
            enhance.transform.position = position;
        }
    }

    protected override void Awake()
    {
        base.Awake();
        cooldown = 10;
    }

    public override void OnUsed()
    {
        Vector3 position = transform.position - new Vector3(0,0.1f,0);
        enhance = Instantiate(enhance_Prefab, position, Quaternion.identity);

        StartCoroutine(Enhance());
    }

    private IEnumerator Enhance()
    {

        print("speedFactor old: "+ currentGun.speedFactor);

        currentGun.speedFactor *= enhanceDatas[0].speedFactor;

        print("speedFactor new: "+currentGun.speedFactor);

        yield return new WaitForSeconds(enhanceDatas[0].enhanceTime - 0.5f);

        currentGun.speedFactor /= enhanceDatas[0].speedFactor;

        print("speedFactor current: "+currentGun.speedFactor);

        Destroy(enhance);
    }
}
