using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinManger : MonoBehaviour
{
    private int coinNumber = 0;

    public int GetCoin
    {
        get { return coinNumber; }
        
    }
    
    public int SetCoin(int coin)
    {
        coinNumber += coin;
        return 0;
    }
}
