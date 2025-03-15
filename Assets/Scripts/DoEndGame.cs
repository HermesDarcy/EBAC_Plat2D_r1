using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class DoEndGame : MonoBehaviour
{

    public ManageUi manageUi;
    
    public AudioTransf transf;

    

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
           transf.MakeTransition();
           manageUi.isEndGame();
        }
    }


   

}
