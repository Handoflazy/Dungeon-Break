using Pathfinding;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnightGFX : MonoBehaviour
{
    // Start is called before the first frame update
    public AIPath aiPath;
    public Animator anim;
    void Update()
    {

        if (aiPath.desiredVelocity.x >= 0.01f)
        {
            transform.localScale = new Vector3(-1,1,1);

        }
        else if(aiPath.desiredVelocity.x <= -0.01f)
        {
            transform.localScale = Vector3.one;
        }
        
        if (aiPath.desiredVelocity.magnitude > 0)
        {

            anim.SetFloat("speed_f", 0.3f);
        }
        else
        {

            anim.SetFloat("speed_f", 0f);
        }
        print(anim.GetFloat("speed_f"));
    }
}
