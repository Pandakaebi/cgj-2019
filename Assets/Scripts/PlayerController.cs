using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private GameStateManager gameStateManager;
    [SerializeField] private PlayerType playerType;
    [SerializeField] private string axis = "Vertical";

    private void Start()
    {
        gameStateManager = FindObjectOfType<GameStateManager>();
        gameStateManager.OnPlayerScore.AddListener(OnScoreUpdate);
    }

    private void Update()
    {
        float v = Input.GetAxisRaw(axis);
        GetComponent<Rigidbody2D>().velocity = new Vector2(0, v) * gameStateManager.PlayerSpeed[playerType];
    }
    private void OnScoreUpdate()
    {
        if (gameStateManager.PlayerScores[playerType] == 5)
        {
            gameStateManager.PlayerSpeed[playerType] -= 10;
        }
    }
}
