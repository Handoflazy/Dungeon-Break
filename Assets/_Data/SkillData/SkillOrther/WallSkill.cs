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
    private GameObject shield;

    protected override void Awake()
    {
        base.Awake();
        cooldown = 2;
        audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (shield != null)
        {
            Vector2 targetPosition = GetPointerPos();
            Vector2 currentPosition = transform.position;


            Vector2 direction = (targetPosition - currentPosition).normalized;
            //float distance = Vector2.Distance(targetPosition, currentPosition);

            Vector2 finalPosition = currentPosition + direction * distanceWall;

            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            shield.transform.position = finalPosition;
            shield.transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle - 180));
        }
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

        shield = Instantiate(wall, finalPosition, Quaternion.identity);
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        shield.transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle - 180));
        Destroy(shield, 3f);


    }

}
