using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ControleGUI : MonoBehaviour
{

    public GameControler gameControler;
    public GameObject panelMenu;
    public GameObject panelGame;
    public GameObject panelMorreu;
    public GameObject panelPause;
    public GameObject player;
    private Vector3 playerPos;
    public TMP_Text txtScore;
    public TMP_Text txtHighScore;
    public GameObject[] vidasImage;
    public Button exitB;
    public Button playGame;






    void Start()
    {
        playerPos = player.transform.position;
        gameControler.salvaScore(gameControler.score);
        exitB.onClick.AddListener(SairBotao);
        playGame.onClick.AddListener(iniciaGame);
        menuGame();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ScoreUpdate()
    {
        txtScore.text = gameControler.score.ToString();
        gameControler.salvaScore(gameControler.score);
    }

    public void HighScoreUpdate()
    {
        gameControler.salvaScore(gameControler.score);
        txtHighScore.text = "HighScore: " + gameControler.getHighScore().ToString();
    }

    public void ContagemVidas()
    {

        if (gameControler.vidas < 5 && gameControler.vidas > 0)
        {
            vidasImage[gameControler.vidas - 1].gameObject.SetActive(false);
        }
        else if(gameControler.vidas <= 0)
        {
            gameControler.startGame = false;
            menuMorreu();
        }
    }

    public void menuGame()
    {
        // inicia e ativa menu do jogo
        panelGame.SetActive(false);
        panelMorreu.SetActive(false);
        panelPause.SetActive(false);
        panelMenu.SetActive(true);
        gameControler.vidas = 5;
        gameControler.score = 0;
        gameControler.apagaInimigos();
        gameControler.AudioDead(2, 0.5f);
        gameControler.startGame = false;
        HighScoreUpdate();
        reporVidas();
    }


    public void SairBotao()
    {
        Debug.Log("Botao sair");
        StartCoroutine(EsperarSegundos(2.0f));
        Application.Quit();
    }

    public void iniciaGame()
    {
        // tela de jogo
        
        
        Time.timeScale = 1f;
        player.SetActive(true);
        posINIplayer();
        gameControler.vidas = 5;
        gameControler.score = 0;
        panelGame.SetActive(true);
        panelMenu.SetActive(false);
        panelMorreu.SetActive(false);
        panelPause.SetActive(false);
        gameControler.AudioStop();
        gameControler.apagaInimigos();
        gameControler.startGame = true;
        reporVidas();
    }


    public void posINIplayer()
    {
        player.transform.position = playerPos;

        StartCoroutine(EsperarSegundos(3.0f));
    }

    public void resumeGame()
    {
        gameControler.salvaScore(gameControler.score);
        Time.timeScale = 1f;

        panelGame.SetActive(true);
        panelMenu.SetActive(false);
        panelMorreu.SetActive(false);
        panelPause.SetActive(false);
        gameControler.AudioStop();
        
        gameControler.startGame = true;
    }


    public void menuMorreu()
    {
        StartCoroutine(EsperarSegundos(3.0f));
        gameControler.AudioDead(3, 0.5f);
        panelGame.SetActive(false);
        panelMenu.SetActive(false);
        panelPause.SetActive(false);
        player.SetActive(false);
        gameControler.startGame = false;
        panelMorreu.SetActive(true);
        
        gameControler.salvaScore(gameControler.score);
    }

    public void botaoPause()
    {
        Time.timeScale = 0f;
        gameControler.salvaScore(gameControler.score);
        panelGame.SetActive(false);
        panelMenu.SetActive(false);
        panelMorreu.SetActive(false);
        gameControler.startGame=false;
        panelPause.SetActive(true);
    }


    private void reporVidas()
    {
        gameControler.vidas = 5;
        for(int i = 0;i < vidasImage.Length ;i++)
        {
            vidasImage[i].SetActive(true);
            Debug.Log(i);
        }
    }

    
			
    IEnumerator EsperarSegundos(float segundos)
    {
        Debug.Log("In�cio da espera");

        yield return new WaitForSeconds(segundos); // Pausa por 'segundos' segundos

        Debug.Log("Espera conclu�da ap�s " + segundos + " segundos");
    }




}
