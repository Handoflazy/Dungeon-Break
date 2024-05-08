using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Shooter
{
    [CreateAssetMenu(fileName = "Data/Gun")]

    public class Weapon : MonoBehaviour
    {
        [field: SerializeField]
        public GunEquipmentSO Gun { get; set; }
        private AudioSource audioSource;
        private bool interacted = false;

        private void Start()
        {
            audioSource = GetComponent<AudioSource>();
            gameObject.name = Gun.WeaponPrefab.name;
        }
        public void OnEquip()
        {
            if (!interacted)
            {
                FindObjectOfType<PlayerWeapon>().SetWeapon(Gun);
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