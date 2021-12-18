using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedPlayerThree : MonoBehaviour
{
    public static string redPlayerIII_ColName;

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Blocks")
        {
            redPlayerIII_ColName = col.gameObject.name;

            if (col.gameObject.name.Contains("Red House"))
            {
                SoundManager.safeHouseAudioSource.Play();
            }
        }
    }

    void Start()
    {
        redPlayerIII_ColName = "none";
    }
}
