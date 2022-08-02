using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance;

    public string CurrentPlayer;
    
    public string BestPlayer;
    public int BestScore;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);

        LoadInf();
    }

    [System.Serializable]
    class SaveData
    {
        public string SD_LastPlayer;

        public string SD_BestPlayer;
        public int SD_BestScore;
    }
    public void SaveInf()
    {
        SaveData data = new SaveData();

        data.SD_LastPlayer = CurrentPlayer;
        data.SD_BestPlayer = BestPlayer;
        data.SD_BestScore = BestScore;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void LoadInf()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            CurrentPlayer = data.SD_LastPlayer;
            BestPlayer = data.SD_BestPlayer;
            BestScore = data.SD_BestScore;
        }
    }
}
