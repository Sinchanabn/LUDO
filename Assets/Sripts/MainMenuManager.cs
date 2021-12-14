using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    public static int howManyPlayers;

    void Start()
    {

    }

    void Update()
    {

    }

    public void two_player()
    {
        SoundManager.buttonAudioSource.Play();
        howManyPlayers = 2;
        SceneManager.LoadScene("Ludo");
    }

    public void three_player()
    {
        SoundManager.buttonAudioSource.Play();
        howManyPlayers = 3;
        SceneManager.LoadScene("Ludo");
    }

    public void four_player()
    {
        SoundManager.buttonAudioSource.Play();
        howManyPlayers = 4;
        SceneManager.LoadScene("Ludo");
    }

    public void quit()
    {
        SoundManager.buttonAudioSource.Play();
        Application.Quit();
    }
}
