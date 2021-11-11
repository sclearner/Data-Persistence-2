using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.IO;
#if UNITY_EDITOR
    using UnityEditor;
#endif

public class MenuUIHandler : MonoBehaviour
{
    public InputField playerInput;
    [System.Serializable]
    class CurrentPlayer
    {
        public string player;
    }
    private void Start()
    {
        DataManager.Instance.player = LoadPlayerName();
        if (DataManager.Instance != null) playerInput.text = DataManager.Instance.player;
    }
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
        SavePlayerName();
    }

    public void ResetPlayerName()
    {
        playerInput.text = "";
        DataManager.Instance.player = "Player";
    }
    public void SavePlayerName()
    {
        CurrentPlayer playerData = new CurrentPlayer();
        playerData.player = DataManager.Instance.player;
        string json = JsonUtility.ToJson(playerData);

        File.WriteAllText(Application.persistentDataPath + "/current-player.json", json);
    }

    public string LoadPlayerName()
    {
        string path = Application.persistentDataPath + "/current-player.json";
        if (File.Exists(path))
        {
            CurrentPlayer playerData = JsonUtility.FromJson<CurrentPlayer>(File.ReadAllText(path));
            return playerData.player;
        }
        return "Player";
    }
}
