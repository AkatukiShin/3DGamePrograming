using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scaffold : MonoBehaviour
{
    private GameObject scafffold;
    private Collider scaffoldCollider;
    
    private bool inCheck;
    private bool outCheck;
    void Start()
    {
        scafffold = transform.parent.gameObject;
        scaffoldCollider = scafffold.GetComponent<BoxCollider>();
        if (this.gameObject.CompareTag("InCheck"))
        {
            inCheck = true;
        }
        if (this.gameObject.CompareTag("OutCheck"))
        {
            outCheck = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(inCheck && other.gameObject.CompareTag("Head")) PlayerIn();
        if(outCheck && other.gameObject.CompareTag("Foot")) PlayerOut();
    }

    private void PlayerIn()
    {
        scaffoldCollider.enabled = false;
    }

    private void PlayerOut()
    {
        scaffoldCollider.enabled = true;
    }
}
