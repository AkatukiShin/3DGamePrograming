using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootHit : MonoBehaviour
{
    private GameObject player;
    private Rigidbody plRigidbody;

    private void Start()
    {
        player = transform.parent.gameObject;
        plRigidbody = player.GetComponent<Rigidbody>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Killer"))
        {
            Destroy(other.gameObject.transform.parent.gameObject);
            plRigidbody.AddForce(new Vector3(0,15,0), ForceMode.Impulse);
        }
        if (other.gameObject.CompareTag("Enemy"))
        {
            Destroy(other.gameObject);
            plRigidbody.AddForce(new Vector3(0,15,0), ForceMode.Impulse);
        }
    }
}
