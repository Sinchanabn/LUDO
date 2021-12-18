using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreenPlayerFour : MonoBehaviour
{
    public static string greenPlayerIV_ColName;

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Blocks")
        {
            greenPlayerIV_ColName = col.gameObject.name;

            if (col.gameObject.name.Contains("Green House"))
            {
                SoundManager.safeHouseAudioSource.Play();
            }
        }
    }

    void Start()
    {
        greenPlayerIV_ColName = "none";
    }
}
