using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreenPlayerThree : MonoBehaviour
{
    public static string greenPlayerIII_ColName;

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Blocks")
        {
            greenPlayerIII_ColName = col.gameObject.name;

            if (col.gameObject.name.Contains("Green House"))
            {
                SoundManager.safeHouseAudioSource.Play();
            }
        }
    }

    void Start()
    {
        greenPlayerIII_ColName = "none";
    }
}
