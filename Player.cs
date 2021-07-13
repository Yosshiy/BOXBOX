using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Playerの動き
/// </summary>
public class Player : MonoBehaviour
{
    Rigidbody2D Rigid;
    //動くスピード
    [SerializeField] float Speed;

    private void Start()
    {
        Rigid = GetComponent<Rigidbody2D>();
    }

    /// <summary>
    /// ジャンプの処理
    /// </summary>
    private void Update()
    {
        var hori = Input.GetAxis("Horizontal");
        Rigid.velocity = new Vector2(hori * Speed,Rigid.velocity.y);
    }

}
