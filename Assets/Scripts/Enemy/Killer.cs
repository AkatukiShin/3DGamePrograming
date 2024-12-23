using System;
using Unity.VisualScripting;
using UnityEngine;

public class Killer : MonoBehaviour
{
    public static Killer instance;
    [SerializeField] private float serchAngle = 45.0f;
    [SerializeField] private float fireTime = 2.0f;
    [SerializeField] private float speed = 3.0f;

    [SerializeField] private Material serchKillerHead;
    [SerializeField] private Material defaultKillerHead;

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
        Debug.Log("hello");
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("serch");
        if(InPlayer(other.gameObject))
        {
            GameObject head = other.transform.Find("Head").gameObject;
            head.GetComponent<MeshRenderer>().material = serchKillerHead;
            Debug.Log("serch");
        }
	}

    private void OnTriggerStay(Collider other) 
    {
        if(InPlayer(other.gameObject))
        {
            //Debug.Log("serch");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(exitPlayer(other.gameObject))
        {
            GameObject head = other.gameObject.transform.GetChild(1).gameObject;
            head.GetComponent<MeshRenderer>().material = defaultKillerHead;
        }
    }

    private bool InPlayer(GameObject other)
    {
        if( other.tag == "Player")
		{
			Vector3 posDelta = other.transform.position - transform.position;
			float targetAngle = Vector3.Angle(transform.forward, posDelta);
            //Debug.Log("視界の範囲内＆視界の角度内＆障害物なし");
			if( targetAngle < serchAngle)
			{
				//if( Physics.Raycaswt(transform.position,new Vector3(posDelta.x,0f,posDelta.z),out RaycastHit hit))
				//{
				//	if( hit.collider == other)
				//	{
						
				//	}
				//}
                return true;
			}
		}
        return false;
    }

    private bool exitPlayer(GameObject other)
    {
        if( other.tag == "Player")
		{
			Vector3 posDelta = other.transform.position - transform.position;
			float targetAngle = Vector3.Angle(transform.forward, posDelta);
			if( targetAngle >= serchAngle)
			{
				//if( Physics.Raycaswt(transform.position,new Vector3(posDelta.x,0f,posDelta.z),out RaycastHit hit))
				//{
				//	if( hit.collider == other)
				//	{
				//		Debug.Log("視界の範囲内＆視界の角度内＆障害物なし");
				//	}
				//}
                return true;
			}
		}
        return false;
    }
    //private void Update()
    //{
    //    if (state == 1)
    //    {
    //        this.transform.parent = null;
    //        posDelta = player.transform.position - this.transform.position;
    //        this.transform.rotation = Quaternion.LookRotation(posDelta, Vector3.forward);
    //        time += Time.deltaTime;
    //        if(time >= fireTime)
    //        {
    //            state = 2;
    //        }
    //    }
    //    if(state == 2) Move();
    //}
//
    //private void Move()
    //{
    //    this.transform.position += posDelta * (speed * Time.deltaTime);
    //}
//
    //public void DestroyKiller()
    //{
    //    if(gameObject != null) Destroy(gameObject);
    //}
    //
    public int GetSetState
    {
        get { return state;}
        set { state = value; }
    }
    public int SetTime
    {
        set { state = value; }
    }
    //
    //private void OnTriggerEnter(Collider other)
    //{
    //    if (other.gameObject.CompareTag("Player"))
    //    {
    //        float targetAngle = Vector3.Angle(this.transform.position, other.gameObject.transform.position);
    //        if (targetAngle <= serchAngle)
    //        {
    //            Debug.Log("serch");
    //            player = other.gameObject;
    //            state = 1;
    //        }
    //    }
    //}
//
    //private void OnTriggerExit(Collider other)
    //{
    //    if (other.gameObject.CompareTag("Player"))
    //    {
    //        float targetAngle = Vector3.Angle(this.transform.position, other.gameObject.transform.position);
    //        if (targetAngle > serchAngle)
    //        {
    //            Debug.Log("lost");
    //            state = 0;
    //            time = 0;
    //        }
    //    }
    //}
}
