using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UseCoins : MonoBehaviour
{
    public static UseCoins Instance;

    public int Coins;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void UsedCoins (int amount)
    {
        Coins -= amount;
    }

    public bool HasEnoughCoins (int amount)
    {
        return (Coins >= amount);
    }
}
