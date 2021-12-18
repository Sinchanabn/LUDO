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

    private void InitializeDice()
    {
        DiceRollButton.interactable = true;

        dice1_Roll_Animation.SetActive(false);
        dice2_Roll_Animation.SetActive(false);
        dice3_Roll_Animation.SetActive(false);
        dice4_Roll_Animation.SetActive(false);
        dice5_Roll_Animation.SetActive(false);
        dice6_Roll_Animation.SetActive(false);

        switch (MainMenuManager.howManyPlayers)
        {
            case 2:
                if (playerTurn == "RED")
                {
                    diceRoll.position = redDiceRollPos.position;
                    frameRed.SetActive(true);
                    frameGreen.SetActive(false);

                }
                if (playerTurn == "GREEN")
                {
                    diceRoll.position = greenDiceRollPos.position;
                    frameGreen.SetActive(true);
                    frameRed.SetActive(false);
                }
                RedPlayerI_Button.interactable = false;
                RedPlayerII_Button.interactable = false;
                RedPlayerIII_Button.interactable = false;
                RedPlayerIV_Button.interactable = false;

                GreenPlayerI_Button.interactable = false;
                GreenPlayerII_Button.interactable = false;
                GreenPlayerIII_Button.interactable = false;
                GreenPlayerIV_Button.interactable = false;

                //-----------Deactivating their bodies as well-----------------------
                redPlayerI_Border.SetActive(false);
                redPlayerII_Border.SetActive(false);
                redPlayerIII_Border.SetActive(false);
                redPlayerIV_Border.SetActive(false);

                greenPlayerI_Border.SetActive(false);
                greenPlayerII_Border.SetActive(false);
                greenPlayerIII_Border.SetActive(false);
                greenPlayerIV_Border.SetActive(false);

                break;
            case 3:
                if (playerTurn == "RED")
                {
                    diceRoll.position = redDiceRollPos.position;
                    frameRed.SetActive(true);
                    frameYellow.SetActive(false);
                    frameBlue.SetActive(false);
                }
                if (playerTurn == "YELLOW")
                {
                    diceRoll.position = yellowDiceRollPos.position;
                    frameYellow.SetActive(true);
                    frameRed.SetActive(false);
                    frameBlue.SetActive(false);
                }
                if (playerTurn == "BLUE")
                {
                    diceRoll.position = blueDiceRollPos.position;
                    frameYellow.SetActive(false);
                    frameRed.SetActive(false);
                    frameBlue.SetActive(true);
                }

                RedPlayerI_Button.interactable = false;
                RedPlayerII_Button.interactable = false;
                RedPlayerIII_Button.interactable = false;
                RedPlayerIV_Button.interactable = false;

                BluePlayerI_Button.interactable = false;
                BluePlayerII_Button.interactable = false;
                BluePlayerIII_Button.interactable = false;
                BluePlayerIV_Button.interactable = false;

                YellowPlayerI_Button.interactable = false;
                YellowPlayerII_Button.interactable = false;
                YellowPlayerIII_Button.interactable = false;
                YellowPlayerIV_Button.interactable = false;

               //-----------Deactivating their bodies as well-----------------------
                redPlayerI_Border.SetActive(false);
                redPlayerII_Border.SetActive(false);
                redPlayerIII_Border.SetActive(false);
                redPlayerIV_Border.SetActive(false);

                bluePlayerI_Border.SetActive(false);
                bluePlayerII_Border.SetActive(false);
                bluePlayerIII_Border.SetActive(false);
                bluePlayerIV_Border.SetActive(false);

                yellowPlayerI_Border.SetActive(false);
                yellowPlayerII_Border.SetActive(false);
                yellowPlayerIII_Border.SetActive(false);
                yellowPlayerIV_Border.SetActive(false);

                break;


            case 4:
                if (playerTurn == "RED")
                {
                    diceRoll.position = redDiceRollPos.position;
                    frameRed.SetActive(true);
                    frameYellow.SetActive(false);
                    frameBlue.SetActive(false);
                    frameGreen.SetActive(false);
                }
                if (playerTurn == "BLUE")
                {
                    diceRoll.position = blueDiceRollPos.position;
                    frameYellow.SetActive(false);
                    frameRed.SetActive(false);
                    frameGreen.SetActive(false);
                    frameBlue.SetActive(true);
                }
                if (playerTurn == "YELLOW")
                {
                    diceRoll.position = yellowDiceRollPos.position;
                    frameYellow.SetActive(true);
                    frameRed.SetActive(false);
                    frameBlue.SetActive(false);
                    frameGreen.SetActive(false);
                }
                if (playerTurn == "GREEN")
                {
                    diceRoll.position = greenDiceRollPos.position;
                    frameYellow.SetActive(false);
                    frameRed.SetActive(false);
                    frameBlue.SetActive(false);
                    frameGreen.SetActive(true);
                }

                RedPlayerI_Button.interactable = false;
                RedPlayerII_Button.interactable = false;
                RedPlayerIII_Button.interactable = false;
                RedPlayerIV_Button.interactable = false;

                BluePlayerI_Button.interactable = false;
                BluePlayerII_Button.interactable = false;
                BluePlayerIII_Button.interactable = false;
                BluePlayerIV_Button.interactable = false;

                YellowPlayerI_Button.interactable = false;
                YellowPlayerII_Button.interactable = false;
                YellowPlayerIII_Button.interactable = false;
                YellowPlayerIV_Button.interactable = false;

                //-----------Deactivating their bodies as well-----------------------

                greenPlayerI_Border.SetActive(false);
                greenPlayerII_Border.SetActive(false);
                greenPlayerIII_Border.SetActive(false);
                greenPlayerIV_Border.SetActive(false);

                redPlayerI_Border.SetActive(false);
                redPlayerII_Border.SetActive(false);
                redPlayerIII_Border.SetActive(false);
                redPlayerIV_Border.SetActive(false);

                bluePlayerI_Border.SetActive(false);
                bluePlayerII_Border.SetActive(false);
                bluePlayerIII_Border.SetActive(false);
                bluePlayerIV_Border.SetActive(false);

                yellowPlayerI_Border.SetActive(false);
                yellowPlayerII_Border.SetActive(false);
                yellowPlayerIII_Border.SetActive(false);
                yellowPlayerIV_Border.SetActive(false);

                greenPlayerI_Border.SetActive(false);
                greenPlayerII_Border.SetActive(false);
                greenPlayerIII_Border.SetActive(false);
                greenPlayerIV_Border.SetActive(false);

                break;
        }
    }
    public void DiceRoll() 
       {
        SoundManager.diceAudioSource.Play();
        DiceRollButton.interactable = false;

        selectDiceNumAnimation = randomNo.Next(1, 7);
        //selectDiceNumAnimation = 6;

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

   IEnumerator PlayersNotInitialized()
    {
        yield return new WaitForSeconds(1f);
        // Game Start Initial position of each player (Red, Green, Blue, Yellow)
        switch (playerTurn)
        {
            case "RED":
                //condition for border glow---
                if ((redMovementBlocks.Count - redPlayerI_Steps) >= selectDiceNumAnimation && redPlayerI_Steps > 0
                    && (redMovementBlocks.Count > redPlayerI_Steps))
                    {
                    redPlayerI_Border.SetActive(true);
                    RedPlayerI_Button.interactable = true;
                    }
                else
                  {
                    redPlayerI_Border.SetActive(false);
                    RedPlayerI_Button.interactable = false;
                  }
                if((redMovementBlocks.Count - redPlayerII_Steps) >= selectDiceNumAnimation && redPlayerII_Steps > 0 && (redMovementBlocks.Count > redPlayerII_Steps))
                {
                    redPlayerII_Border.SetActive(true);
                    RedPlayerII_Button.interactable = true;
                }
                else
                {
                    redPlayerII_Border.SetActive(false);
                    RedPlayerII_Button.interactable = false;
                }

                if ((redMovementBlocks.Count - redPlayerIII_Steps) >= selectDiceNumAnimation && redPlayerIII_Steps > 0 && (redMovementBlocks.Count > redPlayerIII_Steps))
                {
                    redPlayerIII_Border.SetActive(true);
                    RedPlayerIII_Button.interactable = true;
                }
                else
                {
                    redPlayerIII_Border.SetActive(false);
                    RedPlayerIII_Button.interactable = false;
                }

                if ((redMovementBlocks.Count - redPlayerIV_Steps) >= selectDiceNumAnimation && redPlayerIV_Steps > 0 && (redMovementBlocks.Count > redPlayerIV_Steps))
                {
                    redPlayerIV_Border.SetActive(true);
                    RedPlayerIV_Button.interactable = true;
                }
                else
                {
                    redPlayerIV_Border.SetActive(false);
                    RedPlayerIV_Button.interactable = false;
                }

                //When player has no move switch the turn to next player-----

                if (selectDiceNumAnimation == 6 && redPlayerI_Steps == 0)
                {
                    redPlayerI_Border.SetActive(true);
                    RedPlayerI_Button.interactable = true;
                }
                if (selectDiceNumAnimation == 6 && redPlayerII_Steps == 0)
                {
                    redPlayerII_Border.SetActive(true);
                    RedPlayerII_Button.interactable = true;
                }
                if (selectDiceNumAnimation == 6 && redPlayerIII_Steps == 0)
                {
                    redPlayerIII_Border.SetActive(true);
                    RedPlayerIII_Button.interactable = true;
                }
                if (selectDiceNumAnimation == 6 && redPlayerIV_Steps == 0)
                {
                    redPlayerIV_Border.SetActive(true);
                    RedPlayerIV_Button.interactable = true;
                }

                //Player boarder glow when player comes out of the home

                if (!redPlayerI_Border.activeInHierarchy && !redPlayerII_Border.activeInHierarchy
                    && !redPlayerIII_Border.activeInHierarchy && !redPlayerIV_Border.activeInHierarchy)
                {
                    RedPlayerI_Button.interactable = false;
                    RedPlayerII_Button.interactable = false;
                    RedPlayerIII_Button.interactable = false;
                    RedPlayerIV_Button.interactable = false;

                    switch (MainMenuManager.howManyPlayers)
                    {
                        case 2:
                            playerTurn = "GREEN";
                            InitializeDice();
                            break;

                        case 3:
                            playerTurn = "BLUE";
                            InitializeDice();
                            break;

                        case 4:
                            playerTurn = "BLUE";
                            InitializeDice();
                            break;


                    }
                  

                }
                break;
            case "GREEN":


                //Player boarder glow when player comes out of the home
                if (selectDiceNumAnimation == 6 && greenPlayerI_Steps == 0)
                {
                    greenPlayerI_Border.SetActive(true);
                    GreenPlayerI_Button.interactable = true;
                }
               
                if (selectDiceNumAnimation == 6 && greenPlayerII_Steps == 0)
                {
                    greenPlayerII_Border.SetActive(true);
                    GreenPlayerII_Button.interactable = true;
                }

                if (selectDiceNumAnimation == 6 && greenPlayerIII_Steps == 0)
                {
                    greenPlayerIII_Border.SetActive(true);
                    GreenPlayerIII_Button.interactable = true;
                }
               
                if (selectDiceNumAnimation == 6 && greenPlayerIV_Steps == 0)
                {
                    greenPlayerIV_Border.SetActive(true);
                    GreenPlayerIV_Button.interactable = true;
                }




                //---When player has no move switch the turn to next player-----

                if (!greenPlayerI_Border.activeInHierarchy && !greenPlayerII_Border.activeInHierarchy
                   && !greenPlayerIII_Border.activeInHierarchy && !greenPlayerIV_Border.activeInHierarchy)
                {
                    GreenPlayerI_Button.interactable = false;
                    GreenPlayerII_Button.interactable = false;
                    GreenPlayerIII_Button.interactable = false;
                    GreenPlayerIV_Button.interactable = false;

                    switch (MainMenuManager.howManyPlayers)
                    {
                        case 2:
                            playerTurn = "RED";
                            InitializeDice();
                            break;

                        case 3:
                           //green player is not available
                            break;

                        case 4:
                            playerTurn = "YELLOW";
                            InitializeDice();
                            break;
                    }
                }

               break;

            case "BLUE":

                //Player boarder glow when player comes out of the home
                if (selectDiceNumAnimation == 6 && bluePlayerI_Steps == 0)
                {
                   bluePlayerI_Border.SetActive(true);
                   BluePlayerI_Button.interactable = true;
                }
                if (selectDiceNumAnimation == 6 && bluePlayerII_Steps == 0)
                {
                    bluePlayerII_Border.SetActive(true);
                    BluePlayerII_Button.interactable = true;
                }
                if (selectDiceNumAnimation == 6 && bluePlayerIII_Steps == 0)
                {
                    bluePlayerIII_Border.SetActive(true);
                    BluePlayerIII_Button.interactable = true;
                }
                if (selectDiceNumAnimation == 6 && bluePlayerIV_Steps == 0)
                {
                    bluePlayerIV_Border.SetActive(true);
                    BluePlayerIV_Button.interactable = true;
                }

                //---When player has no move switch the turn to next player-----


                if (!bluePlayerI_Border.activeInHierarchy && !bluePlayerII_Border.activeInHierarchy
                   && !bluePlayerIII_Border.activeInHierarchy && !bluePlayerIV_Border.activeInHierarchy)
                {
                    BluePlayerI_Button.interactable = false;
                    BluePlayerII_Button.interactable = false;
                    BluePlayerIII_Button.interactable = false;
                    BluePlayerIV_Button.interactable = false;

                    switch (MainMenuManager.howManyPlayers)
                    {
                        case 2:

                        //blue player is not available
                        
                            break;

                        case 3:
                            playerTurn = "YELLOW";
                            InitializeDice();
                            break;

                        case 4:
                            playerTurn = "GREEN";
                            InitializeDice();
                            break;
                    }
                    
                }
                break;

            case "YELLOW":
                //Player boarder glow when player comes out of the home
                if (selectDiceNumAnimation == 6 && yellowPlayerI_Steps == 0)
                {
                    yellowPlayerI_Border.SetActive(true);
                    YellowPlayerI_Button.interactable = true;
                }
                if (selectDiceNumAnimation == 6 && yellowPlayerII_Steps == 0)
                {
                    yellowPlayerII_Border.SetActive(true);
                    YellowPlayerII_Button.interactable = true;
                }
                if (selectDiceNumAnimation == 6 && yellowPlayerIII_Steps == 0)
                {
                    yellowPlayerIII_Border.SetActive(true);
                    YellowPlayerIII_Button.interactable = true;
                }
                if (selectDiceNumAnimation == 6 && yellowPlayerIV_Steps == 0)
                {
                    yellowPlayerIV_Border.SetActive(true);
                    YellowPlayerIV_Button.interactable = true;
                }


                //---When player has no move switch the turn to next player-----

                if (!yellowPlayerI_Border.activeInHierarchy && !yellowPlayerII_Border.activeInHierarchy
                   && !yellowPlayerIII_Border.activeInHierarchy && !yellowPlayerIV_Border.activeInHierarchy)
                {
                    YellowPlayerI_Button.interactable = false;
                    YellowPlayerII_Button.interactable = false;
                    YellowPlayerIII_Button.interactable = false;
                    YellowPlayerIV_Button.interactable = false;

                    switch (MainMenuManager.howManyPlayers)
                    {
                        case 2:

                            //Yellow player is not available

                            break;

                        case 3:
                            playerTurn = "RED";
                            InitializeDice();
                            //green player is not available
                            break;

                        case 4:
                            playerTurn = "RED";
                            InitializeDice();
                            break;
                    }

                }
                break;



        }

    }

    //-------------------Red player 1 movement---------------------
    public void RedPlayerIMovement()
    {
        SoundManager.playerAudioSource.Play();
        redPlayerI_Border.SetActive(false);
        redPlayerII_Border.SetActive(false);
        redPlayerIII_Border.SetActive(false);
        redPlayerIV_Border.SetActive(false);


        RedPlayerI_Button.interactable = false;
        RedPlayerII_Button.interactable = false;
        RedPlayerIII_Button.interactable = false;
        RedPlayerIV_Button.interactable = false;

        if (playerTurn == "RED" && (redMovementBlocks.Count - redPlayerI_Steps) > selectDiceNumAnimation) // 4 > 4
        {
            if (redPlayerI_Steps > 0)
            {
                Vector3[] redPlayerI_Path = new Vector3[selectDiceNumAnimation];

                for (int i = 0; i < selectDiceNumAnimation; i++)
                {
                    redPlayerI_Path[i] = redMovementBlocks[redPlayerI_Steps + i].transform.position;
                }
                redPlayerI_Steps += selectDiceNumAnimation;

                if (selectDiceNumAnimation == 6)
                {
                    playerTurn = "RED";
                }
                else
                {
                    switch (MainMenuManager.howManyPlayers)
                    {
                        case 2:
                            playerTurn = "GREEN";
                            break;

                        case 3:
                            playerTurn = "BLUE";
                            break;

                        case 4:
                            playerTurn = "BLUE";
                            break;
                    }
                }

                if (redPlayerI_Path.Length > 1)
                {
                    iTween.MoveTo(redPlayerI, iTween.Hash("path", redPlayerI_Path, "speed", 125, "time", 2.0f,
                    "easetype", "elastic", "oncomplete", "InitializeDice", "oncompletetarget", this.gameObject));

                }
                else
                {
                    iTween.MoveTo(redPlayerI, iTween.Hash("position", redPlayerI_Path[0], "speed", 125, "time", 2.0f,
                         "easetype", "elastic", "oncomplete", "InitializeDice", "oncompletetarget", this.gameObject));
                }

                currentPlayerName = "RED PLAYER I";

            }
            else
            {
                if (selectDiceNumAnimation == 6 && redPlayerI_Steps == 0)
                {
                    Vector3[] redPlayerI_Path = new Vector3[1];
                    redPlayerI_Path[0] = redMovementBlocks[redPlayerI_Steps].transform.position;
                    redPlayerI_Steps += 1;
                    playerTurn = "RED";
                    currentPlayerName = "RED PLAYER 1";
                    iTween.MoveTo(redPlayerI, iTween.Hash("position", redPlayerI_Path[0], "speed", 125, "time", 2.0f,
                        "easetype", "elastic", "oncomplete", "InitializeDice", "oncompletetarget", this.gameObject));
                }
            }
        }
        else
        {
            // Condition when Player Coin is reached successfully in House....(Actual Number of required moves to get into the House)
            if (playerTurn == "RED" && (redMovementBlocks.Count - redPlayerI_Steps) == selectDiceNumAnimation)
            {
                Vector3[] redPlayerI_Path = new Vector3[selectDiceNumAnimation];

                for (int i = 0; i < selectDiceNumAnimation; i++)
                {
                    redPlayerI_Path[i] = redMovementBlocks[redPlayerI_Steps + i].transform.position;
                }

                redPlayerI_Steps += selectDiceNumAnimation;

                playerTurn = "RED";

                //redPlayerI_Steps = 0;

                if (redPlayerI_Path.Length > 1)
                {
                    iTween.MoveTo(redPlayerI, iTween.Hash("path", redPlayerI_Path, "speed", 125, "time", 2.0f, "easetype", "elastic", "looptype",
                        "none", "oncomplete", "InitializeDice", "oncompletetarget", this.gameObject));
                }
                else
                {
                    iTween.MoveTo(redPlayerI, iTween.Hash("position", redPlayerI_Path[0], "speed", 125, "time", 2.0f, "easetype", "elastic", "looptype",
                        "none", "oncomplete", "InitializeDice", "oncompletetarget", this.gameObject));
                }
                totalRedInHouse += 1;
                Debug.Log("Cool !!");
                RedPlayerI_Button.enabled = false;
            }
            else
            {
                Debug.Log("You need " + (redMovementBlocks.Count - redPlayerI_Steps).ToString() + " to enter into the house.");

                if (redPlayerIV_Steps + redPlayerII_Steps + redPlayerIII_Steps == 0 && selectDiceNumAnimation != 6)
                {
                    switch (MainMenuManager.howManyPlayers)
                    {
                        case 2:
                            playerTurn = "GREEN";
                            break;

                        case 3:
                            playerTurn = "BLUE";
                            break;

                        case 4:
                            playerTurn = "BLUE";
                            break;
                    }
                  
                }
                InitializeDice();
            }
        }
    }

    //------------------------------Red player 2 movment--------------------------

    public void RedPlayerIIMovement()
    {
        SoundManager.playerAudioSource.Play();
        redPlayerI_Border.SetActive(false);
        redPlayerII_Border.SetActive(false);
        redPlayerIII_Border.SetActive(false);
        redPlayerIV_Border.SetActive(false);


        RedPlayerI_Button.interactable = false;
        RedPlayerII_Button.interactable = false;
        RedPlayerIII_Button.interactable = false;
        RedPlayerIV_Button.interactable = false;

        if (playerTurn == "RED" && (redMovementBlocks.Count - redPlayerII_Steps) > selectDiceNumAnimation) // 4 > 4
        {
            if (redPlayerII_Steps > 0)
            {
                Vector3[] redPlayerII_Path = new Vector3[selectDiceNumAnimation];

                for (int i = 0; i < selectDiceNumAnimation; i++)
                {
                    redPlayerII_Path[i] = redMovementBlocks[redPlayerII_Steps + i].transform.position;
                }
                redPlayerII_Steps += selectDiceNumAnimation;

                if (selectDiceNumAnimation == 6)
                {
                    playerTurn = "RED";
                }
                else
                {
                    switch (MainMenuManager.howManyPlayers)
                    {
                        case 2:
                            playerTurn = "GREEN";
                            break;

                        case 3:
                            playerTurn = "BLUE";
                            break;

                        case 4:
                            playerTurn = "BLUE";
                            break;
                    }
                }

                if (redPlayerII_Path.Length > 1)
                {
                    iTween.MoveTo(redPlayerII, iTween.Hash("path", redPlayerII_Path, "speed", 125, "time", 2.0f,
                    "easetype", "elastic", "oncomplete", "InitializeDice", "oncompletetarget", this.gameObject));

                }
                else
                {
                    iTween.MoveTo(redPlayerII, iTween.Hash("position", redPlayerII_Path[0], "speed", 125, "time", 2.0f,
                         "easetype", "elastic", "oncomplete", "InitializeDice", "oncompletetarget", this.gameObject));
                }

                currentPlayerName = "RED PLAYER II";

            }
            else
            {
                if (selectDiceNumAnimation == 6 && redPlayerII_Steps == 0)
                {
                    Vector3[] redPlayerII_Path = new Vector3[1];
                    redPlayerII_Path[0] = redMovementBlocks[redPlayerII_Steps].transform.position;
                    redPlayerII_Steps += 1;
                    playerTurn = "RED";
                    currentPlayerName = "RED PLAYER 1";
                    iTween.MoveTo(redPlayerII, iTween.Hash("position", redPlayerII_Path[0], "speed", 125, "time", 2.0f,
                        "easetype", "elastic", "oncomplete", "InitializeDice", "oncompletetarget", this.gameObject));
                }
            }
        }
        else
        {
            // Condition when Player Coin is reached successfully in House....(Actual Number of required moves to get into the House)
            if (playerTurn == "RED" && (redMovementBlocks.Count - redPlayerII_Steps) == selectDiceNumAnimation)
            {
                Vector3[] redPlayerII_Path = new Vector3[selectDiceNumAnimation];

                for (int i = 0; i < selectDiceNumAnimation; i++)
                {
                    redPlayerII_Path[i] = redMovementBlocks[redPlayerII_Steps + i].transform.position;
                }

                redPlayerII_Steps += selectDiceNumAnimation;

                playerTurn = "RED";

                //redPlayerI_Steps = 0;

                if (redPlayerII_Path.Length > 1)
                {
                    iTween.MoveTo(redPlayerII, iTween.Hash("path", redPlayerII_Path, "speed", 125, "time", 2.0f, "easetype", "elastic", "looptype",
                        "none", "oncomplete", "InitializeDice", "oncompletetarget", this.gameObject));
                }
                else
                {
                    iTween.MoveTo(redPlayerII, iTween.Hash("position", redPlayerII_Path[0], "speed", 125, "time", 2.0f, "easetype", "elastic", "looptype",
                        "none", "oncomplete", "InitializeDice", "oncompletetarget", this.gameObject));
                }
                totalRedInHouse += 1;
                Debug.Log("Cool !!");
                RedPlayerII_Button.enabled = false;
            }
            else
            {
                Debug.Log("You need " + (redMovementBlocks.Count - redPlayerII_Steps).ToString() + " to enter into the house.");

                if (redPlayerI_Steps + redPlayerIV_Steps + redPlayerIII_Steps == 0 && selectDiceNumAnimation != 6)
                {
                    switch (MainMenuManager.howManyPlayers)
                    {
                        case 2:
                            playerTurn = "GREEN";
                            break;

                        case 3:
                            playerTurn = "BLUE";
                            break;

                        case 4:
                            playerTurn = "BLUE";
                            break;
                    }
                   
                }
                InitializeDice();
            }
        }
    }


    //------------------------------Red player 3 movment--------------------------

    public void RedPlayerIIIMovement()
    {
        SoundManager.playerAudioSource.Play();
        redPlayerI_Border.SetActive(false);
        redPlayerII_Border.SetActive(false);
        redPlayerIII_Border.SetActive(false);
        redPlayerIV_Border.SetActive(false);


        RedPlayerI_Button.interactable = false;
        RedPlayerII_Button.interactable = false;
        RedPlayerIII_Button.interactable = false;
        RedPlayerIV_Button.interactable = false;

        if (playerTurn == "RED" && (redMovementBlocks.Count - redPlayerIII_Steps) > selectDiceNumAnimation) // 4 > 4
        {
            if (redPlayerIII_Steps > 0)
            {
                Vector3[] redPlayerIII_Path = new Vector3[selectDiceNumAnimation];

                for (int i = 0; i < selectDiceNumAnimation; i++)
                {
                    redPlayerIII_Path[i] = redMovementBlocks[redPlayerIII_Steps + i].transform.position;
                }
                redPlayerIII_Steps += selectDiceNumAnimation;

                if (selectDiceNumAnimation == 6)
                {
                    playerTurn = "RED";
                }
                else
                {
                    switch (MainMenuManager.howManyPlayers)
                    {
                        case 2:
                            playerTurn = "GREEN";
                            break;

                        case 3:
                            playerTurn = "BLUE";
                            break;

                        case 4:
                            playerTurn = "BLUE";
                            break;
                    }
                }

                if (redPlayerIII_Path.Length > 1)
                {
                    iTween.MoveTo(redPlayerII, iTween.Hash("path", redPlayerIII_Path, "speed", 125, "time", 2.0f,
                    "easetype", "elastic", "oncomplete", "InitializeDice", "oncompletetarget", this.gameObject));

                }
                else
                {
                    iTween.MoveTo(redPlayerII, iTween.Hash("position", redPlayerIII_Path[0], "speed", 125, "time", 2.0f,
                         "easetype", "elastic", "oncomplete", "InitializeDice", "oncompletetarget", this.gameObject));
                }

                currentPlayerName = "RED PLAYER II";

            }
            else
            {
                if (selectDiceNumAnimation == 6 && redPlayerIII_Steps == 0)
                {
                    Vector3[] redPlayerIII_Path = new Vector3[1];
                    redPlayerIII_Path[0] = redMovementBlocks[redPlayerIII_Steps].transform.position;
                    redPlayerIII_Steps += 1;
                    playerTurn = "RED";
                    currentPlayerName = "RED PLAYER 1";
                    iTween.MoveTo(redPlayerII, iTween.Hash("position", redPlayerIII_Path[0], "speed", 125, "time", 2.0f,
                        "easetype", "elastic", "oncomplete", "InitializeDice", "oncompletetarget", this.gameObject));
                }
            }
        }
        else
        {
            // Condition when Player Coin is reached successfully in House....(Actual Number of required moves to get into the House)
            if (playerTurn == "RED" && (redMovementBlocks.Count - redPlayerIII_Steps) == selectDiceNumAnimation)
            {
                Vector3[] redPlayerIII_Path = new Vector3[selectDiceNumAnimation];

                for (int i = 0; i < selectDiceNumAnimation; i++)
                {
                    redPlayerIII_Path[i] = redMovementBlocks[redPlayerIII_Steps + i].transform.position;
                }

                redPlayerIII_Steps += selectDiceNumAnimation;

                playerTurn = "RED";

                //redPlayerI_Steps = 0;

                if (redPlayerIII_Path.Length > 1)
                {
                    iTween.MoveTo(redPlayerII, iTween.Hash("path", redPlayerIII_Path, "speed", 125, "time", 2.0f, "easetype", "elastic", "looptype",
                        "none", "oncomplete", "InitializeDice", "oncompletetarget", this.gameObject));
                }
                else
                {
                    iTween.MoveTo(redPlayerII, iTween.Hash("position", redPlayerIII_Path[0], "speed", 125, "time", 2.0f, "easetype", "elastic", "looptype",
                        "none", "oncomplete", "InitializeDice", "oncompletetarget", this.gameObject));
                }
                totalRedInHouse += 1;
                Debug.Log("Cool !!");
                RedPlayerIII_Button.enabled = false;
            }
            else
            {
                Debug.Log("You need " + (redMovementBlocks.Count - redPlayerII_Steps).ToString() + " to enter into the house.");

                if (redPlayerI_Steps + redPlayerIV_Steps + redPlayerII_Steps == 0 && selectDiceNumAnimation != 6)
                {
                    switch (MainMenuManager.howManyPlayers)
                    {
                        case 2:
                            playerTurn = "GREEN";
                            break;

                        case 3:
                            playerTurn = "BLUE";
                            break;

                        case 4:
                            playerTurn = "BLUE";
                            break;
                    }
                   
                }
                InitializeDice();
            }
        }
    }

    //------------------------------Red player 4 movment--------------------------

    public void RedPlayerIVMovement()
    {
        SoundManager.playerAudioSource.Play();
        redPlayerI_Border.SetActive(false);
        redPlayerII_Border.SetActive(false);
        redPlayerIII_Border.SetActive(false);
        redPlayerIV_Border.SetActive(false);


        RedPlayerI_Button.interactable = false;
        RedPlayerII_Button.interactable = false;
        RedPlayerIII_Button.interactable = false;
        RedPlayerIV_Button.interactable = false;

        if (playerTurn == "RED" && (redMovementBlocks.Count - redPlayerIV_Steps) > selectDiceNumAnimation) // 4 > 4
        {
            if (redPlayerIV_Steps > 0)
            {
                Vector3[] redPlayerIV_Path = new Vector3[selectDiceNumAnimation];

                for (int i = 0; i < selectDiceNumAnimation; i++)
                {
                    redPlayerIV_Path[i] = redMovementBlocks[redPlayerIV_Steps + i].transform.position;
                }
                redPlayerIV_Steps += selectDiceNumAnimation;

                if (selectDiceNumAnimation == 6)
                {
                    playerTurn = "RED";
                }
                else
                {
                    switch (MainMenuManager.howManyPlayers)
                    {
                        case 2:
                            playerTurn = "GREEN";
                            break;

                        case 3:
                            playerTurn = "BLUE";
                            break;

                        case 4:
                            playerTurn = "BLUE";
                            break;
                    }
                }

                if (redPlayerIV_Path.Length > 1)
                {
                    iTween.MoveTo(redPlayerII, iTween.Hash("path", redPlayerIV_Path, "speed", 125, "time", 2.0f,
                    "easetype", "elastic", "oncomplete", "InitializeDice", "oncompletetarget", this.gameObject));

                }
                else
                {
                    iTween.MoveTo(redPlayerII, iTween.Hash("position", redPlayerIV_Path[0], "speed", 125, "time", 2.0f,
                         "easetype", "elastic", "oncomplete", "InitializeDice", "oncompletetarget", this.gameObject));
                }

                currentPlayerName = "RED PLAYER II";

            }
            else
            {
                if (selectDiceNumAnimation == 6 && redPlayerIV_Steps == 0)
                {
                    Vector3[] redPlayerIV_Path = new Vector3[1];
                    redPlayerIV_Path[0] = redMovementBlocks[redPlayerIV_Steps].transform.position;
                    redPlayerIV_Steps += 1;
                    playerTurn = "RED";
                    currentPlayerName = "RED PLAYER 1";
                    iTween.MoveTo(redPlayerII, iTween.Hash("position", redPlayerIV_Path[0], "speed", 125, "time", 2.0f,
                        "easetype", "elastic", "oncomplete", "InitializeDice", "oncompletetarget", this.gameObject));
                }
            }
        }
        else
        {
            // Condition when Player Coin is reached successfully in House....(Actual Number of required moves to get into the House)
            if (playerTurn == "RED" && (redMovementBlocks.Count - redPlayerIV_Steps) == selectDiceNumAnimation)
            {
                Vector3[] redPlayerIV_Path = new Vector3[selectDiceNumAnimation];

                for (int i = 0; i < selectDiceNumAnimation; i++)
                {
                    redPlayerIV_Path[i] = redMovementBlocks[redPlayerIV_Steps + i].transform.position;
                }

                redPlayerIV_Steps += selectDiceNumAnimation;

                playerTurn = "RED";

                //redPlayerI_Steps = 0;

                if (redPlayerIV_Path.Length > 1)
                {
                    iTween.MoveTo(redPlayerII, iTween.Hash("path", redPlayerIV_Path, "speed", 125, "time", 2.0f, "easetype", "elastic", "looptype",
                        "none", "oncomplete", "InitializeDice", "oncompletetarget", this.gameObject));
                }
                else
                {
                    iTween.MoveTo(redPlayerII, iTween.Hash("position", redPlayerIV_Path[0], "speed", 125, "time", 2.0f, "easetype", "elastic", "looptype",
                        "none", "oncomplete", "InitializeDice", "oncompletetarget", this.gameObject));
                }
                totalRedInHouse += 1;
                Debug.Log("Cool !!");
                RedPlayerIV_Button.enabled = false;
            }
            else
            {
                Debug.Log("You need " + (redMovementBlocks.Count - redPlayerIV_Steps).ToString() + " to enter into the house.");

                if (redPlayerI_Steps + redPlayerII_Steps + redPlayerIII_Steps == 0 && selectDiceNumAnimation != 6)
                {
                    switch (MainMenuManager.howManyPlayers)
                    {
                        case 2:
                            playerTurn = "GREEN";
                            break;

                        case 3:
                            playerTurn = "BLUE";
                            break;

                        case 4:
                            playerTurn = "BLUE";
                            break;
                    }
                   
                }
                InitializeDice();
            }
        }
    }
    //------------------------------Green player 1 movment--------------------------
    public void GreenPlayerIMovement()
    {
        SoundManager.playerAudioSource.Play();
        greenPlayerI_Border.SetActive(false);
        greenPlayerII_Border.SetActive(false);
        greenPlayerIII_Border.SetActive(false);
        greenPlayerIV_Border.SetActive(false);

        GreenPlayerI_Button.interactable = false;
        GreenPlayerII_Button.interactable = false;
        GreenPlayerIII_Button.interactable = false;
        GreenPlayerIV_Button.interactable = false;

        if (playerTurn == "GREEN" && (greenMovementBlocks.Count - greenPlayerI_Steps) > selectDiceNumAnimation)
        {
            if (greenPlayerI_Steps > 0)
            {
                Vector3[] greenPlayer_Path = new Vector3[selectDiceNumAnimation];

                for (int i = 0; i < selectDiceNumAnimation; i++)
                {
                    greenPlayer_Path[i] = greenMovementBlocks[greenPlayerI_Steps + i].transform.position;
                }

                greenPlayerI_Steps += selectDiceNumAnimation;

                if (selectDiceNumAnimation == 6)
                {
                    playerTurn = "GREEN";
                }
                else
                {
                    switch (MainMenuManager.howManyPlayers)
                    {
                        case 2:
                            playerTurn = "RED";
                            break;

                        case 3:
                            //player is not available
                            break;

                        case 4:
                            playerTurn = "YELLOW";
                            break;
                    }
                }

                currentPlayerName = "GREEN PLAYER I";

                if (greenPlayer_Path.Length > 1)
                {
                    iTween.MoveTo(greenPlayerI, iTween.Hash("path", greenPlayer_Path, "speed", 125, 
                        "time", 2.0f, "easetype", "elastic", "looptype", "none", "oncomplete", "InitializeDice", "oncompletetarget", this.gameObject));
                }
                else
                {
                    iTween.MoveTo(greenPlayerI, iTween.Hash("position", greenPlayer_Path[0], "speed", 125, 
                        "time", 2.0f, "easetype", "elastic", "looptype", "none", "oncomplete", "InitializeDice", "oncompletetarget", this.gameObject));

                }
            }
            else
            {
                if (selectDiceNumAnimation == 6 && greenPlayerI_Steps == 0)
                {
                    Vector3[] greenPlayer_Path = new Vector3[selectDiceNumAnimation];
                    greenPlayer_Path[0] = greenMovementBlocks[greenPlayerI_Steps].transform.position;
                    greenPlayerI_Steps += 1;
                    playerTurn = "GREEN";
                    currentPlayerName = "GREEN PLAYER I";
                    iTween.MoveTo(greenPlayerI, iTween.Hash("position", greenPlayer_Path[0], "speed", 125, 
                        "time", 2.0f, "easetype", "elastic", "looptype", "none", "oncomplete", "InitializeDice", "oncompletetarget", this.gameObject));
                }
            }
        }
        else
        {
            // Condition when Player Coin is reached successfully in House....(Actual Number of requigreen moves to get into the House)
            if (playerTurn == "GREEN" && (greenMovementBlocks.Count - greenPlayerI_Steps) == selectDiceNumAnimation)
            {
                Vector3[] greenPlayer_Path = new Vector3[selectDiceNumAnimation];

                for (int i = 0; i < selectDiceNumAnimation; i++)
                {
                    greenPlayer_Path[i] = greenMovementBlocks[greenPlayerI_Steps + i].transform.position;
                }

                greenPlayerI_Steps += selectDiceNumAnimation;

                playerTurn = "GREEN";

                //greenPlayerI_Steps = 0;

                if (greenPlayer_Path.Length > 1)
                {
                    iTween.MoveTo(greenPlayerI, iTween.Hash("path", greenPlayer_Path, "speed", 125, 
                        "time", 2.0f, "easetype", "elastic", "looptype", "none", "oncomplete", "InitializeDice", "oncompletetarget", this.gameObject));
                }
                else
                {
                    iTween.MoveTo(greenPlayerI, iTween.Hash("position", greenPlayer_Path[0], "speed", 125, 
                        "time", 2.0f, "easetype", "elastic", "looptype", "none", "oncomplete", "InitializeDice", "oncompletetarget", this.gameObject));
                }

                totalGreenInHouse += 1;
                Debug.Log("Cool !!");
                GreenPlayerI_Button.enabled = false;
            }
            else
            {
                Debug.Log("You need " + (greenMovementBlocks.Count - greenPlayerI_Steps).ToString() + " to enter into the house.");

                if (greenPlayerII_Steps + greenPlayerIII_Steps + greenPlayerIV_Steps == 0 && selectDiceNumAnimation != 6)
                {
                    switch (MainMenuManager.howManyPlayers)
                    {
                        case 2:
                            playerTurn = "RED";
                            break;

                        case 3:
                            //Player is not available
                            break;

                        case 4:
                            playerTurn = "YELLOW";
                            break;
                    }
                    
                }
                InitializeDice();
            }
        }
    }

    // ------------------Green player 3 movement--------------

    public void GreenPlayerIIMovement()
    {
        SoundManager.playerAudioSource.Play();
        greenPlayerI_Border.SetActive(false);
        greenPlayerII_Border.SetActive(false);
        greenPlayerIII_Border.SetActive(false);
        greenPlayerIV_Border.SetActive(false);

        GreenPlayerI_Button.interactable = false;
        GreenPlayerII_Button.interactable = false;
        GreenPlayerIII_Button.interactable = false;
        GreenPlayerIV_Button.interactable = false;

        if (playerTurn == "GREEN" && (greenMovementBlocks.Count - greenPlayerII_Steps) > selectDiceNumAnimation)
        {
            if (greenPlayerII_Steps > 0)
            {
                Vector3[] greenPlayer_Path = new Vector3[selectDiceNumAnimation];

                for (int i = 0; i < selectDiceNumAnimation; i++)
                {
                    greenPlayer_Path[i] = greenMovementBlocks[greenPlayerII_Steps + i].transform.position;
                }

                greenPlayerII_Steps += selectDiceNumAnimation;

                if (selectDiceNumAnimation == 6)
                {
                    playerTurn = "GREEN";
                }
                else
                {
                    switch (MainMenuManager.howManyPlayers)
                    {
                        case 2:
                            playerTurn = "RED";
                            break;

                        case 3:
                            //player is not available
                            break;

                        case 4:
                            playerTurn = "YELLOW";
                            break;
                    }
                }

                currentPlayerName = "GREEN PLAYER II";

                if (greenPlayer_Path.Length > 1)
                {
                    iTween.MoveTo(greenPlayerII, iTween.Hash("path", greenPlayer_Path, "speed", 125, "time", 2.0f, "easetype", 
                        "elastic", "looptype", "none", "oncomplete", "InitializeDice", "oncompletetarget", this.gameObject));
                }
                else
                {
                    iTween.MoveTo(greenPlayerII, iTween.Hash("position", greenPlayer_Path[0], "speed", 125, "time", 2.0f, 
                        "easetype", "elastic", "looptype", "none", "oncomplete", "InitializeDice", "oncompletetarget", this.gameObject));

                }
            }
            else
            {
                if (selectDiceNumAnimation == 6 && greenPlayerII_Steps == 0)
                {
                    Vector3[] greenPlayer_Path = new Vector3[selectDiceNumAnimation];
                    greenPlayer_Path[0] = greenMovementBlocks[greenPlayerII_Steps].transform.position;
                    greenPlayerII_Steps += 1;
                    playerTurn = "GREEN";
                    currentPlayerName = "GREEN PLAYER II";
                    iTween.MoveTo(greenPlayerII, iTween.Hash("position", greenPlayer_Path[0], "speed", 125, "time", 2.0f, "easetype", 
                        "elastic", "looptype", "none", "oncomplete", "InitializeDice", "oncompletetarget", this.gameObject));
                }
            }
        }
        else
        {
            // Condition when Player Coin is reached successfully in House....(Actual Number of requigreen moves to get into the House)
            if (playerTurn == "GREEN" && (greenMovementBlocks.Count - greenPlayerII_Steps) == selectDiceNumAnimation)
            {
                Vector3[] greenPlayer_Path = new Vector3[selectDiceNumAnimation];

                for (int i = 0; i < selectDiceNumAnimation; i++)
                {
                    greenPlayer_Path[i] = greenMovementBlocks[greenPlayerII_Steps + i].transform.position;
                }

                greenPlayerII_Steps += selectDiceNumAnimation;

                playerTurn = "GREEN";

                //greenPlayerII_Steps = 0;

                if (greenPlayer_Path.Length > 1)
                {
                    iTween.MoveTo(greenPlayerII, iTween.Hash("path", greenPlayer_Path, "speed", 125, "time", 2.0f, "easetype", "elastic", 
                        "looptype", "none", "oncomplete", "InitializeDice", "oncompletetarget", this.gameObject));
                }
                else
                {
                    iTween.MoveTo(greenPlayerII, iTween.Hash("position", greenPlayer_Path[0], "speed", 125, "time", 2.0f, "easetype", 
                        "elastic", "looptype", "none", "oncomplete", "InitializeDice", "oncompletetarget", this.gameObject));
                }

                totalGreenInHouse += 1;
                Debug.Log("Cool !!");
                GreenPlayerII_Button.enabled = false;
            }
            else
            {
                Debug.Log("You need " + (greenMovementBlocks.Count - greenPlayerII_Steps).ToString() + " to enter into the house.");

                if (greenPlayerI_Steps + greenPlayerIII_Steps + greenPlayerIV_Steps == 0 && selectDiceNumAnimation != 6)
                {
                    switch (MainMenuManager.howManyPlayers)
                    {
                        case 2:
                            playerTurn = "RED";
                            break;

                        case 3:
                            //Player is not available
                            break;

                        case 4:
                            playerTurn = "YELLOW";
                            break;
                    }
                    InitializeDice();
                }
            }
        }
    }
     // ------------------Green player 3 movement--------------
    public void GreenPlayerIIIMovement()
    {
        SoundManager.playerAudioSource.Play();
        greenPlayerI_Border.SetActive(false);
        greenPlayerII_Border.SetActive(false);
        greenPlayerIII_Border.SetActive(false);
        greenPlayerIV_Border.SetActive(false);

        GreenPlayerI_Button.interactable = false;
        GreenPlayerII_Button.interactable = false;
        GreenPlayerIII_Button.interactable = false;
        GreenPlayerIV_Button.interactable = false;

        if (playerTurn == "GREEN" && (greenMovementBlocks.Count - greenPlayerIII_Steps) > selectDiceNumAnimation)
        {
            if (greenPlayerIII_Steps > 0)
            {
                Vector3[] greenPlayer_Path = new Vector3[selectDiceNumAnimation];

                for (int i = 0; i < selectDiceNumAnimation; i++)
                {
                    greenPlayer_Path[i] = greenMovementBlocks[greenPlayerIII_Steps + i].transform.position;
                }

                greenPlayerIII_Steps += selectDiceNumAnimation;

                if (selectDiceNumAnimation == 6)
                {
                    playerTurn = "GREEN";
                }
                else
                {
                    switch (MainMenuManager.howManyPlayers)
                    {
                        case 2:
                            playerTurn = "RED";
                            break;

                        case 3:
                            //player is not available
                            break;

                        case 4:
                            playerTurn = "YELLOW";
                            break;
                    }
                }

                currentPlayerName = "GREEN PLAYER III";

                if (greenPlayer_Path.Length > 1)
                {
                    iTween.MoveTo(greenPlayerIII, iTween.Hash("path", greenPlayer_Path, "speed", 125, "time", 2.0f, "easetype", 
                        "elastic", "looptype", "none", "oncomplete", "InitializeDice", "oncompletetarget", this.gameObject));
                }
                else
                {
                    iTween.MoveTo(greenPlayerIII, iTween.Hash("position", greenPlayer_Path[0], "speed", 125, "time", 2.0f, 
                        "easetype", "elastic", "looptype", "none", "oncomplete", "InitializeDice", "oncompletetarget", this.gameObject));

                }
            }
            else
            {
                if (selectDiceNumAnimation == 6 && greenPlayerIII_Steps == 0)
                {
                    Vector3[] greenPlayer_Path = new Vector3[selectDiceNumAnimation];
                    greenPlayer_Path[0] = greenMovementBlocks[greenPlayerIII_Steps].transform.position;
                    greenPlayerIII_Steps += 1;
                    playerTurn = "GREEN";
                    currentPlayerName = "GREEN PLAYER III";
                    iTween.MoveTo(greenPlayerIII, iTween.Hash("position", greenPlayer_Path[0], "speed", 125, "time", 2.0f, "easetype", "elastic", 
                        "looptype", "none", "oncomplete", "InitializeDice", "oncompletetarget", this.gameObject));
                }
            }
        }
        else
        {
            // Condition when Player Coin is reached successfully in House....(Actual Number of requigreen moves to get into the House)
            if (playerTurn == "GREEN" && (greenMovementBlocks.Count - greenPlayerIII_Steps) == selectDiceNumAnimation)
            {
                Vector3[] greenPlayer_Path = new Vector3[selectDiceNumAnimation];

                for (int i = 0; i < selectDiceNumAnimation; i++)
                {
                    greenPlayer_Path[i] = greenMovementBlocks[greenPlayerIII_Steps + i].transform.position;
                }

                greenPlayerIII_Steps += selectDiceNumAnimation;

                playerTurn = "GREEN";

                //greenPlayerIII_Steps = 0;

                if (greenPlayer_Path.Length > 1)
                {
                    iTween.MoveTo(greenPlayerIII, iTween.Hash("path", greenPlayer_Path, "speed", 125, "time", 2.0f, "easetype", "elastic", 
                        "looptype", "none", "oncomplete", "InitializeDice", "oncompletetarget", this.gameObject));
                }
                else
                {
                    iTween.MoveTo(greenPlayerIII, iTween.Hash("position", greenPlayer_Path[0], "speed", 125, "time", 2.0f, "easetype", 
                        "elastic", "looptype", "none", "oncomplete", "InitializeDice", "oncompletetarget", this.gameObject));
                }

                totalGreenInHouse += 1;
                Debug.Log("Cool !!");
                GreenPlayerIII_Button.enabled = false;
            }
            else
            {
                Debug.Log("You need " + (greenMovementBlocks.Count - greenPlayerIII_Steps).ToString() + " to enter into the house.");

                if (greenPlayerI_Steps + greenPlayerII_Steps + greenPlayerIV_Steps == 0 && selectDiceNumAnimation != 6)
                {
                    switch (MainMenuManager.howManyPlayers)
                    {
                        case 2:
                            playerTurn = "RED";
                            break;

                        case 3:
                            //Player is not available
                            break;

                        case 4:
                            playerTurn = "YELLOW";
                            break;
                    }
                    InitializeDice();
                }
            }
        }
    }
    // ------------------Green player 4 movement--------------
    public void GreenPlayerIVMovement()
    {
        SoundManager.playerAudioSource.Play();
        greenPlayerI_Border.SetActive(false);
        greenPlayerII_Border.SetActive(false);
        greenPlayerIII_Border.SetActive(false);
        greenPlayerIV_Border.SetActive(false);

        GreenPlayerI_Button.interactable = false;
        GreenPlayerII_Button.interactable = false;
        GreenPlayerIII_Button.interactable = false;
        GreenPlayerIV_Button.interactable = false;

        if (playerTurn == "GREEN" && (greenMovementBlocks.Count - greenPlayerIV_Steps) > selectDiceNumAnimation)
        {
            if (greenPlayerIV_Steps > 0)
            {
                Vector3[] greenPlayer_Path = new Vector3[selectDiceNumAnimation];

                for (int i = 0; i < selectDiceNumAnimation; i++)
                {
                    greenPlayer_Path[i] = greenMovementBlocks[greenPlayerIV_Steps + i].transform.position;
                }

                greenPlayerIV_Steps += selectDiceNumAnimation;

                if (selectDiceNumAnimation == 6)
                {
                    playerTurn = "GREEN";
                }
                else
                {
                    switch (MainMenuManager.howManyPlayers)
                    {
                        case 2:
                            playerTurn = "RED";
                            break;

                        case 3:
                            //player is not available
                            break;

                        case 4:
                            playerTurn = "YELLOW";
                            break;
                    }
                }

                currentPlayerName = "GREEN PLAYER IV";

                if (greenPlayer_Path.Length > 1)
                {
                    iTween.MoveTo(greenPlayerIV, iTween.Hash("path", greenPlayer_Path, "speed", 125, "time", 2.0f, "easetype", "elastic", 
                        "looptype", "none", "oncomplete", "InitializeDice", "oncompletetarget", this.gameObject));
                }
                else
                {
                    iTween.MoveTo(greenPlayerIV, iTween.Hash("position", greenPlayer_Path[0], "speed", 125, "time", 2.0f, 
                        "easetype", "elastic", "looptype", "none", "oncomplete", "InitializeDice", "oncompletetarget", this.gameObject));

                }
            }
            else
            {
                if (selectDiceNumAnimation == 6 && greenPlayerIV_Steps == 0)
                {
                    Vector3[] greenPlayer_Path = new Vector3[selectDiceNumAnimation];
                    greenPlayer_Path[0] = greenMovementBlocks[greenPlayerIV_Steps].transform.position;
                    greenPlayerIV_Steps += 1;
                    playerTurn = "GREEN";
                    currentPlayerName = "GREEN PLAYER IV";
                    iTween.MoveTo(greenPlayerIV, iTween.Hash("position", greenPlayer_Path[0], "speed", 125, "time", 2.0f, "easetype", "elastic", "looptype", "none", "oncomplete", "InitializeDice", "oncompletetarget", this.gameObject));
                }
            }
        }
        else
        {
            // Condition when Player Coin is reached successfully in House....(Actual Number of requigreen moves to get into the House)
            if (playerTurn == "GREEN" && (greenMovementBlocks.Count - greenPlayerIV_Steps) == selectDiceNumAnimation)
            {
                Vector3[] greenPlayer_Path = new Vector3[selectDiceNumAnimation];

                for (int i = 0; i < selectDiceNumAnimation; i++)
                {
                    greenPlayer_Path[i] = greenMovementBlocks[greenPlayerIV_Steps + i].transform.position;
                }

                greenPlayerIV_Steps += selectDiceNumAnimation;

                playerTurn = "GREEN";

                //greenPlayerIV_Steps = 0;

                if (greenPlayer_Path.Length > 1)
                {
                    iTween.MoveTo(greenPlayerIV, iTween.Hash("path", greenPlayer_Path, "speed", 125, "time", 2.0f, "easetype", 
                        "elastic", "looptype", "none", "oncomplete", "InitializeDice", "oncompletetarget", this.gameObject));
                }
                else
                {
                    iTween.MoveTo(greenPlayerIV, iTween.Hash("position", greenPlayer_Path[0], "speed", 125, "time", 2.0f, 
                        "easetype", "elastic", "looptype", "none", "oncomplete", "InitializeDice", "oncompletetarget", this.gameObject));
                }

                totalGreenInHouse += 1;
                Debug.Log("Cool !!");
                GreenPlayerIV_Button.enabled = false;
            }
            else
            {
                Debug.Log("You need " + (greenMovementBlocks.Count - greenPlayerIV_Steps).ToString() + " to enter into the house.");

                if (greenPlayerI_Steps + greenPlayerII_Steps + greenPlayerIII_Steps == 0 && selectDiceNumAnimation != 6)
                {
                    switch (MainMenuManager.howManyPlayers)
                    {
                        case 2:
                            playerTurn = "RED";
                            break;

                        case 3:
                            //Player is not available
                            break;

                        case 4:
                            playerTurn = "YELLOW";
                            break;
                    }
                    InitializeDice();
                }
            }
        }
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
