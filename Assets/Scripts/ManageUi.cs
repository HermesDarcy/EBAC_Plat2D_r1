using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ManageUi : MonoBehaviour
{
    
    public TMP_Text textLifes;
    public LifeBase lifeBase;

    private void Update()
    {
        LifesText(lifeBase.life.ToString());
    }


    private void LifesText(string text)
    {
        textLifes.text = "Lifes: "+ text;
    }

    
}
