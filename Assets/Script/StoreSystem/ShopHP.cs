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
                player.coin -= 50;
                player.HP += 1;
                OrderText.text = "HP : + 1";
                OrderText.CrossFadeAlpha(0f, 1f, false);
            }

            else if (!Regeneratable)
            {
                if (player.coin <= 50)
                {
                    OrderText.text = "You don't have enough coins";
                    OrderText.CrossFadeAlpha(0f, 1f, false);
                }

                if (player.HP == 3)
                {
                    OrderText.text = "You Can't Regenerate";
                    OrderText.CrossFadeAlpha(0f, 1f, false);
                }
            }

          
        }

    }
}
