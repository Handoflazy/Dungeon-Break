using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatedCharacter : PlayerSystem
{
    Rigidbody2D rb;
    Vector2 PointerPosition;
    public BoolEvent OnLeftSide;
    public bool isUsingWeapon;


    public void onReponseOnAttackingEvent()
    {
        NguyenSingleton.Instance.floatingTextManager.Show("Nguyen bo doi", 5, Color.blue, transform.position, Vector3.up, 2);
    }
    private void OnUsingWeaponEvent(bool isUsingWeapon)
    {
        this.isUsingWeapon = isUsingWeapon;
    }
    protected override void Awake()
    {
        base.Awake(); rb = GetComponent<Rigidbody2D>();
    }

    private void OnEnable()
    {
       
        player.ID.playerEvents.OnMousePointer += GetPointer;
        player.ID.playerEvents.OnUsingWeapon += OnUsingWeaponEvent;

    }

    private void OnDisable()
    {
        player.ID.playerEvents.OnMousePointer -= GetPointer;
        player.ID.playerEvents.OnUsingWeapon -= OnUsingWeaponEvent;
    }
    private void GetPointer(Vector2 pointerPosition)
    {
        PointerPosition = pointerPosition;
    }
    private void Update()
    {

        if (rb.velocity.magnitude > 0.1)
        {
            anim.SetBool("OnRun", true);
        }
        else
        {
            anim.SetBool("OnRun", false);
        }
        if (isUsingWeapon)
        {
            return;
        }
        Vector2 lookDirection = PointerPosition - (Vector2)transform.position;
        if (lookDirection.x > 0)
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
            OnLeftSide?.Invoke(false);

        }
        else if (lookDirection.x < 0)
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
            OnLeftSide?.Invoke(true);

        }

    }
}
