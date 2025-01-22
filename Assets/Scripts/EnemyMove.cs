using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    public float speed, dist;
    //private Rigidbody2D rb;
    public List<Transform> caminho;
    private int Px;
    public LifeBase lifeBase;
    private Animator animator;
    private bool isDeath = false;


    // Start is called before the first frame update
    void Start()
    {
        //rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        Px = 0;

    }

    // Update is called once per frame
    void Update()
    {
        if(!isDeath) 
        {
            Patrol();
            isLive();
        }
       


    }

    private void Patrol()
    {
        animator.SetTrigger("run");
        
       


        // Move para o ponto de patrulha atual
        transform.position = Vector3.MoveTowards(transform.position, caminho[Px].position, speed * Time.deltaTime);
        
        
        // Checa se chegou ao ponto de patrulha
        if (Vector2.Distance(transform.position, caminho[Px].position) < 0.2f)
        {

            
            // Define o próximo ponto de patrulha
            Px = (Px + 1) % caminho.Count;
            if (transform.position.x < caminho[Px].position.x)
            {
                transform.DOScaleX(1, .1f);
            }
            else
            {
                transform.DOScaleX(-1, .1f);
            }

        }
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            animator.SetTrigger("attack");
        }
    }


    private void isLive()
    {
        if(lifeBase.wLife() <=0 )
        {
            animator.SetBool("death", true);
            isDeath = true;
        }
    }




}
