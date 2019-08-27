using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameUi : MonoBehaviour
{
    private GameStateManager gameStateManager;
    [SerializeField] private Text playerOneScore;
    [SerializeField] private Text playerTwoScore;
    [SerializeField] private GameObject twistText;
    // Start is called before the first frame update
    void Start()
    {
        gameStateManager = FindObjectOfType<GameStateManager>();
        gameStateManager.OnPlayerScore.AddListener(OnScoreUpdate);
        gameStateManager.OnTwistEvent.AddListener(OnTwistUpdate);

        twistText.SetActive(false);
    }
    
    private void OnScoreUpdate()
    {
        playerOneScore.text = gameStateManager.PlayerScores[PlayerType.PlayerOne].ToString();
        playerTwoScore.text = gameStateManager.PlayerScores[PlayerType.PlayerTwo].ToString();
    }

    private void OnTwistUpdate()
    {
        twistText.SetActive(true);
    }
}
