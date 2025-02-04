using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class explodeMoedas : MonoBehaviour
{
    public GameObject Coins;
    public Vector3 pos;

    public float forcaDoImpulso = 10f; // Força do impulso
    public ForceMode forcaMode = ForceMode.Impulse; // Tipo de força


    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.E))
        {
            explosionCoins();
        }
    }



    public void explosionCoins(int c = 6)
    {
        pos = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        
        
        int n = Random.Range(2, c);
        for (int i = 0; i < n; i++) 
        {
            GameObject temp = Instantiate(Coins, pos, Quaternion.identity);
            
            temp.GetComponent<Rigidbody2D>().AddForceX(Random.Range(-2,2), ForceMode2D.Impulse);
            temp.GetComponent<Rigidbody2D>().AddForceY(Random.Range(2, 10), ForceMode2D.Impulse);
            Destroy(temp, 5 + i);
            
        }



    }






}
