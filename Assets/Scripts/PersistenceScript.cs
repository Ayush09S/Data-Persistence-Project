using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;
using Unity.IO;
using System;
using System.IO;

public class PersistenceScript : MonoBehaviour
{
    public static PersistenceScript instance;

    public Button startButton;

    public string savedCurrentName; // Current User's Name
    public int savedCurrentScore; 

    public string savedRecentName; // Recent Player's Name
    public int savedRecentScore;

    public string savedHighName; // High Score Player's Name
    public int savedHighScore; 

    public int saveScoreAmount = 0;

    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(gameObject);
    }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        LoadScores();
    }

    [Serializable]
    public class SaveData
    {
        public string savedExternallyRecentName;
        public int savedExternallyRecentScore;

        public string savedExternallyHighName;
        public int savedExternallyHighScore;
    }

    public void SaveScores()
    {
        SaveData data = new SaveData();

        data.savedExternallyRecentName = savedRecentName;
        data.savedExternallyRecentScore = savedRecentScore;

        data.savedExternallyHighName = savedHighName;
        data.savedExternallyHighScore = savedHighScore;

        string json = JsonUtility.ToJson(data);
        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void LoadScores()
    {
        string path = Application.persistentDataPath + "/savefile.json";
    
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            savedRecentName = data.savedExternallyRecentName;
            savedRecentScore = data.savedExternallyRecentScore;

            savedHighName = data.savedExternallyHighName;
            savedHighScore = data.savedExternallyHighScore;
        }
    }
}