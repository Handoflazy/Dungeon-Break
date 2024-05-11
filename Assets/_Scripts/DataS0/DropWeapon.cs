using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Shooter
{
    public class DropWeapon : MonoBehaviour
    {
        [field: SerializeField]
        public  GameObject GunPrefab { get; set; }
        private AudioSource audioSource;
        private bool interacted = false;
        private SpriteRenderer spriteRenderer;
        [field: SerializeField]
        public int BulletNumber { get; set; } = 0;
        private void Awake()
        {
            audioSource = GetComponent<AudioSource>();
            gameObject.name = GunPrefab.name;
            spriteRenderer = GetComponent<SpriteRenderer>();
        }

        private void Start()
        {
            gameObject.name = GunPrefab.name + "Dropped";
            spriteRenderer.sprite = GunPrefab.GetComponent<SpriteRenderer>().sprite;
        }
        public void OnEquip()
        {
            if (!interacted)
            {
                FindObjectOfType<WeaponParent>().SetWeapon(GunPrefab, BulletNumber);
                interacted = true;
                StartCoroutine(PlaySFX());
                if (GunPrefab.name == "assault_rifle")
                {
                    PlayerPrefs.SetInt(PrefConsts.CURRENT_GUN_KEY, 0);
                }
                else if(GunPrefab.name == "ShortGun")
                {
                    PlayerPrefs.SetInt(PrefConsts.CURRENT_GUN_KEY, 1);
                }
            }
        }
        IEnumerator PlaySFX()
        {
            audioSource.Play();
            yield return new WaitForSeconds(audioSource.clip.length);
            Destroy(gameObject);
        }


    }
}