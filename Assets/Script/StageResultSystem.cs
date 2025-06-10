using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor.SceneManagement;
using UnityEngine;

[System.Serializable]

public class StageResult
{
    public string playerName;
   
    public int stage;
   
    public int score;

    public int Coin;
}
[System.Serializable]

public class StageResultList
{
    public List<StageResult> results = new List<StageResult>();
}

public static class StageResultSaver
{
    private const string FILE = "GameScore_Results.json";
    private const string PLAYER_NAME = "PlayerName";
    private const string COIN = "COIN";
    private static string filePath = Path.Combine(Application.persistentDataPath, FILE);
    
    public static void SaveStage(int stage, int score)
    {
        StageResultList list = LoadInternal();
        string playerName = PlayerPrefs.GetString(PLAYER_NAME, "");
        string coinSTR = PlayerPrefs.GetString(COIN, "");
        int coin = 0;
        int.TryParse(coinSTR, out coin);

        StageResult entry = new StageResult
        {
            playerName = playerName,
            stage = stage,
            score = score,
            Coin = coin
        };
        list.results.Add(entry);
        string json = JsonUtility.ToJson(list, true);
        File.WriteAllText(filePath, json);
    }
    private static StageResultList LoadInternal()
    {
        if (File.Exists(filePath))
            return new StageResultList();
        string json = File.ReadAllText(filePath);
        StageResultList list = JsonUtility.FromJson<StageResultList>(json);
        if(list == null)
            return new StageResultList();
        else
            return list;
    }
}
