using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutOfBands : MonoBehaviour
{
    private Ball ball;

    private void Start()
    {
        ball = FindObjectOfType<Ball>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<Ball>() != null)
        {
            ball.ReturnToStartPosition(true, PlayerType.PlayerOne);
        }
    }
}
