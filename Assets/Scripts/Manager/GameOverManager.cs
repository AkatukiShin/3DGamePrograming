using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour
{
    public static GameOverManager instance;
    public static bool isDead = false;
    [SerializeField] private GameObject player;
    [SerializeField] private Image missImage;

    private Vector3 currentPosition;
    private Vector3 targetPosition;
    private Vector3 endPosition;
    private float time;
    private float fallTime;
    private bool isTransform = false;
    private void Awake()
    {
        instance = this;
        DontDestroyOnLoad(this.gameObject);
    }

    private void FixedUpdate()
    {
        if (isTransform)
        {
            time += Time.deltaTime;
            player.transform.position = Vector3.MoveTowards(currentPosition, targetPosition, time * 3f);
        }

        if (player.transform.position == targetPosition)
        {
            fallTime += Time.deltaTime;
            player.transform.position = Vector3.MoveTowards(player.transform.position, endPosition, fallTime * 5.0f);
        }
    }

    public void GameOver()
    {
        Debug.Log("GameOver");
        missImage.gameObject.SetActive(true);
        currentPosition = player.transform.position;
        targetPosition = currentPosition + new Vector3(0, 3, -2.0f);
        endPosition = currentPosition - new Vector3(0, 10, -2.0f);
        Collider collider = player.GetComponent<BoxCollider>();
        Rigidbody rigidbody = player.GetComponent<Rigidbody>();
        CameraFollow.isFollow = false;
        collider.enabled = false;
        rigidbody.isKinematic = true;
        player.transform.Translate(player.transform.position.x, player.transform.position.y, -2.0f, Space.Self);
        //player.transform.Rotate(0, 90, 0);
        isTransform = true;
        Invoke("SceneLoder", 3.0f);
    }

    void SceneLoder()
    {
        missImage.gameObject.SetActive(false);
        SceneManager.LoadScene(0);
    }
    
}
