using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine.UI;
using UnityEngine;

public class HighScoreHandler : MonoBehaviour
{
    // Start is called before the first frame update
    public Text highScore;
    public int h_score = 0;
    [System.Serializable]
    class HighScoreData
    {
        public string player;
        public int highScore;
    }
    public void LoadHighScore() {
        string path = Application.persistentDataPath + "/high-score.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            HighScoreData data = JsonUtility.FromJson<HighScoreData>(json);

            UpdateHighScore(data.player, data.highScore);
        }
    }
    public void UpdateHighScore(string player,int score)
    {
        highScore.text = string.Format("High score: {0}: {1}", player, score);
        h_score = score;
        SaveHighScore(player, score);
    }
    
    public void SaveHighScore(string player, int score)
    {
        HighScoreData highScoreData = new HighScoreData();
        highScoreData.player = player;
        highScoreData.highScore = score;

        string json = JsonUtility.ToJson(highScoreData);

        File.WriteAllText(Application.persistentDataPath + "/high-score.json", json);
    }
}
