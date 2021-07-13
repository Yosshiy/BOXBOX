using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Playerが上または下に向かう
/// </summary>
public class PlayerSuction : MonoBehaviour
{
    //力が加わる向き
    public enum PowerDirection
    {
        Up,
        Down
    }
    public PowerDirection Direction;

    Rigidbody2D Rigid;
    //長押し検知用
    bool Downbool;

    private void Start()
    {
        Rigid = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (Downbool)
        {
            if (Direction == PowerDirection.Down)
            {
                Rigid.AddForce(-Vector2.up * 5);
            }
            else if (Direction == PowerDirection.Up)
            {
                Rigid.AddForce(Vector2.up * 5);
            }
        }
    }

    /// <summary>
    /// 長押し開始
    /// </summary>
    public void LongDown()
    {
        Downbool = true;
    }

    /// <summary>
    /// 長押し終了
    /// </summary>
    public void LongUp()
    {
        Downbool = false;
    }

}
