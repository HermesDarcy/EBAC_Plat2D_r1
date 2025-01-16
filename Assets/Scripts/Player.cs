using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Player : MonoBehaviour
{
    public float speed,jump,friction, duration,isRun,jumpScaleX,jumpScaleY;
    public LifeBase lifeBase;
    public GameObject projetis;
    private bool onFloor;
    private int direction;
    
    private Rigidbody2D rb;
    
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        lifeBase = GetComponent<LifeBase>();
        direction = 1;
       
    }

    // Update is called once per frame
    void Update()
    {
        moveKeys();

        if(rb.velocityX>0) // para frear caso use p physics material sem fricção
        {
            rb.velocityX -= friction;
        }
        else if(rb.velocityX<0)
        {
            rb.velocityX += friction;
        }

        

    }


    private void moveKeys()
    {
        if (Input.GetKey(KeyCode.LeftControl))
        {
            isRun = 2;

        }
        else isRun = 1;

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            rb.velocity = new Vector2(-speed * isRun, rb.velocityY);
            direction = -1;
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            rb.velocityX = speed * isRun;
            direction = 1;
        }
        else if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.velocity = Vector2.up * jump;
            rb.transform.localScale = Vector2.one;
            //DOTween.Clear(rb.transform);
            rb.transform.DOScaleY(jumpScaleY, duration).SetLoops(2, LoopType.Yoyo).SetEase(Ease.OutBack);
            rb.transform.DOScaleX(jumpScaleX, duration).SetLoops(2, LoopType.Yoyo).SetEase(Ease.OutBack);
            onFloor = false;
        }

        if (Input.GetKeyDown(KeyCode.C))
        {
            var temp = Instantiate(projetis);
            temp.GetComponent<projetilMove>().startPos = transform;
            temp.GetComponent<projetilMove>().direction = direction;

        }



    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("floor") && onFloor== false)
        {
            FloorImpact();
        }
        else if(collision.gameObject.CompareTag("enemy"))
        {
            lifeBase.Damage(1);
        }
        
    }


    private void FloorImpact()
    {
        rb.transform.localScale = Vector2.one;
        DOTween.Kill(rb.transform);
        rb.transform.DOScaleY(0.8f, duration).SetLoops(2, LoopType.Yoyo).SetEase(Ease.OutBack);
        rb.transform.DOScaleX(1.2f, duration).SetLoops(2, LoopType.Yoyo).SetEase(Ease.OutBack);
        onFloor = true;
    }

}
