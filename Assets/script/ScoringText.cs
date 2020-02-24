using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ScoringText : MonoBehaviour
{
    private TextMeshProUGUI scoreText;
    // Start is called before the first frame update
    void Start()
    {
        scoreText = transform.Find("CurrentScore").GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        string text = Scoring.getInstance().getCurrentScore().ToString();
        if (text == "0") text = "Press Space Bar to Start";
        scoreText.text = text;
    }
}
