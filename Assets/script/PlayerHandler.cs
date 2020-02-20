using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHandler : MonoBehaviour
{
    private const float JUMP_AMOUNT = 5f;
    private const float ORIGINAL_PLAYER_POSITION_X = -2f;
    private readonly Vector3 ORIGINAL_PLAYER_POSITION = new Vector3(ORIGINAL_PLAYER_POSITION_X, 0, 0);

    private Rigidbody2D playerRigidbody;

    private bool playing = false;

    private float jumpWait = 1.0f;

    void Start()
    {
        playerRigidbody = GetComponent<Rigidbody2D>();
        transform.position = ORIGINAL_PLAYER_POSITION;
        StartCoroutine(AutoJump());
    }

    IEnumerator AutoJump()
    {
        while (true)
        {
            if (!playing)
            {
                playerRigidbody.velocity = Vector2.up * JUMP_AMOUNT;

                yield return new WaitForSeconds(jumpWait);
            }
        }
    }

    void Update()
    {
       if (playing)
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
        }   
       else
        {
            // User control 
            if (Input.GetKeyDown(KeyCode.Space))
            {
                playing = true;
                playerRigidbody.velocity = Vector2.up * JUMP_AMOUNT;
            }
        }
    }
}