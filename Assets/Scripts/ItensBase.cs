using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Play.HD.Singleton;

public class ItensBase : Singleton<ItensBase>
{
   
   


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            ColletedCoin();
        }
    }


    protected virtual void ColletedCoin()
    {

        gameObject.SetActive(false);
    }


    protected virtual void onColleted()
    { }
}
