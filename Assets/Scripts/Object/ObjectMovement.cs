using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectMovement : MonoBehaviour
{
    [SerializeField] private float MovementSpeed = 1;
    void Update()
    {
        transform.Translate(new Vector3(MovementSpeed/100, 0, 0));
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Object"))
        {
            transform.Rotate(new Vector3(0, 180, 0));
        }
    }
}
