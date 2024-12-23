using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class KillerChecker : MonoBehaviour
{
    [SerializeField] private GameObject killer;
    [SerializeField] private Vector3 killerRotate;

    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.CompareTag("KillerPos"))
        {
            if(other.gameObject.transform.childCount == 0)
            {
                Debug.Log("no");
                GameObject killerPrefab = Instantiate(killer, other.gameObject.transform.position, Quaternion.identity);
                killerPrefab.transform.SetParent(other.gameObject.transform);
                killerPrefab.transform.Rotate(killerRotate);
                killerPrefab.name = killer.name;
            }
            {
                Debug.Log("yes");
            }
        }
    }
}
