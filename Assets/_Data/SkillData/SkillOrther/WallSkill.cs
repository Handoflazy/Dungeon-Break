using System.Collections;
using UnityEngine;

public class WallSkill : AbstractSkill
{
    [SerializeField]
    protected AudioClip activeSkill;


    [SerializeField]
    protected GameObject wall;
    [SerializeField]
    private float distanceWall = 0.5f;
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

        BoomGlue();
    }

    public void BoomGlue()
    {

        Vector2 targetPosition = GetPointerPos();
        Vector2 currentPosition = transform.position;


        Vector2 direction = (targetPosition - currentPosition).normalized;
        //float distance = Vector2.Distance(targetPosition, currentPosition);

        Vector2 finalPosition = currentPosition + direction * distanceWall;

        GameObject sword = Instantiate(wall, finalPosition, Quaternion.identity);
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        sword.transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle - 90));
        Destroy(sword, 3f);


    }

}
