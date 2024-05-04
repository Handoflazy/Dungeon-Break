
using UnityEngine;
public static class Prefs
{
    
    public static int coins
    {
        set=> PlayerPrefs.SetInt(PrefConsts.COIN_KEY, value);
        get => PlayerPrefs.GetInt(PrefConsts.COIN_KEY, 0);
    }
    public static string playerData
    {
        set => PlayerPrefs.SetString(PrefConsts.PLAYER_DATA_KEY, value);
        get => PlayerPrefs.GetString(PrefConsts.PLAYER_DATA_KEY, "");
    }


    public static bool IsEnoughCoins(int coinToCheck)
    {
        return coins >= coinToCheck;
    }
}
