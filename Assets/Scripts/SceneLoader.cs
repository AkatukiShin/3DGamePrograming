using System;
using DG.Tweening;
using UnityEngine;
using UnityEngine.SceneManagement;

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
        Scene stage1 = SceneManager.GetSceneByName("Stage1");
        SceneManager.MoveGameObjectToScene(obj,stage1);

        GameObject gameoverManger = GameObject.Find("GameOverManager");
        GameObject canvas = GameObject.Find("Canvas");
        GameObject uiManager = GameObject.Find("UiManager");

        SceneManager.MoveGameObjectToScene(gameoverManger,stage1);
        SceneManager.MoveGameObjectToScene(canvas,stage1);
        SceneManager.MoveGameObjectToScene(uiManager,stage1);
        
        Invoke("GravityOn", 1.0f);
    }

    void GravityOn()
    {
        obj.GetComponent<Rigidbody>().useGravity = true;

    }
}