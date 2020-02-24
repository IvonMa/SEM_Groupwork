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
    // Start is called before the first frame update
    void Start()
    {
        currScoreText = transform.Find("CurrentScore").GetComponent<TextMeshProUGUI>();
        highScoreText = transform.Find("HighScore").GetComponent<TextMeshProUGUI>();
        factText = transform.Find("FactSection").GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        string text = Scoring.getInstance().getCurrentScore().ToString();
        if (text == "0") text = "How to play: \n\nClick spacebar to go higher as gravity pulls you down. \n\nGood luck!";
        currScoreText.text = text;

        text = Scoring.getInstance().getHighScore().ToString();
        if (text == "0") text = "";
        else text = "High Score: " + text;
        highScoreText.text = text;

        text = Scoring.getInstance().getRandomFact();
        //if (text == "0") text = "Fact: \n" + text;
        factText.text = text;
    }
}
