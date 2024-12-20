using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadLine : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("dead");
            GameOverManager.isDead = true;
            GameOverManager.instance.GameOver();
        }
    }
}
