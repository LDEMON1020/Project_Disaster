using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndingShop : MonoBehaviour
{
    public Player player;

    public TextMeshProUGUI OrderText2;

    public void ChoiceGun()
    {
        if (player.coin >= 250)
        {
            player.coin -= 50;
            GameDataManager.Instance.playerData.Coin = player.coin;
            GameDataManager.Instance.SaveData();
            SceneManager.LoadScene("GameEnd_Gun");
        }

        else if (player.coin < 250)
        {
            OrderText2.text = "";
            OrderText2.text = "You don't have enough coins";
        }
    }
    public void ChoiceLight()
    {
        if (player.coin >= 250)
        {
            player.coin -= 50;
            GameDataManager.Instance.playerData.Coin = player.coin;
            GameDataManager.Instance.SaveData();
            SceneManager.LoadScene("GameEnd_Light");
        }

        else if (player.coin < 250)
        {
            OrderText2.text = "";
            OrderText2.text = "You don't have enough coins";
        }
    }
}
