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


    // Start is called before the first frame update
    void Start()
    {
        //rb = GetComponent<Rigidbody2D>();
        
        Px = 0;

    }

    // Update is called once per frame
    void Update()
    {
        Patrol();
        
    }

    private void Patrol()
    {

        
        // Move para o ponto de patrulha atual
        transform.position = Vector3.MoveTowards(transform.position, caminho[Px].position, speed * Time.deltaTime);
        
        
        // Checa se chegou ao ponto de patrulha
        if (Vector2.Distance(transform.position, caminho[Px].position) < 0.2f)
        {

            
            // Define o próximo ponto de patrulha
            Px = (Px + 1) % caminho.Count;
            
        }
        
    }




   
}
