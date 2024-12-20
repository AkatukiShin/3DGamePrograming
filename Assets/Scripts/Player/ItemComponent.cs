using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemComponent : MonoBehaviour
{
    private FlowerItemManager flowerItemManager;
    private PlayerState playerState;
    
    enum PlayerState
    {
        Normal,
        PowerUp,
    }
    // Start is called before the first frame update
    void Start()
    {
        playerState = PlayerState.Normal;
        GameObject obj = GameObject.Find("FlowerItemManager");
        flowerItemManager = obj.GetComponent<FlowerItemManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("PowerUpItem"))
        {
            if (playerState == PlayerState.Normal)
            {
                PowerUp(other.gameObject);
            }
        }

        if (other.gameObject.CompareTag("FlowerItem"))
        {
            flowerItemManager.FlowerCheck(other.gameObject);
            Destroy(other.gameObject);
        }
    }
    
    void PowerUp(GameObject item)
    {
        gameObject.transform.localScale = new Vector3(1, 2, 1);
        playerState = PlayerState.PowerUp;
        Destroy(item.gameObject);
    }
    
}
