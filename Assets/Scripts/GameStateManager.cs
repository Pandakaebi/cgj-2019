using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameStateManager : MonoBehaviour
{
    public Dictionary<PlayerType, int> PlayerScores;
    public UnityEvent OnTwistEvent = new UnityEvent();
    public UnityEvent OnPlayerScore = new UnityEvent();

    // Start is called before the first frame update
    void Start()
    {
        GameSetup();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddScore(PlayerType playerType)
    {
        PlayerScores[playerType] = PlayerScores[playerType] + 1;
        OnPlayerScore.Invoke();
    }

    private void GameSetup()
    {
        PlayerScores = new Dictionary<PlayerType, int>();
        PlayerScores.Add(PlayerType.PlayerOne, 0);
        PlayerScores.Add(PlayerType.PlayerTwo, 0);
    }
}

public enum PlayerType
{
    PlayerOne,
    PlayerTwo
}