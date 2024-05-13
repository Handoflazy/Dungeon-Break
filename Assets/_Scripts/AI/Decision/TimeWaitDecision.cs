using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeWaitDecision : AIDecision
{
    [SerializeField]
    float waitTime = 3f;

    private bool isWaiting = false;
    public override bool MakeDecision()
    {
        print(isWaiting);
       if(isWaiting == false) 
       {
            StartCoroutine(Wait());
       }
       isWaiting = true;
       return isWaiting;
    }

    private IEnumerator Wait()
    {
        yield return new WaitForSeconds(waitTime);  
    }
}
