using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreenPlayerTwo : MonoBehaviour
{
    public static string greenPlayerII_ColName;

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Blocks")
        {
            greenPlayerII_ColName = col.gameObject.name;

            if (col.gameObject.name.Contains("Green House"))
            {
                SoundManager.safeHouseAudioSource.Play();
            }
        }
    }

    void Start()
    {
        greenPlayerII_ColName = "none";
    }
}
