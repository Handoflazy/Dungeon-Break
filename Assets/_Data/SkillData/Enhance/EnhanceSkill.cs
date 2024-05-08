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

    private GunWeapon gunWeapon;

    private void Start()
    {
        gunWeapon = GetComponentInChildren<GunWeapon>(); //ko co scripts GunWapon de lay
        if (!gunWeapon) { print("gun wp null roi"); }
    }

    private void Update()
    {
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
        canUse = false;

        Vector3 position = transform.position - new Vector3(0,0.1f,0);
        enhance = Instantiate(enhance_Prefab, position, Quaternion.identity);

        StartCoroutine(Enhance());

        canUse = true;
    }

    private IEnumerator Enhance()
    {

        print("speedFactor old: "+ gunWeapon.speedFactor);

        gunWeapon.speedFactor *= enhanceDatas[0].speedFactor;

        print("speedFactor new: "+gunWeapon.speedFactor);

        yield return new WaitForSeconds(enhanceDatas[0].enhanceTime - 0.5f);

        gunWeapon.speedFactor /= enhanceDatas[0].speedFactor;

        print("speedFactor current: "+gunWeapon.speedFactor);

        Destroy(enhance);
    }
}
