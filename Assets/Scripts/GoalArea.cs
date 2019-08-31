using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalArea : MonoBehaviour
{
    private GameStateManager gameStateManager;
    private AudioSource audioSource;
    [SerializeField] private AudioClip goal;
    [SerializeField] private PlayerType playerType;
    [SerializeField] private PlayerType oppositionType;

    // Start is called before the first frame update
    void Start()
    {
        gameStateManager = FindObjectOfType<GameStateManager>();
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = goal;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        gameStateManager.AddScore(playerType);
        gameStateManager.ModifyHealth(oppositionType, gameStateManager.PlayerDamage);
        audioSource.Play();
    }
}
