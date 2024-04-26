using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatDummyController : MonoBehaviour
{
    [SerializeField]
    private float knockbackDeathSpeedX, knockbackDeathSpeedY, deathTorque;
    [SerializeField]
    private PlayerID playerID;
    private GameObject aliveGO, brokenTopGo, brokenBotGo;
    private Rigidbody2D rbAlive, rbBrokenTop, rbBrokenBot;
    private Animator aliveAnim;


    public bool playerFacingLeft;

    private void OnEnable()
    {
        playerID.playerEvents.OnLeftSide += OnPlayerFacingLeft;
    }
    private void OnPlayerFacingLeft(bool onLeft)
    {
        playerFacingLeft = onLeft;
    }
    private void Start()
    {

        aliveGO = transform.Find("Alive").gameObject;
        brokenTopGo = transform.Find("Broken Top").gameObject;
        brokenBotGo = transform.Find("Broken Bottom").gameObject;

        aliveAnim = aliveGO.GetComponent<Animator>();
        rbAlive = aliveGO.GetComponent<Rigidbody2D>();
        rbBrokenBot = brokenBotGo.GetComponent<Rigidbody2D>();
        rbBrokenTop = brokenTopGo.GetComponent<Rigidbody2D>();

        aliveGO.SetActive(true);
        brokenTopGo.SetActive(false);
        brokenBotGo.SetActive(false);


    }
    private readonly int playerOnLeft = Animator.StringToHash("playerOnLeft");
    private readonly int damage = Animator.StringToHash("damage");
    public void OnHit()
    {
        aliveAnim.SetBool(playerOnLeft, playerFacingLeft);
        aliveAnim.SetTrigger(damage);
    }
    public void Die()
    {
        Vector2 playerFacingDirection = Vector2.up;
        if (playerFacingLeft)
        {
            playerFacingDirection = Vector2.left;
        }
        else
        {
            playerFacingDirection = Vector2.right;
        }
        aliveGO.SetActive(false);
        brokenBotGo.SetActive(true); 
        brokenTopGo.SetActive(true);
        print("is dummy death"); 
        brokenTopGo.transform.position = aliveGO.transform.position;
        brokenBotGo.transform.position = aliveGO.transform.position;
        rbBrokenTop.velocity = new Vector2(playerFacingDirection.x*knockbackDeathSpeedX, knockbackDeathSpeedY);
        rbBrokenTop.AddTorque(deathTorque * -playerFacingDirection.x, ForceMode2D.Impulse);

    }
}
