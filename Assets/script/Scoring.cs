﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.IO;
using System;

public class Scoring : MonoBehaviour
{
    private static Scoring instance;

    private int score = 0;
    private int highscore = 0;


    private bool display= false;
    
    public bool GetDisplayState()
    {
        return display;
    }


    

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
                display = false;
                break;
            case(PAUSED):
                score = 0;
                display = false;
                break;
            case(PLAYING):
                score = (int)(timer.ElapsedMilliseconds / 1000);
                display = false;
                break;
            case(DEATH):
                if (!display) {
                    highscore = findHighScore();
                    if (score > highscore) {
                        setHighScore();
                        highscore = score;
                    }
                }
                display = true;
                //unit test
                //if display is true, then high score screen becomes visible
               // if(display)
               // {
                //    Debug.Log("High Score Screen visible");
               // }

                break;
            default:
                score = 0;
                display = false;
                break;  
        }
        
    }

    public int getCurrentScore()
    {
        return score;
    }

    public int getHighScore()
    {
        if (display) return highscore;
        else return 0;
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

    private int findHighScore()
    {
        //read from file and return highscore, & compare

    
        string path = "Assets/HighScore.txt";
        
        // Unit Test
        // Test the high score file exists
        //if(!File.Exists(path)) Debug.Log("Cannot find high score file when trying to read it.");
        // Unit Test End

        //Read the text from directly from the test.txt file
        StreamReader reader = new StreamReader(path); 
        
        string line = reader.ReadToEnd();
        reader.Close();
        
        int findScore = 0;

        try 
        {
            findScore = Int32.Parse(line);
        } catch (Exception e){};
        return findScore;    
    }

    private void setHighScore()
    {
         if(getCurrentScore() > getHighScore())
         {
            //unit test
            //If the current score is greater than the highscore, the high score should be updated
            //Debug.Log("High Score to be updated.");

            string path = "Assets/HighScore.txt";
            StreamWriter writer = new StreamWriter(path, false);
            writer.WriteLine(getCurrentScore());
            writer.Close();
         }
         else{
            //Unit Test
            //If the current score is less than or equal to than the highscore, the high score shouldn't be updated
            //Debug.Log("High Score won't be updated.");
            //insert message of not reaching the high score
         }
         //unit test
         //is the high score being saved if the current score exceeds the previous highscore
        //if(findHighScore() != getCurrentScore())
        //{ Debug.Log("High Score not being saved to game textfile"); }
    }



}