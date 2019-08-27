using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameUi : MonoBehaviour
{
    private GameStateManager gameStateManager;
    [SerializeField] private Text playerOneScore;
    [SerializeField] private Text playerTwoScore;
    [SerializeField] private GameObject playerOneTwist;
    [SerializeField] private GameObject playerTwoTwist;
    // Start is called before the first frame update
    void Start()
    {
        gameStateManager = FindObjectOfType<GameStateManager>();
        gameStateManager.OnPlayerScore.AddListener(OnScoreUpdate);
        gameStateManager.OnTwistEvent.AddListener(OnTwistUpdate);

        OnTwistUpdate();
    }
    
    private void OnScoreUpdate()
    {
        playerOneScore.text = gameStateManager.PlayerScores[PlayerType.PlayerOne].ToString();
        playerTwoScore.text = gameStateManager.PlayerScores[PlayerType.PlayerTwo].ToString();
    }

    private void OnTwistUpdate()
    {
        playerOneTwist.SetActive(gameStateManager.PlayerTwist[PlayerType.PlayerOne]);
        playerTwoTwist.SetActive(gameStateManager.PlayerTwist[PlayerType.PlayerTwo]);
    }
}
