using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private GameStateManager gameStateManager;
    private AudioSource audioSource;
    [SerializeField] private AudioClip playerHit;
    [SerializeField] private AudioClip playerDamaged;
    [SerializeField] private AudioClip playerDestroyed;
    [SerializeField] private PlayerType playerType;
    [SerializeField] private string axis = "Vertical";

    private void Start()
    {
        gameStateManager = FindObjectOfType<GameStateManager>();
        gameStateManager.OnPlayerScore.AddListener(OnScoreUpdate);
        gameStateManager.OnTwistEvent.AddListener(OnTwistUpdate);
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = playerHit;
    }

    private void Update()
    {
        float v = Input.GetAxisRaw(axis);
        GetComponent<Rigidbody2D>().velocity = new Vector2(0, v) * gameStateManager.PlayerSpeed[playerType];
    }
    private void OnScoreUpdate()
    {
        
    }

    private void OnTwistUpdate()
    {
        if (gameStateManager.PlayerTwist[playerType] != false)
        {
            audioSource.clip = playerDamaged;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<Ball>() != null)
        {
            audioSource.Play();
        }
    }
}
