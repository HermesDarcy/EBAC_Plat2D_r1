using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Play.HD.Singleton;

public class ItemManager : Singleton<ItemManager>
{
    //public List<GameObject> coisList = new List<GameObject>();
    public int coins;
    public ManageUi manageUi;
    
    // Start is called before the first frame update
    void Start()
    {
        //IsReset();
    }

    private void IsReset()
    {
        coins = 0;
    }


    public void addCoins(int c = 1)
    {
        coins += c;
        manageUi.CoinsText(coins);
    }
}
