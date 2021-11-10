using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
#if UNITY_EDITOR
    using UnityEditor;
#endif

public class MenuUIHandler : MonoBehaviour
{
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
    public void NewPlayerName(GameObject playerName)
    {
        DataManager.Instance.player = playerName.GetComponent<InputField>().text;
    }
}
