using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JointTransition : PlayerSystem
{
    public string TransitionName;
    private void Start()
    {
     
        if (TransitionName==NguyenSingleton.Instance.SceneManagement.SceneTransitionName)
        {
            GameObject player = GameObject.Find("Player");
            player.transform.position = gameObject.transform.position;
            NguyenSingleton.Instance.UIfade.FadeToClear();
     
        }
    }
}
