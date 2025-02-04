using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ItemCoin : ItensBase
{
    public SO_coins coin;
    [SerializeField]
    private int value;
    


    protected override void onColleted()
    {
        base.onColleted();
        ItemManager.Instance.addCoins(value);
    }
    
        
        
    


    // Start is called before the first frame update
    void Start()
    {
        value = coin.coin;
    }


    private void OnDisable()
    {
        Debug.Log("desligado");
        
        
    }


}


