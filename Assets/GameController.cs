using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public GameObject hazard;

    //TODO: fit these to screen size
    public float xVal = 15.0f;
    public float yVal = 0.0f;
    public float yMin = -3.0f;
    public float yMax = 4.0f;
    public float prevSpawn = 1.0f;
    public float spawnBuffer = 0.5f;

    public float spawnWait = 5.0f;

    public float randScale = 1.0f;
    public float prevScale = 1.0f;
   
    public float scaleBuffer = 0.1f;
    public float scaleMin = 0.25f;
    public float scaleMax = 0.75f;

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
            while (Mathf.Abs(prevSpawn - yVal) < spawnBuffer) yVal = Random.Range(yMin, yMax);
            Vector2 spawnPosition = new Vector2(
                xVal,
                yVal);
            prevSpawn = yVal;

            GameObject asteroid = Instantiate(hazard, spawnPosition, Quaternion.identity);

            while (Mathf.Abs(prevScale - randScale) < scaleBuffer) randScale = Random.Range(scaleMin, scaleMax);
            asteroid.transform.localScale = new Vector3(randScale, randScale, randScale);
            prevScale = randScale;

            asteroid.GetComponent<Rigidbody2D>().velocity = new Vector2(hazardSpeed, 0);

            if (spawnWait > 1.0f) spawnWait -= 0.01f;

            yield return new WaitForSeconds(spawnWait);
        }
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
