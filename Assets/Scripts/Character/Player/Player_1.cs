using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : ActorReform
{
    public PlayerID ID;
    public PlayerStatsSO playerStats;
    public int instanceID;
    private static Dictionary<int,GameObject> instances = new Dictionary<int, GameObject>();
    public CharacterType characterType;

    private void Awake()
    {
       
        if (characterType == CharacterType.Player)
        {
            if (instances.ContainsKey(instanceID))
            {
                var existing = instances[instanceID];
                if (existing != null)
                {
                    if (ReferenceEquals(gameObject, existing))
                    {
                        return;
                    }
                    //Destroy(gameObject);
                    return;
                }
            }
            playerStats.load();
            instances[instanceID] = gameObject;
            DontDestroyOnLoad(gameObject);
        }
    }
    private void Start()
    {
        ID.playerEvents.onRespawn?.Invoke();
    }


}
public enum CharacterType
{
    Player,
    Enemy,
    Other
}