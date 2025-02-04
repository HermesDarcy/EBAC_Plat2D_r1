using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AtualizaHighScore : MonoBehaviour
{
    public GameControler gameControler;
    //public TMP_Text txtHighScore;

    void Start()
    { 
        //UpdateText();
        TMP_Text text = this.gameObject.GetComponent<TMP_Text>();
        text.text = "HighScore: " + gameControler.getHighScore().ToString() + " My Score: " + gameControler.score.ToString(); ;
    }

    /* 
    private void UpdateText()
    {
        // Atualize o texto do TextMeshPro com o valor do score
        txtHighScore.text = "HighScore: " + gameControler.getHighScore().ToString() + "  Score: " + gameControler.score.ToString();
    }
    */
}
