using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class AbstractSkill : PlayerSystem
{
    public bool canUse { get; set; }

    [SerializeField]
    protected float cooldown = 5;
    [SerializeField]
    protected int durationCost = 20;


    public virtual void OnUsed()
    {
        print("dang su dung");
    }
    public int GetDurationCost()
    {
        return durationCost;
    }
    public float GetCowndown()
    {
        return cooldown;
    }
    protected virtual Vector2 GetPointerPos()
    {
        Vector3 mousePos;
        mousePos.x = Mouse.current.position.x.ReadValue();
        mousePos.y = Mouse.current.position.y.ReadValue();
        mousePos.z = Camera.main.nearClipPlane;
        return Camera.main.ScreenToWorldPoint(mousePos);
    }
}
