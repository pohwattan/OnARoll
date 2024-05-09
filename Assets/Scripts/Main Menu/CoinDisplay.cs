using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CoinDisplay : MonoBehaviour
{
    private TMP_Text coins;
    
    void Start()
    {
        coins = GetComponent<TMP_Text>();
        UpdateCoinDisplay();
    }

    private void UpdateCoinDisplay()
    {
        int totalCoins = CoinManager.GetTotalCoins();
        coins.text = totalCoins.ToString();
    }
}
