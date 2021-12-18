using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedPlayerTwo : MonoBehaviour
{
    public static string redPlayerII_ColName;

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Blocks")
        {
            redPlayerII_ColName = col.gameObject.name;

            if (col.gameObject.name.Contains("Red House"))
            {
                SoundManager.safeHouseAudioSource.Play();
            }
        }
    }

    void Start()
    {
        redPlayerII_ColName = "none";
    }
}
