using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    private GameStateManager gameStateManager;
    private Vector2 startingPoint;

    float hitFactor(Vector2 ballPos, Vector2 racketPos, float racketHeight)
    {
        return (ballPos.y - racketPos.y) / racketHeight;
    }

    void Start()
    {
        gameStateManager = FindObjectOfType<GameStateManager>();
        startingPoint = this.transform.position;

        // Initial velocity
        GetComponent<Rigidbody2D>().velocity = Vector2.right * gameStateManager.BallSpeed;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "RacketLeft")
        {
            // Calculate hit factor
            float y = hitFactor(transform.position, collision.transform.position, collision.collider.bounds.size.y);

            // Calculate direction, make lenght=1 via .normalized
            Vector2 dir = new Vector2(1, y).normalized;

            // Set Velocity with dir * speed
            GetComponent<Rigidbody2D>().velocity = dir * gameStateManager.BallSpeed;
        }

        if (collision.gameObject.name == "RacketRight")
        {
            // Calculate hit factor
            float y = hitFactor(transform.position, collision.transform.position, collision.collider.bounds.size.y);

            // Calculate direction, make lenght=1 via .normalized
            Vector2 dir = new Vector2(-1, y).normalized;

            // Set Velocity with dir * speed
            GetComponent<Rigidbody2D>().velocity = dir * gameStateManager.BallSpeed;
        }
    }

    public void ReturnToStartPosition(bool resetVelocity, PlayerType playerType)
    {
        this.transform.position = startingPoint;
        if(resetVelocity == true)
        {
            if (playerType == PlayerType.PlayerOne)
            {
                GetComponent<Rigidbody2D>().velocity = Vector2.left * gameStateManager.BallSpeed;
            }
            else if(playerType == PlayerType.PlayerTwo)
            {
                GetComponent<Rigidbody2D>().velocity = Vector2.right * gameStateManager.BallSpeed;

            }
        }
    }
}
