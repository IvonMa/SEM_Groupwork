using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHandler : MonoBehaviour
{
    private const float JUMP_AMOUNT = 5f;
    private readonly Vector3 ORIGINAL_PLAYER_POSITION = new Vector3(-2f, 0, 0);

    private Rigidbody2D playerRigidbody;

    void Start()
    {
        playerRigidbody = GetComponent<Rigidbody2D>();
        transform.position = ORIGINAL_PLAYER_POSITION;
    }

    void Update()
    {
        // User control 
        if (Input.GetKeyDown(KeyCode.Space))
        {
            playerRigidbody.velocity = Vector2.up * JUMP_AMOUNT;
        }
    }
}