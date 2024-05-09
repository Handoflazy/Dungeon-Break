using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Shooter
{
    [CreateAssetMenu(fileName = "Data/Gun")]

    public class DropWeapon : MonoBehaviour
    {
        [field: SerializeField]
        public GunEquipmentSO Gun { get; set; }
        private AudioSource audioSource;
        private bool interacted = false;
        private SpriteRenderer spriteRenderer;
        [field: SerializeField]
        public int BulletNumber { get; set; } = 0;
        private void Awake()
        {
            audioSource = GetComponent<AudioSource>();
            gameObject.name = Gun.WeaponPrefab.name;
            spriteRenderer = GetComponent<SpriteRenderer>();
        }

        private void Start()
        {
            gameObject.name = Gun.WeaponPrefab.name;
            spriteRenderer.sprite = Gun.WeaponPrefab.GetComponent<SpriteRenderer>().sprite;
        }
        public void OnEquip()
        {
            if (!interacted)
            {
                FindObjectOfType<PlayerWeapon>().SetWeapon(Gun,BulletNumber);
                interacted = true;
                StartCoroutine(PlaySFX());
                
            }
        }
        IEnumerator PlaySFX()
        {
            audioSource.clip = Gun.actionSFX;
            audioSource.Play();
            yield return new WaitForSeconds(Gun.actionSFX.length);
            Destroy(gameObject);
        }


    }
}