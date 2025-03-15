using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using static System.TimeZoneInfo;

public class EndLine : MonoBehaviour
{
    public GameObject sign, textEnd;
    public AudioMixerSnapshot snapshot1 , snapshot2;
    // Start is called before the first frame update
    private void Start()
    {
        sign.SetActive(false);
        textEnd.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            snapshot1.TransitionTo(0.1f);
            sign.SetActive(true);
            textEnd.SetActive(true);
        }
    }


    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            snapshot2.TransitionTo(0.1f);
            sign.SetActive(false);
            textEnd.SetActive(false);
        }
    }


}
