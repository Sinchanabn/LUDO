using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedPlayerFour : MonoBehaviour
{
    public static string redPlayerIV_ColName;

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Blocks")
        {
            redPlayerIV_ColName = col.gameObject.name;

            if (col.gameObject.name.Contains("Red House"))
            {
                SoundManager.safeHouseAudioSource.Play();
            }
        }
    }

    void Start()
    {
        redPlayerIV_ColName = "none";
    }
}
