using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class RangerWeapon : Weapon
{
    [SerializeField]
    private float distance = 1;
    [SerializeField]
    private Transform arrowSpawnPoint;

    [SerializeField]
    private GameObject arrowPrefab;
    private List<GameObject> arrows = new();
    public WeaponParent weaponParent;

    [SerializeField]
    private void Start()
    {
        weaponParent = transform.parent.GetComponent<WeaponParent>();
        WeaponAnim = GetComponent<Animator>();
    }

    readonly int FIRE_HASH = Animator.StringToHash("Fire");
    public override void Attack()
    {
        WeaponAnim.SetTrigger(FIRE_HASH);
        GameObject arrow = GetArrow();
        arrow.SetActive(true);
        arrow.transform.position = arrowSpawnPoint.position;
        arrow.transform.rotation = weaponParent.transform.rotation * Quaternion.Euler(0, 0, -90);
        CommonArrow arrowSetting = arrow.GetComponent<CommonArrow>();
        arrowSetting.Distance = distance;

    }


    private GameObject GetArrow()
    {
        GameObject arrow = arrows.Find(t => !t.active);
        if (arrow == null)
        {

            arrow = Instantiate(arrowPrefab);
            //arrow.transform.SetParent(transform);      
            arrows.Add(arrow);
        }
        return arrow;
    }
}
