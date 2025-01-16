using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGame : MonoBehaviour
{
    public float speed, jump, friction, duration, isRun, jumpScaleX, jumpScaleY;


    private Rigidbody2D rb;
    private Animator animator;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftControl))
        {
            isRun = 2;

        }
        else isRun = 1;

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            rb.velocity = new Vector2(-speed * isRun, rb.velocityY);
            rb.transform.rotation = Quaternion.Euler(0, 180, 0);
            animator.SetTrigger("run");
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            rb.velocityX = speed * isRun;
            rb.transform.rotation = Quaternion.Euler(0, 0, 0);
            animator.SetTrigger("run");
        }
        else if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.velocity = Vector2.up * jump;
            

        }


        if (rb.velocityX > 0) // para frear caso use p physics material sem fricção
        {
            rb.velocityX -= friction;
        }
        else if (rb.velocityX < 0)
        {
            rb.velocityX += friction;
        }



    }
}
