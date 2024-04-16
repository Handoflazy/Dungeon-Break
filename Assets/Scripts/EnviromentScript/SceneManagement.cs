using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneManagement : PlayerSystem
{
    public string SceneTransitionName;

    
    public void SetTransitionName(string SceneStransitionName)
    {
        this.SceneTransitionName = SceneStransitionName;
    }
}

