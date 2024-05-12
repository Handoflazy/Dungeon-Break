using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCDialog : Collidable
{
    [SerializeField] string message;
    private float cooldown = 4;
    private float lastTime;
    protected override void Start()
    {
        DGSingleton.Instance.FloatingTextManager.Show("Welcome", 50, Color.white, transform.position + new Vector3(0, 0.16f, 0), Vector3.zero, 1);
        base.Start();
        lastTime = -cooldown;
    }
    protected override void OnCollide(Collider2D other)
    {
        if (other.GetComponent<Player>() != null)
        {
            if (Time.time - lastTime > cooldown)
            {
                lastTime = Time.time;
                DGSingleton.Instance.FloatingTextManager.Show(message, 50, Color.white, transform.position + new Vector3(0, 0.16f, 0), Vector3.zero, cooldown);
            }
        }
    }

}
