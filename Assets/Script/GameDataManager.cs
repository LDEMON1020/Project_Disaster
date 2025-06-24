using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[Serializable]

public class PlayerData
{
    public List<string> collectedItems = new List<String>();
    public int stage = 1;
    public int Coin = 0;
    public float Hp = 2f;
    public float MaxStamina = 50f;
}
public class GameDataManager : MonoBehaviour
{
    public static GameDataManager Instance;
    public PlayerData playerData;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void SaveData()
    {
        string filePath = Application.persistentDataPath + "/player_data.json";
        string json = json = JsonUtility.ToJson(playerData, true);
        System.IO.File.WriteAllText(filePath, json);
        Debug.Log("���� ������ �����: " + json);
    }

    public PlayerData LoadData()
    {
        string filePath = Application.persistentDataPath + "/player_data.json";
        if(System.IO.File.Exists(filePath))
        {
            string json = System.IO.File.ReadAllText(filePath);
            PlayerData playerData = JsonUtility.FromJson<PlayerData>(json);
            Debug.Log("���� ������ �ε��: " + json);
            return playerData;
        }
        else 
        {
            Debug.LogWarning("������ ���� �����Ͱ� �����ϴ�.");
            return new PlayerData()
            {
                Coin = 0,
                Hp = 2f,
                MaxStamina = 50f
            };
        }
    }
    public void GameStart()
    {
        playerData = LoadData();
        if (playerData == null)
            playerData = new PlayerData();
        
        if (playerData.MaxStamina <= 0f)
        {
            playerData.MaxStamina = 50f;
            SaveData();
        }
        SceneManager.LoadScene("Play_Scene_Scary");
    }

    public void PlayerDead()
    {
        PlayerData playerData = LoadData();
        if (playerData != null)
        {
            playerData.stage = 1;

            SaveData();
        }
        SceneManager.LoadScene("GameOver");
    }
}
