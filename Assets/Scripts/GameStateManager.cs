using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameStateManager : MonoBehaviour
{
    public Dictionary<PlayerType, int> PlayerScores;
    public Dictionary<PlayerType, bool> PlayerTwist;
    public UnityEvent OnTwistEvent = new UnityEvent();
    public UnityEvent OnPlayerScore = new UnityEvent();
    [SerializeField] private int twistThreshold = 5;

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

        if (PlayerScores[playerType] >= twistThreshold)
        {
            SetTwist(playerType, true);
        }
        else
        {
            SetTwist(playerType, false);
        }
    }

    public void SetTwist(PlayerType playerType, bool active)
    {
        PlayerTwist[playerType] = active;
        OnTwistEvent.Invoke();
    }

    private void GameSetup()
    {
        PlayerScores = new Dictionary<PlayerType, int>();
        PlayerScores.Add(PlayerType.PlayerOne, 0);
        PlayerScores.Add(PlayerType.PlayerTwo, 0);

        PlayerTwist = new Dictionary<PlayerType, bool>();
        PlayerTwist.Add(PlayerType.PlayerOne, false);
        PlayerTwist.Add(PlayerType.PlayerTwo, false);
    }
}

public enum PlayerType
{
    PlayerOne,
    PlayerTwo
}