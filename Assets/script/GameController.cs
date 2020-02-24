using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public GameObject hazard;

    public bool playing = false;

    private PlayerHandler playerHandler;
    private Scoring scoringHandler;
    private Music _music;

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

    // Start is called before the first frame update
    void Start()
    {
        playerHandler = GameObject.Find("Player").GetComponent<PlayerHandler>();
        scoringHandler = GameObject.Find("Player").GetComponent<Scoring>();
        _music = Music.GetInstance();

        asteroids = new List<GameObject>();
        StartCoroutine(SpawnAsteroids());
    }

    IEnumerator SpawnAsteroids()
    {
        while (true)
        {
            if (playing)
            {
                while (Mathf.Abs(prevSpawn - yVal) < spawnBuffer) yVal = Random.Range(yMin, yMax);
                Vector2 spawnPosition = new Vector2(
                    xVal,
                    yVal);
                prevSpawn = yVal;

                GameObject asteroid = Instantiate(hazard, spawnPosition, Quaternion.identity);

                asteroids.Add(asteroid);

                while (Mathf.Abs(prevScale - randScale) < scaleBuffer) randScale = Random.Range(scaleMin, scaleMax);
                asteroid.transform.localScale = new Vector3(randScale, randScale, randScale);
                prevScale = randScale;

                asteroid.GetComponent<Rigidbody2D>().velocity = new Vector2(hazardSpeed, 0);

                if (spawnWait > 1.0f) spawnWait -= 0.01f;
            }

            yield return new WaitForSeconds(spawnWait);
        }
    }


    // Update is called once per frame
    void Update()
    {
        if (!playing)
        {
            // User control 
            if (Input.GetKeyDown(KeyCode.Space))
            {
                playing = true;
                playerHandler.SetPlayState(true);
                scoringHandler.SetPlayState(true);
                _music.PlayGameMusic();
            }
        }
    }

    public void PlayerDeath()
    {
        playing = false;

        foreach (GameObject asteroid in asteroids)
        {
            Destroy(asteroid);
        }

        playerHandler.SetPlayState(false);
        scoringHandler.SetPlayState(false);
        _music.PlayMenuMusic();
    }
}