using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Duration : PlayerSystem
{
    public int MaxDuration { get; private set; }

    public bool IsFull { get  =>CurrentDuration>=MaxDuration;}

    [field:SerializeField]
    public int CurrentDuration { get; private set; }

    private void OnEnable()
    {
        player.ID.playerEvents.OnRefillDuration += RefillDuration;
        player.ID.playerEvents.OnLevelUp += SetMaxDuration;
    }

    private void OnDisable()
    {
        player.ID.playerEvents.OnRefillDuration -= RefillDuration;
        player.ID.playerEvents.OnLevelUp -= SetMaxDuration;
    }
    private void Start()
    {

        //MaxDuration = PlayerPrefs.GetInt(PrefConsts.MAX_DURATION_KEY);
        CurrentDuration = PlayerPrefs.GetInt(PrefConsts.CURRENT_DURATION_KEY);
        player.ID.playerEvents.onInitialDuration?.Invoke(MaxDuration);
        player.ID.playerEvents.OnDurationChanged?.Invoke(CurrentDuration);
    }
    public void Update()
    {
        //SaveDuration();
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
        if (!PlayerPrefs.HasKey(PrefConsts.CURRENT_DURATION_KEY))
        {
            CurrentDuration = MaxDuration;
            SaveDuration();
        }
        else
        {
            CurrentDuration = PlayerPrefs.GetInt(PrefConsts.CURRENT_DURATION_KEY);
        }
        
    }
    public void SetMaxDuration()
    {
        int temp = player.playerStats.duration - MaxDuration;

        MaxDuration = player.playerStats.duration;
        RefillDuration(temp);
        player.ID.playerEvents.onInitialDuration?.Invoke(MaxDuration);
        //SetMaxHealthBar?.Invoke(MaxHealth);
        SaveDuration();
    }
    public void InitialDuration()
    {
        MaxDuration = player.playerStats.duration;
        //CurrentDuration = MaxDuration;
        //CurrentDuration = PlayerPrefs.GetInt(PrefConsts.CURRENT_DURATION_KEY);
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
        SaveDuration();
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
        SaveDuration();
        player.ID.playerEvents.OnDurationChanged?.Invoke(CurrentDuration);
    }
    public void SaveDuration()
    {
        PlayerPrefs.SetInt(PrefConsts.CURRENT_DURATION_KEY, CurrentDuration);
        PlayerPrefs.SetInt(PrefConsts.MAX_DURATION_KEY, MaxDuration);
        PlayerPrefs.Save();
    }
}
