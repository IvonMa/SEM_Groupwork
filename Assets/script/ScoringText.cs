using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ScoringText : MonoBehaviour
{
    private TextMeshProUGUI currScoreText;
    private TextMeshProUGUI highScoreText;
    // Start is called before the first frame update
    void Start()
    {
        currScoreText = transform.Find("CurrentScore").GetComponent<TextMeshProUGUI>();
        highScoreText = transform.Find("HighScore").GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        string text = Scoring.getInstance().getCurrentScore().ToString();
        if (text == "0") text = "Press Space Bar to Start";
        currScoreText.text = text;

        text = Scoring.getInstance().getHighScore().ToString();
        if (text == "0") text = "";
        else text = "High Score: " + text;
        highScoreText.text = text;
    }
}
