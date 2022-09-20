using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameObserver : MonoBehaviour
{
    public int amountSlimesKilled = 0;

    private void Start()
    {
        PlayerPrefs.SetInt("CoinAmount", 0);
    }
    public static void SaveCoinsToMemory(int amount)
    {
        PlayerPrefs.SetInt("CoinAmount", amount);
    }
}
