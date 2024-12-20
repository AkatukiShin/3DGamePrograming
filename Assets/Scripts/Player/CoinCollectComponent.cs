using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinCollectComponent : MonoBehaviour
{
    private CoinManger coinMangerObj;
    void Start()
    {
        GameObject obj = GameObject.Find("CoinManager");
        coinMangerObj = obj.GetComponent<CoinManger>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Coin"))
        {
            coinMangerObj.SetCoin(1);
        }
    }
}
