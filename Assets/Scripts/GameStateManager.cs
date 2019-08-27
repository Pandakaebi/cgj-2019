using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameStateManager : MonoBehaviour
{
    public Dictionary<PlayerType, int> PlayerScores;
    public UnityEvent OnTwistEvent = new UnityEvent();
    public UnityEvent OnPlayerScore = new UnityEvent();
    public bool TwistState = false;

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
        PlayerScores[playerType] += 1;
        OnPlayerScore.Invoke();

        if (PlayerScores[playerType] >= 5)
        {
            OnTwistEvent.Invoke();
        }
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