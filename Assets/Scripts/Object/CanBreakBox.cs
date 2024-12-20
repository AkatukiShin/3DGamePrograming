using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanBreakBox : MonoBehaviour
{
    public static CanBreakBox instance;
    
    [SerializeField] private GameObject item;
    [SerializeField] private GameObject itemPos;
    [SerializeField] private Material hittedColor;

    private bool isHit = false;
    private void Awake()
    {
        instance = this;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("CanBreakBox") && !isHit)
        {
            HitPlayer();
        }
    }

    public void HitPlayer()
    {
        if(item == null) Destroy(this.gameObject);
        else
        {
            Instantiate(item, itemPos.transform.position, Quaternion.identity);
            isHit = true;
        }
        GetComponent<MeshRenderer>().material = hittedColor;
    }
}
