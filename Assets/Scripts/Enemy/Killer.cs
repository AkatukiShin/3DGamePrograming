using System;
using Unity.VisualScripting;
using UnityEngine;

public class Killer : MonoBehaviour
{
    public static Killer instance;
    [SerializeField] private float serchAngle = 45.0f;
    [SerializeField] private float fireTime = 2.0f;
    [SerializeField] private float speed = 3.0f;

    private GameObject player;
    private Rigidbody rb;
    private Vector3 posDelta;
    private int state = 0;
    private float time = 0;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (state == 1)
        {
            posDelta = player.transform.position - this.transform.position;
            this.transform.rotation = Quaternion.LookRotation(posDelta, Vector3.forward);
            time += Time.deltaTime;
            if(time >= fireTime)
            {
                state = 2;
            }
        }
        if(state == 2) Move();
    }

    private void Move()
    {
        this.transform.position += posDelta * (speed * Time.deltaTime);
    }

    public void DestroyKiller()
    {
        if(gameObject != null) Destroy(gameObject);
    }
    
    public int GetSetState
    {
        get { return state;}
        set { state = value; }
    }
    public int SetTime
    {
        set { state = value; }
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            float targetAngle = Vector3.Angle(this.transform.position, other.gameObject.transform.position);
            if (targetAngle <= serchAngle)
            {
                Debug.Log("serch");
                player = other.gameObject;
                state = 1;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            float targetAngle = Vector3.Angle(this.transform.position, other.gameObject.transform.position);
            if (targetAngle > serchAngle)
            {
                Debug.Log("lost");
                state = 0;
                time = 0;
            }
        }
    }
}
