using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public GameObject hazard;
    public float xVal = 30.0f;              //set this to just beyond screen
    public float yMin = -10.0f;
    public float yMax = 10.0f;
    public float spawnWait = 5.0f;

    public float hazardSpeed = -2.0f;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnAsteroids());
    }

    IEnumerator SpawnAsteroids()
    {
        while (true)
        {
            Vector2 spawnPosition = new Vector2(
                xVal,
                Random.Range(yMin, yMax));

            GameObject asteroid = Instantiate(hazard, spawnPosition, Quaternion.identity);

            asteroid.GetComponent<Rigidbody2D>().velocity = new Vector2(hazardSpeed, 0);

            if (spawnWait > 1.0f) spawnWait -= 0.05f;

            yield return new WaitForSeconds(spawnWait);
        }
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
