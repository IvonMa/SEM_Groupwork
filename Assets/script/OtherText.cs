using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class OtherText : MonoBehaviour
{
    private TextMeshProUGUI factText;
    private TextMeshProUGUI instructionText;
    private TextMeshProUGUI titleText;
    private TextMeshProUGUI gameEndText;
    private TextMeshProUGUI winStatementText;
    private TextMeshProUGUI loseStatementText;
    private TextMeshProUGUI restartMessageText;
    private TextMeshProUGUI levelText;
    private Scoring scoring;
    private const int SecondsPerLevel = 5;
    private const int LevelCountBeforeInfiniteLevel = 10;

    void Start()
    {
        scoring = Scoring.getInstance();
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
        text = scoring.getRandomFact();
        //if (text == "0") text = "Fact: \n" + text;
        factText.text = text;

        text = scoring.getTitle();
        titleText.text = text;

        text = scoring.getInstructions();
        instructionText.text = text;

        text = scoring.getGameEnd();
        gameEndText.text = text;

        text = scoring.getWinStatement();
        winStatementText.text = text;
        text = scoring.getLoseStatement();
        loseStatementText.text = text;

        text = scoring.getRestartMessage();
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
}