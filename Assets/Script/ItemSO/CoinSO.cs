using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "Game/Coin", fileName = "CoinData")]
public class CoinSO : ScriptableObject
{
    [Header("Coin Value")]
    public int Coin = 5;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
