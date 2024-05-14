using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.FullSerializer;
using UnityEditor;
using UnityEngine;

[CreateAssetMenu(menuName = "Weapons/Weapon Data")]
public class GunWeaponDataSO : ScriptableObject
{
    [field: SerializeField]
    public BulletDataSO BulletData { get; set; }


    [field: SerializeField]
    [field: Range(1, 100)]
    public int AmmoCapacity { get; private set; } = 100;
    [field: SerializeField]
    public bool AutomaticFire { get; internal set; } = false;
    [field: SerializeField]
    [field: Range(0.1f, 2f)]
    public float WeaponDelay { get; internal set; } = .1f;
    [field: SerializeField]
    [field: Range(0, 15)]
    public float SpreadAngle { get; set; } = 5;
    public bool MultiBulletShoot { get => multiBulletShoot; set => multiBulletShoot = value; }

    [SerializeField]
    private bool multiBulletShoot = false;
    [SerializeField]
    private int bulletCount = 0;


    internal int GetButtetCountToSpawn()
    {
        if (MultiBulletShoot)
        {
            return bulletCount;
        }
        else
            return 1;
    }
#if UNITY_EDITOR
    [CustomEditor(typeof(GunWeaponDataSO))]
    class MyClassEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            GunWeaponDataSO self = (GunWeaponDataSO)target;
            serializedObject.Update();

            if (self.multiBulletShoot)
            {
                DrawDefaultInspector();  // Show all properties
            }
            else
            {
                DrawPropertiesExcluding(serializedObject, "bulletCount"); // Hide 'otherVariable'
            }

            serializedObject.ApplyModifiedProperties();
        }
    }
#endif
}
