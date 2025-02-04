using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinUp : ItensBase
{
    
    private int value;
    protected override void onColleted()
    {
        base.onColleted();
        ItemManager.Instance.addCoins(value);
    }






    // Start is called before the first frame update
    void Start()
    {
        value = 1;
    }

}
