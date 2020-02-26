using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class GameController : MonoBehaviour
{
    private static GameController instance;

    public static GameController GetInstance()
    {
        return instance;
    }
    public GameObject hazard;

    private int gameState = 1;

    public const int START = 0;
    public const int PAUSED = 1;
    public const int PLAYING = 2;
    public const int DEATH = 3;


    private PlayerHandler playerHandler;
    private Scoring scoringHandler;

    private List<GameObject> asteroids;

    //TODO: fit these to screen size
    private float xVal = 10.0f;
    private float yVal = 0.0f;
    private float yMin = -2.0f;
    private float yMax = 4.0f;

    private float prevSpawn = 1.0f;
    private float spawnBuffer = 0.5f;

    private float spawnWait = 5.0f;

    private float randScale = 1.0f;
    private float prevScale = 1.0f;

    private float scaleBuffer = 0.1f;
    private float scaleMin = 0.25f;
    private float scaleMax = 0.65f;

    private float hazardSpeed = -2.0f;

    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        playerHandler = GameObject.Find("Player").GetComponent<PlayerHandler>();
        scoringHandler = GameObject.Find("Player").GetComponent<Scoring>();
        Scoring.getInstance().getRandNumberIndex();
        asteroids = new List<GameObject>();
        StartCoroutine(SpawnAsteroids());
    }

    IEnumerator SpawnAsteroids()
    {
        while (true)
        {
            switch(gameState)
            {


                case(START):
                    //startscreen 
                    break;
                case(PAUSED):
                    break;
                case(PLAYING):

                    while (Mathf.Abs(prevSpawn - yVal) < spawnBuffer) yVal = Random.Range(yMin, yMax);
                    Vector2 spawnPosition = new Vector2(xVal, yVal);
                    prevSpawn = yVal;

                    GameObject asteroid = Instantiate(hazard, spawnPosition, Quaternion.identity);

                    asteroids.Add(asteroid);

                    while (Mathf.Abs(prevScale - randScale) < scaleBuffer) randScale = Random.Range(scaleMin, scaleMax);
                    asteroid.transform.localScale = new Vector3(randScale, randScale, randScale);
                    prevScale = randScale;

                    asteroid.GetComponent<Rigidbody2D>().velocity = new Vector2(hazardSpeed, 0);

                    if (spawnWait > 1.0f) spawnWait -= 0.01f;
                    break;




                case(DEATH):
                    //highscore screen
                    

                    break;
                default:
                    gameState = START;
                    playerHandler.SetPlayState(START);
                    scoringHandler.SetPlayState(START);
                    break;
            
              

            }
            yield return new WaitForSeconds(spawnWait);
        }
    }


    // Update is called once per frame
    void Update()
    {
       switch(gameState)

        {
            case(START):
                break;
            case(PAUSED):
                if (Input.GetKeyDown(KeyCode.Space))
                {   

                    gameState=PLAYING;
                    playerHandler.SetPlayState(PLAYING);
                    scoringHandler.SetPlayState(PLAYING);
                }
                break;
            case(PLAYING):
                break;
            case(DEATH):
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    Scoring.getInstance().getRandNumberIndex();
                    gameState= PAUSED;
                    playerHandler.SetPlayState(PAUSED);
                    scoringHandler.SetPlayState(PAUSED);
                }
                break;
            default:
                break;
            
            
        }
        
    }

    public void PlayerDeath()
    {
        // Unit Test Start
        // Test whether the game is in right state when this function is called
        if (gameState != PLAYING && gameState != DEATH)
            Debug.Log("Game is in wrong state when player dead. Current state is:" + gameState);
        // Unit Test End
           
        if(gameState!= DEATH)
        {
            Scoring.getInstance().getRandNumberIndex();
        }
        gameState = DEATH;
        foreach(GameObject asteroid in asteroids)
        {
            Destroy(asteroid);
        }
        spawnWait = 5.0f;
        playerHandler.SetPlayState(DEATH);
        scoringHandler.SetPlayState(DEATH);
        

    }

    public int GetGameState()
    {
        return gameState;
    }
    
}
