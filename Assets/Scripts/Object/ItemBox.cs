using System;
using UnityEngine;

public class ItemBox : MonoBehaviour
{
    public static ItemBox instance;
    
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
        if (other.gameObject.CompareTag("Head")  && !isHit)
        {
            HitPlayer();
        }
    }

    public void HitPlayer()
    {
        if (item != null)
        {
            Instantiate(item, itemPos.transform.position, Quaternion.identity);
            isHit = true;
        }
        GetComponent<MeshRenderer>().material = hittedColor;
    }
}
