using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Play.HD.Singleton;
using DG.Tweening;

public class GameManager : Singleton<GameManager> // cria um singleton no gamemaneger
{
    [Header("Player")]
    public GameObject player;
    public Transform playerInitPos;
    [Header("Enemys")]
    public List<GameObject> enemysList;

    public float duration;
    private Ease ease;
    
    void Start()
    {
        spawPlayer();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void spawPlayer()
    {
        player = Instantiate(player);
        player.transform.position = playerInitPos.position;
        player.transform.DOScale(0, duration).SetEase(ease).From().SetDelay(0.2f);
    }





}
