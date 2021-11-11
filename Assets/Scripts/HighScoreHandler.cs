using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class HighScoreHandler : MonoBehaviour
{
    // Start is called before the first frame update
    public Text highScore;
    public int h_score = 0;

    public void LoadHighScore() { 
    
    }
    public void UpdateHighScore(int score)
    {
        highScore.text = string.Format("High score: {0}: {1}", DataManager.Instance.player, score);
        h_score = score;
    }

}
