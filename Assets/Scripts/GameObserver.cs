using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameObserver : MonoBehaviour
{

    private void Start()
    {
        PlayerPrefs.SetInt("CoinAmount", 0);
    }
    public static void SaveCoinsToMemory(int amount)
    {
        PlayerPrefs.SetInt("CoinAmount", amount);
    }
}
