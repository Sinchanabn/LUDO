using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    //variable to count the number of winners
    private int totalBlueInHouse, totalRedInHouse, totalGreenInHouse, totalYellowInHouse;

    //holds frames
    public GameObject frameRed, frameGreen, frameBlue, frameYellow;
    
    //holds colorboard
    public GameObject redPlayerI_Border, redPlayerII_Border, redPlayerIII_Border, redPlayerIV_Border;
    public GameObject greenPlayerI_Border, greenPlayerII_Border, greenPlayerIII_Border, greenPlayerIV_Border;
    public GameObject bluePlayerI_Border, bluePlayerII_Border, bluePlayerIII_Border, bluePlayerIV_Border;
    public GameObject yellowPlayerI_Border, yellowPlayerII_Border, yellowPlayerIII_Border, yellowPlayerIV_Border;

    //holds each players starts position
    public Vector3 redPlayerI_Pos, redPlayerII_Pos, redPlayerIII_Pos, redPlayerIV_Pos;
    public Vector3 greenPlayerI_Pos, greenPlayerII_Pos, greenPlayerIII_Pos, greenPlayerIV_Pos;
    public Vector3 bluePlayerI_Pos, bluePlayerII_Pos, bluePlayerIII_Pos, bluePlayerIV_Pos;
    public Vector3 yellowPlayerI_Pos, yellowPlayerII_Pos, yellowPlayerIII_Pos, yellowPlayerIV_Pos;

    //Holds main and each colored dice positions
    public Transform diceRoll;
    public Transform redDiceRollPos, greenDiceRollPos, blueDiceRollPos, yellowDiceRollPos;

    //holds player button when we click
    public Button RedPlayerI_Button, RedPlayerII_Button, RedPlayerIII_Button, RedPlayerIV_Button;
    public Button GreenPlayerI_Button, GreenPlayerII_Button, GreenPlayerIII_Button, GreenPlayerIV_Button;
    public Button BluePlayerI_Button, BluePlayerII_Button, BluePlayerIII_Button, BluePlayerIV_Button;
    public Button YellowPlayerI_Button, YellowPlayerII_Button, YellowPlayerIII_Button, YellowPlayerIV_Button;

    public GameObject blueScreen, greenScreen, redScreen, yellowScreen;


    private string playerTurn = "RED";
    private string currentPlayer = "none";
    private string currentPlayerName = "none";

    //player movment controller
    public GameObject redPlayerI, redPlayerII, redPlayerIII, redPlayerIV;
    public GameObject greenPlayerI, greenPlayerII, greenPlayerIII, greenPlayerIV;
    public GameObject bluePlayerI, bluePlayerII, bluePlayerIII, bluePlayerIV;
    public GameObject yellowPlayerI, yellowPlayerII, yellowPlayerIII, yellowPlayerIV;


    //holds each players steps
    private int redPlayerI_Steps, redPlayerII_Steps, redPlayerIII_Steps, redPlayerIV_Steps;
    private int greenPlayerI_Steps, greenPlayerII_Steps, greenPlayerIII_Steps, greenPlayerIV_Steps;
    private int bluePlayerI_Steps, bluePlayerII_Steps, bluePlayerIII_Steps, bluePlayerIV_Steps;
    private int yellowPlayerI_Steps, yellowPlayerII_Steps, yellowPlayerIII_Steps, yellowPlayerIV_Steps;

    //selection of dice numbers animation
    private int selectDiceNumAnimation;

    //Dice Animation
    public GameObject dice1_Roll_Animation;
    public GameObject dice2_Roll_Animation;
    public GameObject dice3_Roll_Animation;
    public GameObject dice4_Roll_Animation;
    public GameObject dice5_Roll_Animation;
    public GameObject dice6_Roll_Animation;

    //Players movement corenspoding to blocks
    public List<GameObject> redMovementBlocks = new List<GameObject>();
    public List<GameObject> greenMovementBlocks = new List<GameObject>();
    public List<GameObject> yellowMovementBlocks = new List<GameObject>();
    public List<GameObject> blueMovementBlocks = new List<GameObject>();

    // Random generation of dice numbers
    private System.Random randomNo;
    public GameObject confirmScreen;
    public GameObject gameCompletedScreen;

    public Button DiceRollButton;


    //When we want to exit the game 
    public void ExitMethod()
    {
        SoundManager.buttonAudioSource.Play();
        confirmScreen.SetActive(true);
    }

    //When we click yes
    public void yesMethod()
    {
        SoundManager.buttonAudioSource.Play();
        SceneManager.LoadScene("MainMenu");
    }

    //when we click no
    public void noMethod()
    {
        SoundManager.buttonAudioSource.Play();
        confirmScreen.SetActive(false);
    }

    IEnumerator GameCompletedRoutine()
    {
        yield return new WaitForSeconds(1.5f);
        gameCompletedScreen.SetActive(true);
    }
    //when we click yes
    public void yesGameCompleted()
    {
        SoundManager.buttonAudioSource.Play();
        SceneManager.LoadScene("Ludo");
    }
    // when we click no
    public void noGameCompleted()
    {
        SoundManager.buttonAudioSource.Play();
        SceneManager.LoadScene("Main Menu");
    }

     public void DiceRoll() 
       {
        SoundManager.diceAudioSource.Play();
        DiceRollButton.interactable = false;

        selectDiceNumAnimation = randomNo.Next(1, 7);

        switch (selectDiceNumAnimation)
        {
            case 1:
                dice1_Roll_Animation.SetActive(true);
                dice2_Roll_Animation.SetActive(false);
                dice3_Roll_Animation.SetActive(false);
                dice4_Roll_Animation.SetActive(false);
                dice5_Roll_Animation.SetActive(false);
                dice6_Roll_Animation.SetActive(false);
                break;

            case 2:
                dice1_Roll_Animation.SetActive(false);
                dice2_Roll_Animation.SetActive(true);
                dice3_Roll_Animation.SetActive(false);
                dice4_Roll_Animation.SetActive(false);
                dice5_Roll_Animation.SetActive(false);
                dice6_Roll_Animation.SetActive(false);
                break;

            case 3:
                dice1_Roll_Animation.SetActive(false);
                dice2_Roll_Animation.SetActive(false);
                dice3_Roll_Animation.SetActive(true);
                dice4_Roll_Animation.SetActive(false);
                dice5_Roll_Animation.SetActive(false);
                dice6_Roll_Animation.SetActive(false);
                break;

            case 4:
                dice1_Roll_Animation.SetActive(false);
                dice2_Roll_Animation.SetActive(false);
                dice3_Roll_Animation.SetActive(false);
                dice4_Roll_Animation.SetActive(true);
                dice5_Roll_Animation.SetActive(false);
                dice6_Roll_Animation.SetActive(false);
                break;

            case 5:
                dice1_Roll_Animation.SetActive(false);
                dice2_Roll_Animation.SetActive(false);
                dice3_Roll_Animation.SetActive(false);
                dice4_Roll_Animation.SetActive(false);
                dice5_Roll_Animation.SetActive(true);
                dice6_Roll_Animation.SetActive(false);
                break;

            case 6:
                dice1_Roll_Animation.SetActive(false);
                dice2_Roll_Animation.SetActive(false);
                dice3_Roll_Animation.SetActive(false);
                dice4_Roll_Animation.SetActive(false);
                dice5_Roll_Animation.SetActive(false);
                dice6_Roll_Animation.SetActive(true);
                break;
        }

        StartCoroutine("PlayersNotInitialized");
    }

    





                // Start is called before the first frame update
   void Start()
    {

        QualitySettings.vSyncCount = 1;
        Application.targetFrameRate = 30;

        randomNo = new System.Random();

        dice1_Roll_Animation.SetActive(false);
        dice2_Roll_Animation.SetActive(false);
        dice3_Roll_Animation.SetActive(false);
        dice4_Roll_Animation.SetActive(false);
        dice5_Roll_Animation.SetActive(false);
        dice6_Roll_Animation.SetActive(false);


        // Players initial positions.....
        redPlayerI_Pos = redPlayerI.transform.position;
        redPlayerII_Pos = redPlayerII.transform.position;
        redPlayerIII_Pos = redPlayerIII.transform.position;
        redPlayerIV_Pos = redPlayerIV.transform.position;

        greenPlayerI_Pos = greenPlayerI.transform.position;
        greenPlayerII_Pos = greenPlayerII.transform.position;
        greenPlayerIII_Pos = greenPlayerIII.transform.position;
        greenPlayerIV_Pos = greenPlayerIV.transform.position;

        bluePlayerI_Pos = bluePlayerI.transform.position;
        bluePlayerII_Pos = bluePlayerII.transform.position;
        bluePlayerIII_Pos = bluePlayerIII.transform.position;
        bluePlayerIV_Pos = bluePlayerIV.transform.position;

        yellowPlayerI_Pos = yellowPlayerI.transform.position;
        yellowPlayerII_Pos = yellowPlayerII.transform.position;
        yellowPlayerIII_Pos = yellowPlayerIII.transform.position;
        yellowPlayerIV_Pos = yellowPlayerIV.transform.position;


        redPlayerI_Border.SetActive(false);
        redPlayerII_Border.SetActive(false);
        redPlayerIII_Border.SetActive(false);
        redPlayerIV_Border.SetActive(false);

        yellowPlayerI_Border.SetActive(false);
        yellowPlayerII_Border.SetActive(false);
        yellowPlayerIII_Border.SetActive(false);
        yellowPlayerIV_Border.SetActive(false);

        bluePlayerI_Border.SetActive(false);
        bluePlayerII_Border.SetActive(false);
        bluePlayerIII_Border.SetActive(false);
        bluePlayerIV_Border.SetActive(false);

        greenPlayerI_Border.SetActive(false);
        greenPlayerII_Border.SetActive(false);
        greenPlayerIII_Border.SetActive(false);
        greenPlayerIV_Border.SetActive(false);

        redScreen.SetActive(false);
        greenScreen.SetActive(false);
        yellowScreen.SetActive(false);
        blueScreen.SetActive(false);

        switch (MainMenuManager.howManyPlayers)
        {
            case 2:
                playerTurn = "RED";

                frameRed.SetActive(true);
                frameGreen.SetActive(false);
                frameBlue.SetActive(false);
                frameYellow.SetActive(false);
                //diceRoll.position = redDiceRollPos.position;
                bluePlayerI.SetActive(false);
                bluePlayerII.SetActive(false);
                bluePlayerIII.SetActive(false);
                bluePlayerIV.SetActive(false);

                yellowPlayerI.SetActive(false);
                yellowPlayerII.SetActive(false);
                yellowPlayerIII.SetActive(false);
                yellowPlayerIV.SetActive(false);
                break;

            case 3:
                playerTurn = "YELLOW";

                frameRed.SetActive(false);
                frameGreen.SetActive(false);
                frameBlue.SetActive(false);
                frameYellow.SetActive(true);

                diceRoll.position = yellowDiceRollPos.position;
                greenPlayerI.SetActive(false);
                greenPlayerII.SetActive(false);
                greenPlayerIII.SetActive(false);
                greenPlayerIV.SetActive(false);

                break;

            case 4:
                playerTurn = "RED";

                frameRed.SetActive(true);
                frameGreen.SetActive(false);
                frameBlue.SetActive(false);
                frameYellow.SetActive(false);

                diceRoll.position = redDiceRollPos.position;
                // keep all players active
                break;
        }
    }
    


  

    // Update is called once per frame
    void Update()
    {
        
    }
}
