using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // Start is called before the first frame update
    public float vel, timeLife;

    private GameControler gameControler;
    
    public int pontos;
    
    void Start()
    {
        
        
        gameControler = FindAnyObjectByType<GameControler>();
        Destroy(this.gameObject, timeLife);
    }

    // Update is called once per frame
    void Update()
    {
        
        transform.Translate(Vector3.left * vel * Time.deltaTime);
    }


    private void OnTriggerEnter2D(Collider2D other) 
    {
        
        if(other.CompareTag("lazer"))
        {
            GameObject explode = gameControler.explosao[Random.Range(0,gameControler.explosao.Length)];
            gameControler.AudioDead(0,1f);
            GameObject temp = Instantiate(explode, new Vector2(transform.position.x , transform.position.y), Quaternion.Euler(0f,0f,0f));
            gameControler.score += pontos;
            Destroy(gameObject,0.01f);
            Destroy(other.gameObject);
            Destroy(temp , 2f);

        }
        
        if(other.CompareTag("Player"))
        {
            GameObject explode = gameControler.explosao[3];
            gameControler.AudioDead(1,1f);
            GameObject temp = Instantiate(explode, new Vector2(transform.position.x, transform.position.y), Quaternion.Euler(0f, 0f, 0f));
            gameControler.vidas -= 1;
            gameControler.posINIplayer();
            Destroy(gameObject, 0.01f);
            Destroy(temp, 2f);
        }

    
    }


}
