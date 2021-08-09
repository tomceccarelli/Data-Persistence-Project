using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class MainManager : MonoBehaviour
{
    public static MainManager Instance;
    public string playerName;
    public int highScore;


    // Singleton pattern
    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    [System.Serializable]
    class SaveData
    {
        public string playerName;
        public int highScore;
    }

    // After loading high score data, we check if the player set a new high score and if so, we save it
    public void SaveHighScore()
    {
        string[] highScoreData = LoadHighScore();
        if (int.Parse(highScoreData[1]) <= highScore)
        {
            SaveData data = new SaveData();
            data.playerName = playerName;
            data.highScore = highScore;

            string json = JsonUtility.ToJson(data);

            File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
        }
    }

    // We try loading high score data from a JSON, if the file exist we return it's values in a string array, if not we return default values
    public string[] LoadHighScore()
    {
        string[] highScoreData = new string[2];
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            highScoreData[0] = data.playerName;
            highScoreData[1] = "" + data.highScore;
        }
        else
        {
            highScoreData[0] = "Name";
            highScoreData[1] = "0";
        }
        return highScoreData;
    }
}
