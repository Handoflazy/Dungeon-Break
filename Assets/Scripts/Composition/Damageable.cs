using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Assertions.Must;
using PlayerController;
using SunnyValleyVersion;

namespace FirstVersion
{
    [RequireComponent(typeof(Health))]
    public class Damageable : MonoBehaviour
    {
        Health health;
        private void Awake()
        {
            health = GetComponent<Health>();
        }
        public void DealDamage(int dmg,GameObject sender)
        {
            if(sender.transform.root.gameObject.layer==gameObject.layer)
            {
                return;
            }
            NguyenSingleton.Instance.FloatingTextManager.Show(dmg.ToString(), 10, Color.red, transform.position, Vector3.zero, 0.5f);
            health.TakeDamage(dmg,sender.transform.root.gameObject);       
        }
    }
}