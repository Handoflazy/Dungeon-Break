using System.Collections;
using UnityEngine;

public class TeleportSkill : AbstractSkill
{
    [SerializeField]
    protected AudioClip activeSkill;

    [SerializeField]
    protected float teleportDistance = 10f;

    [SerializeField]
    protected GameObject teleportGate;
    [SerializeField]
    private LayerMask wallLayerMask;
    private AudioSource audioSource;

    protected override void Awake()
    {
        base.Awake();
        cooldown = 2;
        audioSource = GetComponent<AudioSource>();
    }

    public override void OnUsed()
    {
        audioSource.PlayOneShot(activeSkill);

        Teleport();
    }

    public void Teleport()
    {
        GameObject gate_1 = Instantiate(teleportGate,transform.position, Quaternion.identity);

        Vector2 targetPosition = GetPointerPos();
        Vector2 currentPosition = transform.position;


        Vector2 direction = (targetPosition - currentPosition).normalized;
        float distance = Vector2.Distance(targetPosition, currentPosition);

        distance = Mathf.Min(distance, teleportDistance);

        RaycastHit2D hit = Physics2D.Raycast(currentPosition, direction, distance, wallLayerMask);
        if (hit.collider != null)
        {
            distance = hit.distance;
        }

        Vector2 finalPosition = currentPosition + direction * distance;

        GameObject gate_2 = Instantiate(teleportGate, finalPosition, Quaternion.identity);
        transform.position = finalPosition;
        Destroy(gate_1, 0.6f);
        Destroy(gate_2, 1f);
        
        
    }

}
