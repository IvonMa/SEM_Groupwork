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

    private int randnum = 0;

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


        try{
        string path = "Assets/SpaceFacts.txt";

        string line; //current line
        System.IO.StreamReader file = new System.IO.StreamReader(path);
        while((line = file.ReadLine()) != null)
        {
            randfacts.Add(line);
        }
    }
    catch(Exception e){}
        
         
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

    public void getRandNumberIndex()
    {
        randnum = UnityEngine.Random.Range(0,randfacts.Count);
        
    }

    public string getRandomFact()
    {
        string fact = "";
        if (display)
        {
            fact = "Fact:\n" + randfacts[randnum];
            // // Unit Test Start
            // if(fact.Equals("")) Debug.Log("Got empty random fact.");
            // // Unit Test End
        }
        if (score == 0)
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
        if (score == 0)
        {
            instr = "How to play: \n\nClick spacebar to go higher as gravity pulls you down.\n\n...But not too high or you'll get lost in space...\n\nGood luck!"; 
        }
        return instr;
    }
    public string getTitle()
    {
        string instr = "";
        if (score == 0)
        {
            instr = "Protect the Planet"; 
        }

        // unit test
        // if string'instr' is empty, then the title is not being saved
        // if(instr == "")
        // {
        // Debug.Log("Title not being saved.");
    	// }

        return instr;
    }
    public string getGameEnd()
    {
        string statement = "";
        if (display)
        {
            statement = "Game Over!"; 
        }
        // unit test
    	// if string statment is empty, Game Over message isn't being displayed.
    	// if (statement == "") Debug.Log("Game over message isn't being displayed.");
        // Unit test end
        return statement;

    }
    

    public string getWinStatement()
    {
        string statement = "";
        if (display)
        {
            if(getCurrentScore() == getHighScore())
            {
                statement = "Congratulations, New High Score!"; 
            }
            else{
                statement = "";
            }
        }
        return statement;
    }
    public string getLoseStatement()
    {
        string statement = "";
        if (display)
        {
            if(getCurrentScore() == getHighScore())
            {
                statement = ""; 
            }
            else{
                statement = "Unlucky, better luck next time...";
            }
        }
        return statement;
    }


    public string getRestartMessage()
    {
        string statement = "";
        if (display)
        {
            statement = "Click spaceBar to restart...";
        }
        return statement;
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