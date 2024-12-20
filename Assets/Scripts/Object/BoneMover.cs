using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class BoneMover : MonoBehaviour
{
    private bool isHitPlayer = false;
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Player") && !isHitPlayer)
        {
            isHitPlayer = true;
            this.transform.DOMove(new Vector3(0, -16, 0), 10.0f);
            Debug.Log("hit");
        }
    }
}
