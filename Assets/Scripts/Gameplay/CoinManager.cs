using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinManager : MonoBehaviour
{
    private const string TotalCoinsKey = "TotalCoins";

    public static int GetTotalCoins()
    {
        return PlayerPrefs.GetInt(TotalCoinsKey, 0);
    }

    public static void AddCoins(int amount)
    {
        int totalCoins = GetTotalCoins();
        totalCoins += amount;
        PlayerPrefs.SetInt(TotalCoinsKey, totalCoins);
        PlayerPrefs.Save();
    }
}
