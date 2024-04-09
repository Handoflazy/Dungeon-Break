using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyReform : MonoBehaviour
{
    public PlayerID ID;

    private void Start()
    {
        ID.playerEvents.onRespawn?.Invoke();
    }
}
