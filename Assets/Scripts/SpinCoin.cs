using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class SpinCoin : MonoBehaviour
{
    public float duration;
   


    public void spinExec()
    {
        StartCoroutine(spinCoin());
    }

    
    IEnumerator spinCoin()
    {
        for(int i = 0; i < 6;i++)
        {
            transform.DOScaleX(-1, duration);
            yield return new WaitForSeconds(duration);
            transform.DOScaleX(1, duration);
            yield return new WaitForSeconds(duration);
        }
        
    }

}
