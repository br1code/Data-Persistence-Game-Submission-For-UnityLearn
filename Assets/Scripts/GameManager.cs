using System;
using System.IO;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public string PlayerName;
    public int BestScoreValue;
    public string BestScorePlayerName;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
        LoadBestScore();
    }

    public void SaveScore(int score)
    {
        if (score <= BestScoreValue)
        {
            return;
        }

        BestScoreValue = score;
        BestScorePlayerName = PlayerName;

        var data = new SaveData
        {
            BestScoreValue = BestScoreValue,
            BestScorePlayerName = PlayerName
        };

        var json = JsonUtility.ToJson(data);
        var path = Application.persistentDataPath + "/savefile.json";
        File.WriteAllText(path, json);
    }

    public void LoadBestScore()
    {
        var path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            var json = File.ReadAllText(path);
            var data = JsonUtility.FromJson<SaveData>(json);
            BestScoreValue = data.BestScoreValue;
            BestScorePlayerName = data.BestScorePlayerName;
        }
    }

    [Serializable]
    class SaveData
    {
        public int BestScoreValue;
        public string BestScorePlayerName;
    }
}