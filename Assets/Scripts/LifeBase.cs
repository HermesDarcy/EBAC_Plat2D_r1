using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class LifeBase : MonoBehaviour
{
    public flashColor flash;
    private int startLife;
    private int life;
    private bool isLife = true;

    private void Init()
    {
        startLife = 5;
        life = startLife;
        isLife = true;
    }

    private void Awake()
    {
        Init();
    }

    void Update()
    {
        if(isLife == false)
        {
            StartCoroutine(myDeath());
            
        }
    }


    public void Damage(int damage)
    {
        if (!isLife) return; // return não executa o restatne do codigo


        life -= damage;
        if(life <= 0) 
        {
            isLife = false;
            Debug.Log("morte");
        
        }
        flash.onFlash();
        

    }

    

    IEnumerator myDeath()
    {
        
        transform.DOScale(0, 2.9f).SetEase(Ease.OutBack);
        yield return new WaitForSecondsRealtime(2.9f);
        yield return new WaitForEndOfFrame();
        gameObject.SetActive(false);
    }


    public int wLife()
    {
        return life;


    }


}
