using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemObject : MonoBehaviour
{
    [SerializeField] ItemSO data;
    [SerializeField] CoinSO coin;

    public int GetPoint()
    {
        return data.point;
    }

    public int GetCoin()
    {
        return coin.Coin;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
