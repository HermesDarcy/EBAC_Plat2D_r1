using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBG : MonoBehaviour
{
    
    public float v1;
    
    private float larguraSprite;
    private void Start()
    {
        // Calcula a largura da imagem de fundo (assumindo que o fundo é uma única imagem)
        larguraSprite = GetComponent<SpriteRenderer>().bounds.size.x;
        //v1 = .1f;   
                           


    }

    private void Update()
    {
        // Move a imagem de fundo para a esquerda
        transform.Translate(Vector2.left * v1 * Time.deltaTime);

        // Se a imagem de fundo se mover completamente para a esquerda da tela, reposicione-a à direita
        if (transform.position.x <= -larguraSprite)
        {
            // Calcula a nova posição
            Vector2 novaPosicao = new Vector2(transform.position.x + larguraSprite * 2, transform.position.y);

            // Move a imagem de fundo para a nova posição
            transform.position = novaPosicao;
        }
    }
}


