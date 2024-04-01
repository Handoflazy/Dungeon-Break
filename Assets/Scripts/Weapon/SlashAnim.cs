using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlashAnim : MonoBehaviour
{
    [SerializeField]
    Transform localTransform;
    private Animator animator;

    public static SlashAnim instance;
    private void Awake()
    {
        instance = this;
        localTransform = gameObject.transform;
        animator = GetComponent<Animator>();
    }
    public void ActivateEffect()
    {
        transform.SetPositionAndRotation(localTransform.position, localTransform.rotation);
        gameObject.SetActive(true);
        animator.Play("Entry_Slash");
        
        
    }

   

    public void DeactivateEffect()
    {
        gameObject.SetActive(false);
        transform.SetPositionAndRotation(localTransform.position, localTransform.rotation);
        transform.localScale = Vector3.one;
    }


}
