using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Play.HD.Singleton;

public class ItensBase : MonoBehaviour

{
    public ParticleSystem fxCoin;



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            ColletedCoin();
        }
    }


    protected virtual void ColletedCoin()
    {
        if (fxCoin != null) fxCoin.Play();
        gameObject.SetActive(false);
        onColleted();
    }


    protected virtual void onColleted()
    { 
    
    }





}
