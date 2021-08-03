using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class Data : MonoBehaviour
{
    public static Data Instance;
    public string NameSelect;
    public int score = 0;
    public string highScorePName;
    private void Awake()
    {
        if(Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
        LoadScore();
    }
    // Start is called before the first frame update
    [System.Serializable]
    class HighScore
    {
        public int highScore;
        public string pName;
        
    }

    public void SaveScore()
    {
        HighScore scores = new HighScore();
        scores.highScore = score;
        scores.pName = highScorePName;

        string json = JsonUtility.ToJson(scores);
        File.WriteAllText(Application.persistentDataPath + "/highscore.json", json);
     }

    public void LoadScore()
    {
        string path = Application.persistentDataPath + "/highscore.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            HighScore scores = JsonUtility.FromJson<HighScore>(json);

            score = scores.highScore;
            highScorePName = scores.pName;
                    }
    }
   
}
