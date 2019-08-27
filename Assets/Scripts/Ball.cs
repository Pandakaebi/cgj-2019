using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] private float speed = 30;

    float hitFactor(Vector2 ballPos, Vector2 racketPos, float racketHeight)
    {
        return (ballPos.y - racketPos.y) / racketHeight;
    }

    void Start()
    {
        // Initial velocity
        GetComponent<Rigidbody2D>().velocity = Vector2.right * speed;
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
            GetComponent<Rigidbody2D>().velocity = dir * speed;
        }

        if (collision.gameObject.name == "RacketRight")
        {
            // Calculate hit factor
            float y = hitFactor(transform.position, collision.transform.position, collision.collider.bounds.size.y);
            // Calculate direction, make lenght=1 via .normalized
            Vector2 dir = new Vector2(-1, y).normalized;
            // Set Velocity with dir * speed
            GetComponent<Rigidbody2D>().velocity = dir * speed;
        }
    }
}
