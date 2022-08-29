using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;

    public Rigidbody2D rb;
    public Animator animator;

    Vector2 movement;

    void Update()
    {
        // Input
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            switch (GameManager.Instance.GetGameState())
            {
                case GameState.GameStart:
                    break;
                case GameState.Shop:
                    break;
                case GameState.Pause:
                    GameManager.Instance.UpdateGameState(GameState.Play);
                    break;
                case GameState.Play:
                    GameManager.Instance.UpdateGameState(GameState.Pause);
                    break;
                case GameState.GameOver:
                    break;
                case GameState.QuitGame:
                    break;
                default:
                    break;
            }
        }



        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        movement = movement.normalized;

        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Speed", movement.sqrMagnitude);
    }

    void FixedUpdate()
    {
        // Movement
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }
}
