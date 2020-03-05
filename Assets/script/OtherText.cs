using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class OtherText : MonoBehaviour
{
    private static OtherText instance;
    private TextMeshProUGUI factText;
    private TextMeshProUGUI instructionText;
    private TextMeshProUGUI titleText;
    private TextMeshProUGUI gameEndText;
    private TextMeshProUGUI winStatementText;
    private TextMeshProUGUI loseStatementText;
    private TextMeshProUGUI restartMessageText;
    private TextMeshProUGUI levelText;
    private Scoring scoring;
    private GameController gameController;
    private const int SecondsPerLevel = 50;
    private const int LevelCountBeforeInfiniteLevel = 10;

    private int randnum = 0;
    public List<string> randfacts = new List<string>();

    public static OtherText GetInstance()
    {
        return instance;
    }

    private void Awake()
    {
        instance = this;
        try
        {
            string path = "Assets/SpaceFacts.txt";

            string line; //current line
            System.IO.StreamReader file = new System.IO.StreamReader(path);
            while ((line = file.ReadLine()) != null)
            {
                randfacts.Add(line);
            }
        }
        catch (Exception e)
        {
            Debug.Log(e.Message);
        }
    }

    void Start()
    {
        scoring = Scoring.getInstance();
        gameController = GameController.GetInstance();
        factText = transform.Find("RandFact").GetComponent<TextMeshProUGUI>();
        instructionText = transform.Find("Instructions").GetComponent<TextMeshProUGUI>();
        titleText = transform.Find("Title").GetComponent<TextMeshProUGUI>();
        gameEndText = transform.Find("GameEnd").GetComponent<TextMeshProUGUI>();
        winStatementText = transform.Find("WinStatement").GetComponent<TextMeshProUGUI>();
        loseStatementText = transform.Find("LoseStatement").GetComponent<TextMeshProUGUI>();
        restartMessageText = transform.Find("RestartMessage").GetComponent<TextMeshProUGUI>();
        levelText = transform.Find("LevelMessage").GetComponent<TextMeshProUGUI>();
    }

    void Update()
    {
        string text = "";
        text = getRandomFact();
        //if (text == "0") text = "Fact: \n" + text;
        factText.text = text;

        text = getTitle();
        titleText.text = text;

        text = getInstructions();
        instructionText.text = text;

        text = getGameEnd();
        gameEndText.text = text;

        text = getWinStatement();
        winStatementText.text = text;
        text = getLoseStatement();
        loseStatementText.text = text;

        text = getRestartMessage();
        restartMessageText.text = text;

        text = getLevelMessage(scoring.getCurrentScore());
        levelText.text = text;
    }

    public string getLevelMessage(int score)
    {
        string statement = "";
        if (!scoring.GetDisplayState())
        {
            if (score >= 1 && score <= 2)
            {
                statement = "Level 1";
            }

            int scoreMod = score % SecondsPerLevel;
            int levelNum = score / SecondsPerLevel + 1;
            if (levelNum > 1 && 0 <= scoreMod && scoreMod <= 1 && levelNum <= 10)
            {
                statement = "Level " + levelNum;
            }

            if (score >= SecondsPerLevel * LevelCountBeforeInfiniteLevel &&
                score <= SecondsPerLevel * LevelCountBeforeInfiniteLevel)
            {
                statement = "Level Infinity...";
            }
        }
        else
        {
            statement = "";
        }

        return statement;
    }

    public void getRandNumberIndex()
    {
        randnum = UnityEngine.Random.Range(0, randfacts.Count);
    }

    public string getRandomFact()
    {
        string fact = "";
        if (scoring.GetDisplayState())
        {
            fact = "Fact:\n" + randfacts[randnum];
            // // Unit Test Start
            // if(fact.Equals("")) Debug.Log("Got empty random fact.");
            // // Unit Test End
        }

        if (gameController.GetGameState() == GameController.PAUSED)
        {
            fact = "Fact:\n" + randfacts[randnum];
            // // Unit Test Start
            // if(fact.Equals("")) Debug.Log("Got empty random fact.");
            // // Unit Test End
        }

        return fact;
    }

    public string getInstructions()
    {
        string instr = "";
        if (gameController.GetGameState() == GameController.PAUSED)
        {
            instr = "How to play: \n\n" +
                    "Click spacebar to Jump\n\n" +
                    "But not too high or you'll get lost in space";
        }

        return instr;
    }

    public string getTitle()
    {
        string instr = "";
        if (gameController.GetGameState() == GameController.PAUSED)
        {
            instr = "Lost in Space";
        }

        //unit test
        //if string 'instr' is empty, then the title is not being saved
        //if(instr == "")
        //{
        //    Debug.Log("Title not being saved");
        //}
        return instr;
    }

    public string getGameEnd()
    {
        string statement = "";
        if (scoring.GetDisplayState())
        {
            statement = "Game Over!";
        }

        return statement;
    }

    public string getWinStatement()
    {
        string statement = "";
        if (scoring.GetDisplayState())
        {
            if (scoring.getCurrentScore() == scoring.getHighScore())
            {
                statement = "Congratulations, New High Score!";
            }
            else
            {
                statement = "";
            }
        }

        return statement;
    }

    public string getLoseStatement()
    {
        string statement = "";
        if (scoring.GetDisplayState())
        {
            if (scoring.getCurrentScore() == scoring.getHighScore())
            {
                statement = "";
            }
            else
            {
                statement = "Unlucky, better luck next time...";
            }
        }

        return statement;
    }


    public string getRestartMessage()
    {
        string statement = "";
        if (scoring.GetDisplayState())
        {
            statement = "Click spacebar to restart...";
        }

        return statement;
    }
}