using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

/// <summary>
/// ゲームクリア、オーバーの管理
/// </summary>
public class ClearManager : MonoBehaviour
{
    [SerializeField] Canvas GOCanvas;
    [SerializeField] Text GOText;
    [SerializeField] Image GOPanel;
    [SerializeField] Canvas GCCanvas;
    [SerializeField] Text GCText;
    [SerializeField] Image GCPanel;
    bool Animflag = false;
    int ClearCount;
    const int MaxClearCount = 2;

    public void AddClearCount(int value)
    {
        ClearCount += value;
        if (isClear())
        {
            GameClear();
        }
          
    }

    /// <summary>
    /// クリア判定
    /// </summary>
    bool isClear()
    {
        if(ClearCount == MaxClearCount)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
 
    /// <summary>
    /// ゲームオーバー処理
    /// </summary>
    public void GameOver()
    {
        Branch(GOCanvas, GOText, GOPanel);
    }

    /// <summary>
    /// ゲームクリアー処理
    /// </summary>
    public void GameClear()
    {
        Branch(GCCanvas, GCText, GCPanel);
    }

    /// <summary>
    /// 分岐処理
    /// </summary>
    /// <param name="canvas">Activeになるcanvas</param>
    /// <param name="text">AnimationさせるText</param>
    /// <param name="panel">AnimationさせるImage</param>
    public void Branch(Canvas canvas,Text text,Image panel)
    {
        if (Animflag)
        {
            return;
        }
        Animflag = true;
        GameManager.Instance.PlayerStop();
        canvas.gameObject.SetActive(true);

        string newtext = text.text;
        text.text = "";

        //アニメーション完了までの時間
        float duration = 2;

        text.DOText(newtext, duration)
              .SetEase(Ease.Linear)
              .OnComplete
              (() => TextMove(text,panel));
    }

    /// <summary>
    /// Textの移動
    /// </summary>
    void TextMove(Text text, Image panel)
    {
        //アニメーション完了までの時間
        float duration = 2;
        text.rectTransform.DOLocalMove(Vector3.zero, duration).OnComplete(() => Fade(text,panel));
    }

    /// <summary>
    /// フェード
    /// </summary>
    void Fade(Text text, Image panel)
    {
        //アニメーション完了までの時間
        float duration = 2;

        text.DOFade(0, duration);
        panel.DOFade(1, duration).OnComplete(()=>Back());
    }

    void Back()
    {
        GameManager.Instance.GetSceneManager().BackHome();
    }
}
