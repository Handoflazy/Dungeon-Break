using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstSkillManager : MonoBehaviour
{
}

public interface IFirstSkill { }

public class Wideslash:AbtractSkill, IFirstSkill
{
    public Animator swordAnim;


    private void OnEnable()
    {
        player.ID.playerEvents.OnChangeWeapon += OnWeaponChange;
    }



    void OnWeaponChange( Weapon weapon)
    {
        swordAnim = weapon.gameObject.GetComponent<Animator>();
        print(swordAnim);
    }
    private readonly int WideSlash = Animator.StringToHash("WideSlash");
    public override void OnUsed()
    {
        swordAnim.Play(WideSlash);
    }
}

