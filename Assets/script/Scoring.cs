using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scoring : MonoBehaviour
{
    private static Scoring instance;

    private int score = 0;

    void Awake()
    {
        instance = this;
    }

    public static Scoring getInstance()
    {
        return instance;
    }

    // Update is called once per frame
    void Update()
    {
        score = (int)Time.realtimeSinceStartup;
    }

    public int getCurrentScore()
    {
        return score;
    }
}