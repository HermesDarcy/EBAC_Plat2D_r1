using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameControler : MonoBehaviour
{
    public ControleGUI controleGUI;
    public ReSpawn reSpawn;
    public int score;
    public int vidas;
    public AudioClip[] audioClips;
    public GameObject[] explosao;
    public bool startGame = false;
    public Transform inimigosLugar;
    public int fase;
    public float spawnTime =3f;

    void Start()
    {
        score = 0;
        vidas = 5;
        fase = 0;
        controleGUI = FindAnyObjectByType<ControleGUI>();


    }

    // Update is called once per frame
    void Update()
    {
        controleGUI.ScoreUpdate();
        controleGUI.ContagemVidas();
        if(score > 100)
        {
            spawnTime = 2f;
            reSpawn.spawnTime = spawnTime; 
        }
        if(score >200)
        {
            spawnTime = 1.2f;
            reSpawn.spawnTime = spawnTime;
        }
    }



    public void AudioDead(int i, float v)
    {

        AudioSource audioSource = this.gameObject.GetComponent<AudioSource>();
        audioSource.volume = v;
        audioSource.clip = audioClips[i];
        audioSource.Play();

    }

    public void AudioStop()
    {
        AudioSource audioSource = this.gameObject.GetComponent<AudioSource>();
        audioSource.Stop();
    }


    public void apagaInimigos()
    {

        if (inimigosLugar.childCount > 0)
        {
            foreach (Transform child in inimigosLugar.transform)
            {
                Destroy(child.gameObject);
            }
        }
    }


    public void salvaScore(int pontos)
    {
        int highScore = getHighScore();
        if (pontos > highScore)
        {
            PlayerPrefs.SetInt("PlayerScore", pontos);
            PlayerPrefs.Save();
        }

    }

    public int getHighScore() // função onde tem um retorno de valor
    {
        int playerScore = PlayerPrefs.GetInt("PlayerScore", 0);
        return playerScore;
    }


    public void posINIplayer()
    {
        controleGUI.posINIplayer();
    }


}
    
