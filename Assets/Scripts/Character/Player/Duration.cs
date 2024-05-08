using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Duration : PlayerSystem
{
    public int MaxDuration { get; private set; }

    [field:SerializeField]
    public int CurrentDuration { get; private set; }

    private void OnEnable()
    {
        player.ID.playerEvents.OnRefillDuration += RefillDuration;
    }

    private void OnDisable()
    {
        player.ID.playerEvents.OnRefillDuration -= RefillDuration;
    }
    private void Start()
    {
        player.ID.playerEvents.onInitialDuration?.Invoke(MaxDuration);
    }
    IEnumerator RegeDuration()
    {
        while (true)
        {
            player.ID.playerEvents.OnRefillDuration?.Invoke((int)(0.2f*MaxDuration));
            yield return new WaitForSeconds(4);
        }
    }
    protected override void Awake()
    {
        base.Awake();
        MaxDuration = player.playerStats.duration;
        CurrentDuration = MaxDuration;
    }
    public void InitialDuration()
    {
        MaxDuration = player.playerStats.duration;
        CurrentDuration = MaxDuration;
        player.ID.playerEvents.onInitialDuration?.Invoke(MaxDuration);
        player.ID.playerEvents.OnDurationChanged?.Invoke(CurrentDuration);
    }
    public void ReduceDuration(int durationAmount)
    {
     
        CurrentDuration -= durationAmount;
        if (CurrentDuration <= 0)
        {
         
            CurrentDuration = 0;
        }
        player.ID.playerEvents.OnDurationChanged?.Invoke(CurrentDuration);

    }
    public void RefillDuration(int healAmount)
    {
        if(CurrentDuration >= MaxDuration) { return; }
        CurrentDuration += healAmount;
        if (CurrentDuration > MaxDuration)
        {
            CurrentDuration = MaxDuration;
        }
        player.ID.playerEvents.OnDurationChanged?.Invoke(CurrentDuration);
    }
}
