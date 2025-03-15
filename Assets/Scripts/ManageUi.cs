using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ManageUi : MonoBehaviour
{
    
    public TMP_Text textLifes,textCoins, textEndCoins;
    public SpinCoin coin;
    public Image imageVic;
    public LifeBase lifeBase;
    public GameObject PanelEngGame, PanelGame;
    


    private void Start()
    {
        PanelEngGame.SetActive(false);
        PanelGame.SetActive(true);
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
        textEndCoins.text = "X " + coins.ToString();
        coin.spinExec();
    }
    

    public void exitGame()
    {
        Application.Quit();
    }

    public void isEndGame()
    {
        PanelGame.SetActive(false);
        PanelEngGame.SetActive(true);
       
        imageVic.transform.DOScale(2f, 2f);
        StartCoroutine(endGame());
       
    }


    public void inPause()
    {
        Time.timeScale = 0f;
    }

    public void outPause()
    {
        Time.timeScale = 1f;
    }

    IEnumerator endGame()
    {
        yield return new WaitForSeconds(2f);
        inPause();
    }


}
