using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CreateAssetMenu(menuName = "Weapons/Weapon Data")]
public class GunWeaponDataSO : ScriptableObject
{
    [field: SerializeField]
    public BulletDataSO BulletData {  get; set; }


    [field: SerializeField]
    [field: Range(1, 100)]
    public int AmmoCapacity { get; private set; } = 100;
    [field: SerializeField]
    public bool AutomaticFire { get; internal set; } = false;
    [field: SerializeField]
    [field: Range(0.1f, 2f)]
    public float WeaponDelay { get; internal set; } = .1f;
    [field: SerializeField]
    [field: Range(0, 10)]
    public float SpreadAngle { get; set; } = 5;
    public bool MultiBulletShoot { get => multiBulletShoot; }

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

    [CustomEditor(typeof(GunWeaponDataSO))]
    class MyClassEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            GunWeaponDataSO self = (GunWeaponDataSO)target;
            serializedObject.Update();

            // Draw 'multiBulletShoot' checkbox first
            EditorGUILayout.PropertyField(serializedObject.FindProperty("multiBulletShoot"));

            if (self.multiBulletShoot)
            {
                // Now draw bullet count
                EditorGUILayout.PropertyField(serializedObject.FindProperty("bulletCount"));
            }

            serializedObject.ApplyModifiedProperties();
        }
    }

}
