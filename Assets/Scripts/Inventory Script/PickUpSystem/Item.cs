using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Inventory.Model
{
    public class Item : MonoBehaviour
    {
        [field: SerializeField]
        public ItemSO InventoryItem { get; set; }
        [field: SerializeField]
        public int Quantity { get; set; } = 1;

        [SerializeField]
        private AudioSource audioSource;

        [SerializeField]
        private float duration = .3f;



        private void Start()
        {
            GetComponent<SpriteRenderer>().sprite = InventoryItem.ItemImage;
        }
        public void DestroyItem()
        {
            GetComponent<Collider2D>().enabled = false;
            StartCoroutine(AnimateItemPickUp());
        }

        private IEnumerator AnimateItemPickUp()
        {
            audioSource.Play();
            Vector3 startScale = transform.localScale;
            Vector3 endScale = Vector3.zero;
            float currentTime = 0;
            while (currentTime < duration)
            {
                currentTime += Time.deltaTime;
                transform.localScale = Vector3.Lerp(startScale, endScale, currentTime / duration);
                yield return null;
            }
            Destroy(gameObject);
        }
    }
}