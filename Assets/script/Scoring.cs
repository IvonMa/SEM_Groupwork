using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scoring : MonoBehaviour
{
    private static Scoring instance;

    private int score = 0;

    System.Diagnostics.Stopwatch timer = new System.Diagnostics.Stopwatch();

    private int gameState = 1;
    private const int START = 0;
    private const int PAUSED = 1;
    private const int PLAYING = 2;
    private const int DEATH = 3;
    
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
        //score = (int)Time.realtimeSinceStartup;


        switch(gameState)

        {
            case(START):
                score = 0;
                break;
            case(PAUSED):
                score = 0;
                break;
            case(PLAYING):
                score = (int)(timer.ElapsedMilliseconds / 1000);
                break;
            case(DEATH):
                //where we implement high scores
                break;
            default:
                break;  
        }
        
    }

    public int getCurrentScore()
    {
        return score;
    }

    public void SetPlayState(int state)
    {
        gameState = state;
        if (state==PLAYING) timer.Start();
        else
        {
            timer.Stop();
            timer.Reset();
        }
    }
}