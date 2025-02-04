using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReSpawn : MonoBehaviour
{
    
    public GameObject[] inimigos;
    public GameControler gameControler;
    public Transform aqui;
   
    private float minY, maxY;
    
    private float nextSpawn;
    public float spawnTime;
    void Start()
    {
        // gameControle = FindAnyObjectByType<GameControle>();
        nextSpawn = Time.time;
        spawnTime = gameControler.spawnTime;
        SetMinMax();
    }

    // Update is called once per frame
    void Update()
    {
       Spawn();
    }

    private void SetMinMax()
    {
        Vector3 bounds = Camera.main.ScreenToWorldPoint(new Vector3(0f,Screen.safeArea.height,0f));
        maxY = bounds.y * 0.9f;
        minY = -bounds.y * 0.85f;
        
    }


    private void Spawn()
    {
        if (Time.time > nextSpawn && gameControler.startGame)
        {
            Vector2 position = new Vector2( transform.position.x ,Random.Range(minY,maxY));
            GameObject temp = Instantiate(inimigos[Random.Range(0,inimigos.Length)], new Vector2(position.x, position.y), Quaternion.Euler(0f,0f,0f));
            temp.transform.parent = aqui;
            nextSpawn = Time.time + spawnTime;
            //Debug.Log(position.y);
        }
    }
}
