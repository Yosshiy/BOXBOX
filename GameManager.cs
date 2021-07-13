using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 全体のマネージャー
/// </summary>
public class GameManager : MonoBehaviour
{
    #region シングルトン
    /// <summary>
    /// シングルトン
    /// </summary>
    private static GameManager instance;

    public static GameManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = (GameManager)FindObjectOfType(typeof(GameManager));
                if (instance = null)
                {
                    Debug.LogError(typeof(GameManager) + "が存在しません");
                }
            }

            return instance;
        }
    }

    private void Awake()
    {
        instance = this;
    }
    #endregion

    //クリア判定のスクリプト
    [SerializeField] ClearManager M_Clear;
    //シーン管理のスクリプト
    [SerializeField] _SceneManager M_Scene;
    //上のPlayer
    [SerializeField] Player PlayerA;
    //下のPlayer
    [SerializeField] Player PlayerB;

    /// <summary>
    /// 時間の流れをなくす
    /// </summary>
    public void TimeStop()
    {
        Time.timeScale = 0;
    }

    /// <summary>
    /// 時間の流れを通常に戻す
    /// </summary>
    public void TimeDefault()
    {
        Time.timeScale = 1;
    }

    /// <summary>
    /// ゲームオーバー
    /// </summary>
    public void GameOver()
    {
        M_Clear.GameOver();
    }

    /// <summary>
    /// ゲームクリアー
    /// </summary>
    public void GameClear(int value)
    {
        M_Clear.AddClearCount(value);
    }

    /// <summary>
    /// _ScenManagerの取得
    /// </summary>
    public _SceneManager GetSceneManager()
    {
        return M_Scene;
    }

    /// <summary>
    /// Player停止
    /// </summary>
    public void PlayerStop()
    {
        PlayerA.enabled = false;
        PlayerB.enabled = false;
    }
}
