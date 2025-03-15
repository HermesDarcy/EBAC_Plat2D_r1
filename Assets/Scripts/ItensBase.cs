using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Play.HD.Singleton;

public class ItensBase : MonoBehaviour

{
    public ParticleSystem fxCoin;
    public AudioSource audio;
    public Collider2D collider;


    private void Start()
    {
        
        audio.Stop();
    }




    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            ColletedCoin();
            if(collider != null) collider.enabled = false;
        }
    }


    protected virtual void ColletedCoin()
    {
        if (fxCoin != null) fxCoin.Play();
        if (audio != null)
        {
            audio.Play();
           
        }
        
        gameObject.SetActive(false);
        onColleted();
    }


    protected virtual void onColleted()
    { 
        
            
    }





}
