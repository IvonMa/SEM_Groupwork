using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ScoringText : MonoBehaviour
{
    private TextMeshProUGUI currScoreText;
    private TextMeshProUGUI highScoreText;
    private TextMeshProUGUI factText;
    private TextMeshProUGUI instructionText;
    private TextMeshProUGUI titleText;
    private TextMeshProUGUI gameEndText;
    private TextMeshProUGUI winStatementText;
    private TextMeshProUGUI loseStatementText;
    private TextMeshProUGUI restartMessageText;
    private TextMeshProUGUI levelText;
    // Start is called before the first frame update
    void Start()
    {
        currScoreText = transform.Find("CurrentScore").GetComponent<TextMeshProUGUI>();
        highScoreText = transform.Find("HighScore").GetComponent<TextMeshProUGUI>();
        factText = transform.Find("RandFact").GetComponent<TextMeshProUGUI>();
        instructionText = transform.Find("Instructions").GetComponent<TextMeshProUGUI>();
        titleText = transform.Find("Title").GetComponent<TextMeshProUGUI>();
        gameEndText = transform.Find("GameEnd").GetComponent<TextMeshProUGUI>();
        winStatementText = transform.Find("WinStatement").GetComponent<TextMeshProUGUI>();
        loseStatementText = transform.Find("LoseStatement").GetComponent<TextMeshProUGUI>();
        restartMessageText = transform.Find("RestartMessage").GetComponent<TextMeshProUGUI>();
        levelText = transform.Find("LevelMessage").GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        string text = Scoring.getInstance().getCurrentScore().ToString();
        if (text == "0") text = "";
        else text = "Score: " + text;
        currScoreText.text = text;

        text = Scoring.getInstance().getHighScore().ToString();
        if (text == "0") text = "";
        else text = "High Score: " + text;
        highScoreText.text = text;

        text = Scoring.getInstance().getRandomFact();
        //if (text == "0") text = "Fact: \n" + text;
        factText.text = text;

        text = Scoring.getInstance().getTitle();
        titleText.text = text;

        text = Scoring.getInstance().getInstructions();
        instructionText.text = text;

        text = Scoring.getInstance().getGameEnd();
        gameEndText.text = text;

        text = Scoring.getInstance().getWinStatement();
        winStatementText.text = text;
        text = Scoring.getInstance().getLoseStatement();
        loseStatementText.text = text;

        text = Scoring.getInstance().getRestartMessage();
        restartMessageText.text = text;

        text = Scoring.getInstance().getLevelMessage();
        levelText.text = text;
        
    }
}
