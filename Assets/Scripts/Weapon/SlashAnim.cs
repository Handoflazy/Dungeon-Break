using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlashAnim : MonoBehaviour
{
    private Animator animator;
    private SpriteRenderer spriteRenderer;
    public bool FacingLeft { get; set; }

    private void OnDisable()
    {
        AnimatedCharacter.Instance.OnLeftSide -= OnChangeSideEvent;
    }

    private void OnChangeSideEvent(bool onLeft)
    {
        FacingLeft = onLeft;
    }
    private void Awake()
    {
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    private void Start()
    {
        AnimatedCharacter.Instance.OnLeftSide += OnChangeSideEvent;
    }
    private readonly int Slash = Animator.StringToHash("Entry_Slash");
    public void ActivateEffect()
    {
        gameObject.SetActive(true);
        animator.Play(Slash);
    }

   

    public void DeactivateEffect()
    {
        //gameObject.SetActive(false);
    }


}
