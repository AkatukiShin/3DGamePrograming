using System;
using DG.Tweening;
using UnityEngine;
using UnityEngine.SceneManagement;  //追加

public class SceneLoader : MonoBehaviour
{
    private GameObject obj;
    private void Awake()
    {
        obj = GameObject.Find("Player");
        obj.GetComponent<Rigidbody>().useGravity = false;
        obj.transform.position = new Vector3(0, 6, 0);
        obj.transform.Rotate(new Vector3(0, 90, 0));
        obj.transform.DOMove(new Vector3(0, 4.4f, 0), 1.0f);
        
        Invoke("GravityOn", 1.0f);
    }

    void GravityOn()
    {
        obj.GetComponent<Rigidbody>().useGravity = true;

    }
}