using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;

public class MagicWeapon : Weapon
{

    [SerializeField] float distance;
    [SerializeField] Transform spawnLaserPos;   
    [SerializeField]
    private GameObject LaserPrefab;

    private List<GameObject> arrows = new();
    public WeaponParent weaponParent;
    private float laserWitdh;
    private void Start()
    {
        weaponParent = transform.parent.GetComponent<WeaponParent>();
        WeaponAnim = GetComponent<Animator>();
        laserWitdh = spawnLaserPos.gameObject.GetComponent<SpriteRenderer>().size.x;
    }
    readonly int FIRE_HASH = Animator.StringToHash("Fire");
    public override void Attack()
    {
        WeaponAnim.SetTrigger(FIRE_HASH);
        GameObject laser = GetLaser();
        laser.SetActive(true);
        laser.transform.position = spawnLaserPos.position;
        laser.transform.rotation = weaponParent.transform.rotation;
        laser.GetComponent<Laser>().UpdateLaserRange(distance,laserWitdh*3);
    }

    private GameObject GetLaser()
    {
        GameObject Laser = arrows.Find(t => !t.active);
        if (Laser == null)
        {

            Laser = Instantiate(LaserPrefab);
            //arrow.transform.SetParent(transform);      
            arrows.Add(Laser);
        }
        return Laser;
    }
}
