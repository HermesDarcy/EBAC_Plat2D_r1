using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaticCoin : MonoBehaviour
{
    private Rigidbody2D rb;
    private float duration = 0.2f;
    public GameObject coin;
    private Collider2D collider;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        collider = GetComponent<Collider2D>();
    }

    private void Update()
    {
        if(coin.activeInHierarchy==false)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("floor"))
        {
            rb.constraints = RigidbodyConstraints2D.FreezePositionX;
            StartCoroutine(spinCoin());
        }
        if(collision.gameObject.CompareTag("Player"))
        {
            collider.enabled = false;
        }

    }


    IEnumerator spinCoin()
    {
        for (int i = 0; i < 10; i++)
        {
            transform.DOScaleX(-1, duration);
            yield return new WaitForSeconds(duration);
            transform.DOScaleX(1, duration);
            yield return new WaitForSeconds(duration);
        }

    }



}


