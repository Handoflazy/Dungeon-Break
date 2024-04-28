using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlashAnim : MonoBehaviour
{
    private Animator animator;
    private void Awake()
    {
        animator = GetComponent<Animator>();
       
    }
    private readonly int Slash = Animator.StringToHash(AnimConsts.ENTRY_SLASH_PARAM); // MỚI 


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
