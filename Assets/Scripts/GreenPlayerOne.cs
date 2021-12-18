using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreenPlayerOne : MonoBehaviour
{
    public static string greenPlayerI_ColName;

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Blocks")
        {
            greenPlayerI_ColName = col.gameObject.name;

            if (col.gameObject.name.Contains("Green House"))
            {
                SoundManager.safeHouseAudioSource.Play();
            }
        }
    }

    void Start()
    {
        greenPlayerI_ColName = "none";
    }
}
