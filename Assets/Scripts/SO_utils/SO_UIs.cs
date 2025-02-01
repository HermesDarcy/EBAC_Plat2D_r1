using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;

public class SO_UIs : ScriptableObject
{ 

    public TMPro.TextMeshPro textMeshPro;
    public SO_coins coins;

    private void Update()
    {
        textMeshPro.text = coins.coin.ToString();
    }


  


}
