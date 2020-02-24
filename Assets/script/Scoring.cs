using System.Collections;
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

    System.Diagnostics.Stopwatch timer = new System.Diagnostics.Stopwatch();

    private int gameState = 1;
    private const int START = 0;
    private const int PAUSED = 1;
    private const int PLAYING = 2;
    private const int DEATH = 3;
    public List<string> randfacts = new List<string>();
    void Awake()
    {
        instance = this;


        
        string path = "Assets/SpaceFacts.txt";

        string line; //current line
        System.IO.StreamReader file = new System.IO.StreamReader(path);
        while((line = file.ReadLine()) != null)
         {
             randfacts.Add(line);
         }
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

    public string getRandomFact()
    {

        if (display)
            return randfacts[0];
        else if(score == 0)
            return randfacts[0];
        else return "";

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
            string path = "Assets/HighScore.txt";
            StreamWriter writer = new StreamWriter(path, false);
            writer.WriteLine(getCurrentScore());
            writer.Close();
         }
         else{
            //insert message of not reaching the high score
         }
    }



}