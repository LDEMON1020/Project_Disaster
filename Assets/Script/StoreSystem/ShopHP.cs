using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using static UnityEditor.Timeline.TimelinePlaybackControls;

public class ShopHP : MonoBehaviour
{
    public Player player;

    public TextMeshProUGUI OrderText;

    public bool Regeneratable = false;

    public bool MaxStaminaUP = false;

    private void Update()
    {
        if (player.HP >= 1 && player.HP < 3)
        {
            Regeneratable = true;
        }
        else if (player.HP == 3)
        {
            Regeneratable = false;
        }

        if(player.MaxStamina >= 50 && player.MaxStamina < 100)
        {
            MaxStaminaUP = true;
        }
        else if (player.MaxStamina == 100)
        {
            MaxStaminaUP = false;
        }
       
    }

    // Start is called before the first frame update
    
    public void CheckingHP()
    {
        if (Regeneratable)
        {
            if (player.coin >= 50)
            {
                player.coin -= 50;
                GameDataManager.Instance.playerData.Coin = player.coin;
                player.HP += 1;
                player.CoinText.text = "Coin : " + player.coin;
                OrderText.text = "HP : + 1";
                GameDataManager.Instance.SaveData();
            }

            else if (player.coin < 50)
            {
                OrderText.text = "You don't have enough coins";
            }
        }
        else if (!Regeneratable)
        {
            if (player.HP == 3 && player.coin >= 50)
            {
                OrderText.text = "You Can't Regenerate";
            }

            if(player.HP == 3 && player.coin < 50)
                {
                    OrderText.text = "You Can't Regenerate";
                }
        }
    }
    public void CheckingStamina()
    {
        if (MaxStaminaUP)
        {
            if (player.coin >= 50)
            {
                player.coin -= 50;
                player.MaxStamina += 10f;
                GameDataManager.Instance.playerData.Coin = player.coin;
                GameDataManager.Instance.playerData.MaxStamina = player.MaxStamina;
                player.CoinText.text = "Coin : " + player.coin;
                OrderText.text = "StaminaUP! : + 10";
                GameDataManager.Instance.SaveData();
            }

            else if (player.coin < 50)
            {
                OrderText.text = "You don't have enough coins";
            }
        }
        else if (!MaxStaminaUP)
        {
            if (player.MaxStamina == 100 && player.coin >= 50)
            {
                OrderText.text = "You Can't Upgrade!!!";
            }

            if (player.MaxStamina == 100 && player.coin < 50)
            {
                OrderText.text = "You Can't Upgrade!!!";
            }
        }
    }
}
