using System;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float blinkingInterval = 0.3f;
    [SerializeField] private Renderer playerRenderer;
    
    private PlayerState playerState;
    
    private bool isHitEnemy = false;
    private bool isInvincible = false;
    
    private float time;

    enum PlayerState
    {
        Normal,
        PowerUp,
    }

    void Start()
    {
        playerState = PlayerState.Normal;
        
    }

    void Blinking()
    {
        isInvincible = true;
        time += Time.deltaTime;
        
        var repeatValue = Mathf.Repeat((float)time, blinkingInterval);
        
        playerRenderer.enabled = repeatValue >= blinkingInterval * 0.5f;
    }

    void IsHitEnemyReset()
    {
        isInvincible = false;
        isHitEnemy = false;
        playerRenderer.enabled = true;
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("DeadLine"))
        {
            GameOverManager.isDead = true;
            GameOverManager.instance.GameOver();
        }
        if (other.gameObject.CompareTag("Enemy")||other.gameObject.CompareTag("Killer"))
        {
            if (!isInvincible)
            {
                if (playerState == PlayerState.PowerUp)
                {
                    Debug.Log("PowerDown");
                    //パワーダウン処理
                    isHitEnemy = true;
                    Invoke("IsHitEnemyReset", 2.0f);
                }

                if (playerState == PlayerState.Normal)
                {
                    Debug.LogWarning(other.gameObject);
                    Debug.Log("dead");
                    GameOverManager.isDead = true;
                    GameOverManager.instance.GameOver();
                }
            }
            else
            {
                Debug.Log("きかぬぅ");
            }
        }
    }
}
