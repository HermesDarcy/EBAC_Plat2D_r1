using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;

public class MovLazer : MonoBehaviour
{
    
    
    public float vel, timeLife;
    public GameObject explosao;
    public GameControler gameControler;
    
    public AudioSource som;

    
    void Start()
    {
                
        Destroy(this.gameObject, timeLife);
       
    }

    // Update is called once per frame
    void Update()
    {
        
        transform.Translate(Vector3.right * vel * Time.deltaTime);
        
    }


    
}
