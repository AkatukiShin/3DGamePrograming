using System;
using DG.Tweening;
using Microsoft.Unity.VisualStudio.Editor;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PipeMoveComponent : MonoBehaviour
{
    private bool canPipeIn;
    [SerializeField] GameObject transition;

    void PipeIn()
    {
        if (canPipeIn)
        {
            Debug.Log("PipeIn!");
            this.gameObject.transform.DOMove(new Vector3(-8.6f, -7.5f, 0.1f), 1.0f);
            transition.gameObject.SetActive(true);
            transition.transform.DOMove(new Vector3(-0.09f, -5.0f, -7.67f), 3.0f);
            Invoke("SceneLoader", 4.0f);
        }
    }

    void SceneLoader()
    {
        GameObject gameoverManger = GameObject.Find("GameOverManager");
        GameObject canvas = GameObject.Find("Canvas");
        GameObject uiManager = GameObject.Find("UiManager");

        DontDestroyOnLoad(gameoverManger);
        DontDestroyOnLoad(canvas);
        DontDestroyOnLoad(uiManager);
        DontDestroyOnLoad(this.gameObject);

        SceneManager.LoadScene(1);
    }
    
    public void PipeInAction(InputAction.CallbackContext context)
    {
        if(context.performed) PipeIn();
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("PipeHead"))
        {
            canPipeIn = true;
        }
    }
}
