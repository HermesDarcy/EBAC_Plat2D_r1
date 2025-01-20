using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ManageUi : MonoBehaviour
{
    
    public TMP_Text textLifes,textCoins;
    public SpinCoin coin;

    public LifeBase lifeBase;

    private void Start()
    {
        
    }


    private void Update()
    {
        LifesText(lifeBase.wLife().ToString());
        
        if(Input.GetKeyDown(KeyCode.J)) { coin.spinExec(); }

    }


    public void LifesText(string text)
    {
        textLifes.text = "Lifes: "+ text;
    }


    public void CoinsText(int coins)
    {
        textCoins.text = "X " + coins.ToString();
        coin.spinExec();
    }
    
}
