using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class ButtonManagen : MonoBehaviour
{
    public List<GameObject> buttonsList = new List<GameObject>();
    public float dutation, delai;
    public Ease ease;

    private void hideButtons()
    {
        foreach (var bt in buttonsList) 
        {
            bt.transform.localScale = Vector3.zero;
            bt.SetActive(false);
                   
        }
    }

    private void showButtons()
    {
        
        foreach(var bt in buttonsList)
        {
            bt.transform.DOScale(1, dutation).SetDelay(delai).SetEase(ease);
            bt.SetActive(true);

        }
    }

    private void OnEnable()
    {
        hideButtons();
        showButtons();
    }

    public void exitMenu()
    {
        Application.Quit();
    }


    public void isPlay()
    {
        SceneManager.LoadScene(1);
    }

}
