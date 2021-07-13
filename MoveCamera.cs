using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// カメラの動き
/// </summary>
public class MoveCamera : MonoBehaviour
{
    //プレイヤー1
    [SerializeField] GameObject PlayerA;
    //プレイヤー2
    [SerializeField] GameObject PlayerB;
    //どこまでカメラが追従するか
    [SerializeField] Vector3 EndPosition;

    void Update()
    {
        //Playerがスタート地点より左に行ったときは何もしない
        if(PlayerA.transform.position.x < 0 && PlayerB.transform.position.x < 0)
        {
            return;
        }

        //Playerがゴール地点より左に行ったときは何もしない
        if(PlayerA.transform.position.x > EndPosition.x || PlayerB.transform.position.x > EndPosition.x)
        {
            return;
        }

        //追従
        var la = Mathf.Max(PlayerA.transform.position.x, PlayerB.transform.position.x);
        transform.position = new Vector3(la,transform.position.y,transform.position.z);
    }

    
}
