using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
#if UNITY_EDITOR
    using UnityEditor;
#endif

public class MenuUIHandler : MonoBehaviour
{
    public InputField playerInput;
    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    public void Exit()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Exit();
#endif
    }
    
    public void NewPlayerName()
    {
        DataManager.Instance.player = playerInput.text;
    }

    public void ResetPlayerName()
    {
        playerInput.text = "";
        DataManager.Instance.player = "Player";
    }
}
