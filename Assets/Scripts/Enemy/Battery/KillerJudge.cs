using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillerJudge : MonoBehaviour
{
    [SerializeField] private GameObject killer;

    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.CompareTag("KillerPos"))
        {
            if (other.gameObject.transform.childCount == 0)
            {
                GameObject killerPrefab = Instantiate(killer, other.gameObject.transform.position, Quaternion.identity);
                killerPrefab.transform.parent = other.transform;
            }
            else
            {
                Debug.Log("yes");
            }
        }
    }
}
