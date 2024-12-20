using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillerHead : MonoBehaviour
{
    private Killer killer;
    private Vector3 hitPos;
    private void Start()
    {
        GameObject obj = GameObject.Find("Killer");
        killer = obj.GetComponent<Killer>();
        if(killer == null) Debug.Log("kasu");
    }

    private void OnTriggerEnter(Collider other)
{
    if (other.gameObject.CompareTag("Ground") || other.gameObject.CompareTag("Object"))
    {
        if (killer.GetSetState == 2)
        {
            // 状態をリセット
            killer.GetSetState = 0;

            // ヒットした位置を取得
            hitPos = this.gameObject.transform.position;

            // 面の法線を取得して回転を設定
            if (other is MeshCollider meshCollider && meshCollider.convex)
            {
                // Convex MeshCollider の場合、接触点と法線を取得
                RaycastHit hit;
                if (Physics.Raycast(transform.position, transform.forward, out hit))
                {
                    Vector3 normal = hit.normal; // 接触した面の法線
                    Quaternion rotation = Quaternion.LookRotation(Vector3.forward, normal);
                    rotation *= Quaternion.Euler(-90, 0, 0);
                    killer.gameObject.transform.rotation = rotation;
                }
            }
            else if (other is BoxCollider || other is SphereCollider)
            {
                // シンプルな形状の場合（例: BoxCollider）、回転を直接設定
                Vector3 normal = (transform.position - other.ClosestPoint(transform.position)).normalized;
                Quaternion rotation = Quaternion.LookRotation(Vector3.forward, normal);
                rotation *= Quaternion.Euler(-90, 0, 0);
                killer.gameObject.transform.rotation = rotation;
            }

            // オブジェクトを指定の位置に移動（Z座標を0に固定）
            killer.gameObject.transform.position = new Vector3(hitPos.x, hitPos.y, 0);
            killer.SetTime = 0;
        }
    }
}

}
