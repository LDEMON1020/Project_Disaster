using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ShopHP : MonoBehaviour
{
    public Player player;

    public TextMeshProUGUI OrderText;

    public bool Regeneratable = false;

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
    }

    // Start is called before the first frame update
    
    public void CheckingHP()
    {
        if (Regeneratable)
        {
            if (player.coin >= 50)
            {
                OrderText.text = "";
                player.coin -= 50;
                player.HP += 1;
                OrderText.text = "HP : + 1";
            }

            else if (player.coin < 50)
            {
                OrderText.text = "";
                OrderText.text = "You don't have enough coins";
            }
        }
        else if (!Regeneratable)
        {
            if (player.HP == 3 && player.coin >= 50)
            {
                OrderText.text = "";
                OrderText.text = "You Can't Regenerate";
            }

            if(player.HP == 3 && player.coin < 50)
                {
                    OrderText.text = "";
                    OrderText.text = "You Can't Regenerate";
                }
        }
    }
    void CheckingStamina()
    {

    }
}
