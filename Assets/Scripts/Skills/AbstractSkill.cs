using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class AbstractSkill : PlayerSystem
{
    public int maxLevel { get; set; }
    public int level;

    public bool canUse { get; protected set; }
    [SerializeField]
    protected float[] cooldown = {1,4,3,2,1};
    [SerializeField]
    protected int[] durationCost= { 20, 30, 40, 50, 60 };


    public virtual void OnUsed()
    {
        print("dang su dung");
    }
    public int GetDurationCost()
    {
        return durationCost[level];
    }
    public float GetCowndown()
    {
        return cooldown[level];
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
