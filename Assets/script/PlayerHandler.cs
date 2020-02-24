using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHandler : MonoBehaviour
{
    private const float JUMP_AMOUNT = 5f;
    private const float ORIGINAL_PLAYER_POSITION_X = -2f;
    private readonly Vector3 ORIGINAL_PLAYER_POSITION = new Vector3(ORIGINAL_PLAYER_POSITION_X, 0, 0);

    private Rigidbody2D playerRigidbody;

    private int gameState = 1;
    private const int START = 0;
    private const int PAUSED = 1;
    private const int PLAYING = 2;
    private const int DEATH = 3;

    private float jumpWait = 0.99f;

    private GameController gameController;

    void Start()
    {
        playerRigidbody = GetComponent<Rigidbody2D>();
        gameController = GameObject.Find("GameController").GetComponent<GameController>();
        transform.position = ORIGINAL_PLAYER_POSITION;
        StartCoroutine(AutoJump());
    }

    IEnumerator AutoJump()
    {
        while (true)
        {
            if (gameState==PAUSED)
            {
                playerRigidbody.velocity = Vector2.up * JUMP_AMOUNT;
            }

            yield return new WaitForSeconds(jumpWait);
        }
    }

    void Update()
    {
        if (gameState==PLAYING)
        {
            // User control 
            if (Input.GetKeyDown(KeyCode.Space))
            {
                playerRigidbody.velocity = Vector2.up * JUMP_AMOUNT;
            }

            if (transform.position.x < ORIGINAL_PLAYER_POSITION_X)
            {
                playerRigidbody.velocity = Vector2.right;
            }

            // // Unit test start: player position
            // if (transform.position.x < -15 || transform.position.x > 15f)
            //     Debug.Log("Player position exception!");
            // // Unit test end
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // // Unit test start
        // Debug.Log("Player collision happen!");
        // // Unit test end
        gameController.PlayerDeath();
    }

    public void SetPlayState(int state)
    {
        gameState = state;
        if (gameState==PAUSED) playerRigidbody.transform.position = ORIGINAL_PLAYER_POSITION;
        playerRigidbody.velocity = Vector2.up * JUMP_AMOUNT;
    }
}