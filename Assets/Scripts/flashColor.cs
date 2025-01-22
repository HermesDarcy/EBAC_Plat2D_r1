using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class flashColor : MonoBehaviour
{
    public List<SpriteRenderer> renderers;
    public Color color;
    public float duration;
    [SerializeField]
    private Tween _current;


    private void Start()
    {
        foreach (var renderer in transform.GetComponentsInChildren<SpriteRenderer>())
        {
            renderers.Add(renderer);
        }
    }





    private void OnValidate()
    {
        
    }


    public void onFlash()
    {
        

        

        if(_current != null)
        {
            _current.Kill();
            foreach (var renderer in renderers)
            {
                renderer.color = Color.white;

            }

            // renderers.ForEach(renderer => { renderer.color = Color.white; }); // outra tecnica 

            
        }



        foreach (var renderer in renderers)
        {
            renderer.DOColor(color, duration).SetLoops(2,LoopType.Yoyo);

            renderer.DOColor(Color.white, duration);

            renderer.color = Color.white;

        }

        //renderers.ForEach(renderer => { renderer.color = Color.white; }); // outra tecnica

        

    }




}
