using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class projetilMove : MonoBehaviour
{
    public SO_projectil projectil;
    public Transform startPos;
    private SpriteRenderer sprite;
    //public float speed;
    public int direction;
    
    // Start is called before the first frame update
    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        sprite.color = projectil.color;
        transform.position = startPos.position;
        Destroy(gameObject, 5f);
    }

    // Update is called once per frame
    void Update()
    {
        transform .position = new Vector2(transform.position.x + projectil.speed * Time.deltaTime * direction, transform.position.y);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("enemy"))
        {
            collision.gameObject.GetComponent<LifeBase>().Damage(1);
            Destroy(this.gameObject);
        }
    }

    

    

}
