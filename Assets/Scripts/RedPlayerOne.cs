using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedPlayerOne : MonoBehaviour
{
    // Start is called before the first frame update
    public static string redPlayerI_ColName;

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Blocks")
        {
            redPlayerI_ColName = col.gameObject.name;

            if (col.gameObject.name.Contains("Red House"))
            {
                SoundManager.safeHouseAudioSource.Play();
            }
        }
    }

    void Start()
    {
        redPlayerI_ColName = "none";
    }
}
