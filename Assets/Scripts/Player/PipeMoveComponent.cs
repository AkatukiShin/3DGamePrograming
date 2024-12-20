using System;
using DG.Tweening;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PipeMoveComponent : MonoBehaviour
{
    private bool canPipeIn;

    void PipeIn()
    {
        if (canPipeIn)
        {
            Debug.Log("PipeIn!");
            this.gameObject.transform.DOMove(new Vector3(-8.6f, -7.5f, 0.1f), 1.0f);
            Invoke("SceneLoader", 2.0f);
        }
    }

    void SceneLoader()
    {
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
