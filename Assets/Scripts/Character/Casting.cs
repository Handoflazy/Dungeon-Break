using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Casting : MonoBehaviour
{
    public Transform firePoint;

    //Skill fireball
    public GameObject fireBall_Pref;
    public float fireBallRate = 2f;
    public float fireBallRange = 2f;
    public float fireBallCooldown = 2f;
    private float timeSinceLastE = 0f;

    //Normal attack
    public GameObject normalAttack_Pref;
    public float normalAttackRate = 2f;
    public float normalAttackRange = 2f;
    public float normalAttackCooldown = 0f;
    private float timeSinceLastFired = 0f;

    //Shield
    public Transform Player;
    public GameObject shield_Pref;
    //public float shieldForce = 2f;
    //public float shieldRange = 2f;
    private GameObject currentShield;
    public float shieldDuration = 5f;
    public float shieldCooldown = 3f;
    private float timeSinceLastQ = 0f;

    // Update is called once per frame
    void Update()
    {
        timeSinceLastFired += Time.deltaTime;
        timeSinceLastE += Time.deltaTime;
        timeSinceLastQ += Time.deltaTime;
        if (Input.GetMouseButtonDown(0) && timeSinceLastFired >= normalAttackCooldown)
        {
            Cast(firePoint, normalAttack_Pref, normalAttackRate, normalAttackRange);
            timeSinceLastFired = 0f;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha1) && timeSinceLastE >= fireBallCooldown)
        {
            Cast(firePoint, fireBall_Pref, fireBallRate, fireBallRange);
            timeSinceLastE = 0f;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2) && timeSinceLastQ >= shieldCooldown)
        {
            EnableShield();
            timeSinceLastQ = 0f;
        }
        UpdateShieldPosition();
    }

    void Cast(Transform ObjectPoint, GameObject Object_Ref, float ObjectForce, float ObjectRange)
    {
        GameObject Object = Instantiate(Object_Ref, ObjectPoint.position, ObjectPoint.rotation);
        Rigidbody2D rb = Object.GetComponent<Rigidbody2D>();
        rb.AddForce(ObjectPoint.right * ObjectForce, ForceMode2D.Impulse);

        StartCoroutine(DestroyFireBall(Object, ObjectRange));
    }

    IEnumerator DestroyFireBall(GameObject fireBall, float range)
    {
        yield return new WaitForSeconds(range);
        Destroy(fireBall);
    }

    IEnumerator DestroyShield(GameObject currentShield, float time)
    {
        yield return new WaitForSeconds(time);
        Destroy(currentShield);
        // Bật collider của player
        Collider2D playerCollider = Player.GetComponent<Collider2D>();
        playerCollider.enabled = true;
    }

    void EnableShield()
    {
        if (currentShield == null)
        {
            currentShield = Instantiate(shield_Pref, Player.position, Player.rotation);
            // Tắt collider của player
            //Collider2D playerCollider = Player.GetComponent<Collider2D>();
            //playerCollider.enabled = false;
        }
        StartCoroutine(DestroyShield(currentShield, shieldDuration));
    }

    void DisableShield()
    {
        if (currentShield != null)
        {
            Destroy(currentShield);
            currentShield = null;

            // Bật collider của player
            //Collider2D playerCollider = Player.GetComponent<Collider2D>();
            //playerCollider.enabled = true;
        }
    }

    void UpdateShieldPosition()
    {
        if (currentShield != null)
        {
            currentShield.transform.position = Player.position;
        }
    }
}



