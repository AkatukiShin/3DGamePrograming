using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flag : MonoBehaviour
{
    [SerializeField] private Material flagColor;

    private GameObject flag;

    private bool isPlayerHit  = false;
    // Start is called before the first frame update
    void Start()
    {
        flag = transform.GetChild(3).gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!isPlayerHit)
        {
            isPlayerHit = true;
            flag.GetComponent<MeshRenderer>().material = flagColor;
        }
    }
}
