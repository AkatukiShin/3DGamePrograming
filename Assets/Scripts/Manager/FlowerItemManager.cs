using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cysharp.Threading.Tasks;
using DG.Tweening;

public class FlowerItemManager : MonoBehaviour
{
    [SerializeField] private List<FlowerAndPipes> flowerAndPipes = new();

    private int id;

    public enum MoveDirection
    {
        North,
        East,
        South,
        West,
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void FlowerCheck(GameObject flower)
    {
        string flowerid = flower.name.Substring(11, 2);
        id = int.Parse(flowerid);
        PipeMover(id);
        Debug.Log(id);
    }
    void PipeMover(int id)
    {
        if (flowerAndPipes[id].MoveDirection == MoveDirection.North)
        {
            
        }
        else if (flowerAndPipes[id].MoveDirection == MoveDirection.East)
        {
            GameObject obj = flowerAndPipes[id].PipeObject;
            obj.transform.DOMove(new Vector3(obj.transform.position.x + 10,obj.transform.position.y ,0),2.0f);
            Debug.Log("moved");
        }
        else if (flowerAndPipes[id].MoveDirection == MoveDirection.South)
        {
            GameObject obj = flowerAndPipes[id].PipeObject;
            obj.transform.DOMove(new Vector3(obj.transform.position.x ,obj.transform.position.y -10 ,0),2.0f);
        }
        else if (flowerAndPipes[id].MoveDirection == MoveDirection.West)
        {
            
        }
    }
}

/*
 * pipemanagerに
 * フラワー獲ったらpipemanagerに情報がいく
 * pipemanagerからpipemoverまたはコインを設置する関数かスクリプトを呼び出す
*/

[System.Serializable]
public class FlowerAndPipes
{
    public GameObject FlowerItem;
    public GameObject PipeObject;
    public FlowerItemManager.MoveDirection MoveDirection;
    public GameObject Coin;
}