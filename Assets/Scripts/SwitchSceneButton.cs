using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SwitchSceneButton : MonoBehaviour
{
    public enum SceneType
    {
        PRELOADER = 0,
        MAIN_MENU = 1,
        LEVEL_1 = 2,
        LEVEl_2 = 3
    }
    [SerializeField] private SceneType _sceneType;
    [SerializeField] private Button _btn;

    private void Awake()
    {
        _btn.onClick.AddListener(() =>
        {
            SceneManager.LoadScene((int) _sceneType);
        });
    }

}
