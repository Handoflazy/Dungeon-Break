using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Item/ParameterApplyEquipment/ChangeColorSO")]
public class ChangeColorSo : ApplyWeaponParameterSO
{
    [field:SerializeField]
    public Color color = Color.white;
    private Color defaultColor;
    public override void AffectCharacter(GameObject Sender, GameObject character, float val)
    {
        if (character.TryGetComponent(out SpriteRenderer spriteRenderer))
        {
            defaultColor = spriteRenderer.color;
           
        }
    }
    IEnumerator changeColor(SpriteRenderer spriteRenderer,float time)
    {
        spriteRenderer.color = color;
        yield  return new WaitForSeconds(time);
        spriteRenderer.color = defaultColor;

    }
}
