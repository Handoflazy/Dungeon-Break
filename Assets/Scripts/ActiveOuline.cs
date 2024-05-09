using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveOuline : MonoBehaviour
{
    [SerializeField]
    private SpriteRenderer spriteRenderer = null;

    private Shader originalMaterialShader;

    [SerializeField]
    private Material outlineMaterial = null;
    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        originalMaterialShader = spriteRenderer.material.shader;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        ActivateOuline();
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        DeactivateOuline();
    }
    public void ActivateOuline()
    {
        if (spriteRenderer.material.HasProperty(ShaderConst.OUTLINE) == false)
        {
            originalMaterialShader = outlineMaterial.shader;
        }
        spriteRenderer.material.SetInt(ShaderConst.OUTLINE, 1);
    }
    public void DeactivateOuline()
    {
        if (spriteRenderer.material.HasProperty(ShaderConst.OUTLINE) == false)
        {
            originalMaterialShader = outlineMaterial.shader;
        }
        spriteRenderer.material.SetInt(ShaderConst.OUTLINE, 0);
    }
}
