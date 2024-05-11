using PlayerController;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ItemManager : PlayerSystem
{
    [SerializeField]
    private int MedikitCount, AmmoBoxCount;
    [SerializeField]
    private int medikitHealAmount = 20;
    [SerializeField]
    private int medikitCapacity = 5, ammoBoxCapacity = 5;
    [SerializeField]

    public UnityEvent useAmmoBox;
    public UnityEvent useMedikit;


    private BasicGun currentGun = null;

    public bool IsMedikitFull { get => MedikitCount >= medikitCapacity; }
    public bool IsAmmoFull { get => AmmoBoxCount >= ammoBoxCapacity; }


    private void OnEnable()
    {
        player.ID.playerEvents.OnUseMedit += UseMedit;
        player.ID.playerEvents.OnUseAmmoBox += UseAmmoBox;
        player.ID.playerEvents.OnChangeGun += OnchangeGun;

    }
    private void OnDisable()
    {
        player.ID.playerEvents.OnUseMedit -= UseMedit;
        player.ID.playerEvents.OnUseAmmoBox -= UseAmmoBox;
        player.ID.playerEvents.OnChangeGun -= OnchangeGun;

    }
    private void Start()
    {
        if (PlayerPrefs.HasKey(PrefConsts.MEDIKIT_COUNT_KEY))
        {
            MedikitCount = PlayerPrefs.GetInt(PrefConsts.MEDIKIT_COUNT_KEY);

        }
        if (PlayerPrefs.HasKey(PrefConsts.AMMOBOX_COUNT_KEY))
        {
            AmmoBoxCount = PlayerPrefs.GetInt(PrefConsts.AMMOBOX_COUNT_KEY);
        }
        player.ID.playerEvents.OnUpdateMedikit?.Invoke(MedikitCount);
        player.ID.playerEvents.OnUpdateAmmoBox?.Invoke(AmmoBoxCount);
        currentGun = GetComponentInChildren<BasicGun>();


    }

    private void OnchangeGun(BasicGun gun)
    {
        currentGun = gun;
    }

    public void AddMedikit(int number)
    {
        MedikitCount += number;
        PlayerPrefs.SetInt(PrefConsts.MEDIKIT_COUNT_KEY, MedikitCount);
        MedikitCount = Mathf.Clamp(MedikitCount, 0, medikitCapacity);
        player.ID.playerEvents.OnUpdateMedikit?.Invoke(MedikitCount);

    }
    public void AddAmmoBox(int number)
    {
        AmmoBoxCount += number;
        PlayerPrefs.SetInt(PrefConsts.AMMOBOX_COUNT_KEY, AmmoBoxCount);
        AmmoBoxCount = Mathf.Clamp(AmmoBoxCount, 0, ammoBoxCapacity);
        player.ID.playerEvents.OnUpdateAmmoBox?.Invoke(AmmoBoxCount);
    }
    public void UseMedit()
    {
        if (MedikitCount > 0)
        {
            if (TryGetComponent<PlayerHealth>(out PlayerHealth health))
            {
                if (health.isFull) { return; }
                health.AddHealth(medikitHealAmount);
                MedikitCount--;
                PlayerPrefs.SetInt(PrefConsts.MEDIKIT_COUNT_KEY, MedikitCount);
                player.ID.playerEvents.OnUpdateMedikit?.Invoke(MedikitCount);
                useMedikit?.Invoke();

            }
        }
    }

    public void UseAmmoBox()
    {
        if (AmmoBoxCount > 0)
        {
            if (currentGun)
            {
                if (currentGun.AmmoFull)
                {
                    return;
                }
                currentGun.FullReload();
                AmmoBoxCount--;
                PlayerPrefs.SetInt(PrefConsts.AMMOBOX_COUNT_KEY, AmmoBoxCount);
                player.ID.playerEvents.OnUpdateAmmoBox?.Invoke(AmmoBoxCount);
                useAmmoBox?.Invoke();
            }
        }
    }
}