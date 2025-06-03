using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public TMP_InputField inputField;
    public Button gameStartButton;
    // Start is called before the first frame update
    private void Start()
    {
        gameStartButton.onClick.AddListener(OnGameStartButtonClicked);
    }

    private void OnGameStartButtonClicked()
    {
        string playerName = inputField.text;
        if(string.IsNullOrEmpty(playerName))
        {
            Debug.Log("�÷��̾� �̸��� �Է��ϼ���.");
            return;
        }

        PlayerPrefs.SetString("PlayerName", playerName);
        PlayerPrefs.Save();

        Debug.Log("�÷��̾��� �̸� ���� ��: " + playerName);

        SceneManager.LoadScene("Play_Scene");
    }
}
