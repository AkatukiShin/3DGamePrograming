using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
 
public class CameraFollow : MonoBehaviour
{

    public static bool isFollow = true;
 
    private GameObject player;   //プレイヤー情報格納用
    private Vector3 offset;      //相対距離取得用
 
    // Use this for initialization

    private void Awake()
    {
        //unitychanの情報を取得
        player = GameObject.Find("Player");
 
        // MainCamera(自分自身)とplayerとの相対距離を求める
        offset = transform.position - player.transform.position;
    }
	
    // Update is called once per frame
    void Update () {

        if (isFollow)
        {
            //新しいトランスフォームの値を代入する
            transform.position = player.transform.position + offset;
        }
    }
}