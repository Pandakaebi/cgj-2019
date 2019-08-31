using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameUi : MonoBehaviour
{
    private GameStateManager gameStateManager;
    [SerializeField] private Text playerOneScore;
    [SerializeField] private Text playerTwoScore;
    [SerializeField] private Text playerOneTwist;
    [SerializeField] private Text playerTwoTwist;
    private PlayerController playerOne;
    private PlayerController playerTwo;

    // Start is called before the first frame update
    void Start()
    {
        gameStateManager = FindObjectOfType<GameStateManager>();
        OnTwistUpdate();
        gameStateManager.OnPlayerScore.AddListener(OnScoreUpdate);
        gameStateManager.OnTwistEvent.AddListener(OnTwistUpdate);
        gameStateManager.OnHealthUpdate.AddListener(HealthUpdate);
        playerOne = GameObject.FindGameObjectWithTag("PlayerOne").GetComponent<PlayerController>();
        playerOne.PlayerDamagedEvent.AddListener(PlayerOneDamaged);
        playerTwo = GameObject.FindGameObjectWithTag("PlayerTwo").GetComponent<PlayerController>();
        playerTwo.PlayerDamagedEvent.AddListener(PlayerTwoDamaged);

    }
    
    private void OnScoreUpdate()
    {
        playerOneScore.text = gameStateManager.PlayerScores[PlayerType.PlayerOne].ToString();
        playerTwoScore.text = gameStateManager.PlayerScores[PlayerType.PlayerTwo].ToString();
    }

    private void OnTwistUpdate()
    {
        playerOneTwist.text = gameStateManager.PlayerHealth[PlayerType.PlayerOne].ToString();
        playerOneTwist.gameObject.SetActive(gameStateManager.PlayerTwist[PlayerType.PlayerOne]);
        playerTwoTwist.text = gameStateManager.PlayerHealth[PlayerType.PlayerTwo].ToString();
        playerTwoTwist.gameObject.SetActive(gameStateManager.PlayerTwist[PlayerType.PlayerTwo]);
    }

    public void HealthUpdate()
    {
        playerOneTwist.text = gameStateManager.PlayerHealth[PlayerType.PlayerOne].ToString();
        playerTwoTwist.text = gameStateManager.PlayerHealth[PlayerType.PlayerTwo].ToString();
    }

    private void PlayerOneDamaged()
    {
        HealthUpdate();
    }

    private void PlayerTwoDamaged()
    {
        HealthUpdate();   
    }
}
