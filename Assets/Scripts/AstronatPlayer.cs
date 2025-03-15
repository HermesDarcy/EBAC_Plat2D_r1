using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class AstronatPlayer : MonoBehaviour
{
    [Header("Player")]
    /*public float speed;
    public float jump;
    public float friction, duration;*/
    public LifeBase lifeBase;
    public SO_player isPlayer;
    public SO_projectil projectil;
    public Animator animator;
    

    [Header("GunFire")]
    //public GameObject projetis;
    public Transform gun;

    [Header("VFX")]
    public ParticleSystem dust;
    public ParticleSystem jetts;

    

    private bool onFloor;
    private int direction;
    private float isRun;

    private Rigidbody2D rb;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        //animator = GetComponent<Animator>();
        lifeBase = GetComponent<LifeBase>();
        direction = 1;
        dust.Play();
    }

    // Update is called once per frame
    void Update()
    {
        moveKeys();

        if (rb.velocityX > 0) // para frear caso use p physics material sem fricção
        {
            rb.velocityX -= isPlayer.friction;
        }
        else if (rb.velocityX < 0)
        {
            rb.velocityX += isPlayer.friction;
        }



    }


    private void moveKeys()
    {
        if (Input.GetKey(KeyCode.LeftControl))
        {
            isRun = 2;
            animator.speed = isRun;

        }
        else
        {
            isRun = 1;
            animator.speed = isRun;
        }



        if (Input.GetKey(KeyCode.LeftArrow))
        {
            rb.velocity = new Vector2(-isPlayer.speed * isRun, rb.velocityY);
            direction = -1;
            transform.DOScaleX(-1,0.1f);
            if(onFloor) animator.SetBool("run", true);
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            rb.velocityX = isPlayer.speed * isRun;
            //transform.localScale = new Vector3(1, 1, 1);
            transform.DOScaleX(1, 0.1f);
            direction = 1;
            if(onFloor) animator.SetBool("run", true);
        }
        else if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.velocity = Vector2.up * isPlayer.jump;
            animator.SetTrigger("jump");
            jetts.Play();
            dust.Stop();
            onFloor = false;
        }
        else animator.SetBool("run", false);

        if (Input.GetKeyDown(KeyCode.C))
        {
            var temp = Instantiate(projectil.projectil);
            temp.GetComponent<projetilMove>().startPos = gun;
            temp.GetComponent<projetilMove>().direction = direction;

        }



    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("floor") && onFloor == false)
        {
            onFloor = true;
            animator.SetTrigger("landing");
            dust.Play();
            //jetts.Pause();
        }
        else if (collision.gameObject.CompareTag("enemy"))
        {
            lifeBase.Damage(1);
            
        }

    }


    
}
