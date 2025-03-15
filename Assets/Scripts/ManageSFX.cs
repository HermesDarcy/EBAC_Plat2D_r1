using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class ManageSFX : MonoBehaviour
{
    public AudioMixer group;
    public OpcoesDropdown myOP;
    public enum OpcoesDropdown
    {
        AmbienceParam,
        MasterParam,
        SFXParam
       
    }



    private string floatParam;



    public void ChangeValue(float f)
    {
        floatParam = changeParam();
        group.SetFloat(floatParam, f);
    }

    private string changeParam()
    {
        switch(myOP)
        {
            case OpcoesDropdown.MasterParam:
                return "MasterParam";
                //break;
            case OpcoesDropdown.SFXParam:
                return "SFXParam";
                //break;
            case OpcoesDropdown.AmbienceParam:
                return "AmbienceParam";
                //break;
            default:
                return "MasterParam";
        }
    }

}
