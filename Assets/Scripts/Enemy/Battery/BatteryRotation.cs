using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatteryRotation : MonoBehaviour
{
    [SerializeField] private float rotationSpeed = 1.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void FixedUpdate() {
        this.gameObject.transform.Rotate(new Vector3(0, 0, rotationSpeed));
    }
}
