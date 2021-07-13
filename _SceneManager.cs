using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class _SceneManager : MonoBehaviour
{
    //BuildSetting内のScene
    public enum SceneName
    {
        StageSelect,
        Stage1
    }

    public void BackHome()
    {
        SceneManager.LoadScene(SceneName.StageSelect.ToString());
    }

    public void StageGo()
    {
        SceneManager.LoadScene(name.ToString());
    }
}
