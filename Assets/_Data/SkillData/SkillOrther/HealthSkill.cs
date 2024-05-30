using PlayerController;
using System.Collections;
using UnityEngine;

public class HealthSkill : AbstractSkill
{
    [SerializeField]
    protected AudioClip soundSkill;

    [SerializeField]
    protected GameObject healPrefabs;
    [SerializeField]
    protected int healAmount = 25;
    private AudioSource audioSource;
    
    protected override void Awake()
    {
        base.Awake();
        cooldown = 2;
        audioSource = GetComponent<AudioSource>();
    }

    public override void OnUsed()
    {
        audioSource.PlayOneShot(soundSkill);
        HealthHP();
    }

    public void HealthHP()
    {
        if (TryGetComponent<PlayerHealth>(out PlayerHealth health))
        {
            if (health.isFull) { return; }
            GameObject healPref = Instantiate(healPrefabs, transform.position, Quaternion.identity);
            health.AddHealth(healAmount);
            Destroy(healPref, 0.3f);
        }
    }

}
