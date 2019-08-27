using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameStateManager : MonoBehaviour
{
    public Dictionary<PlayerType, int> PlayerScores;
    public Dictionary<PlayerType, bool> PlayerTwist;
    public Dictionary<PlayerType, float> PlayerSpeed;
    public UnityEvent OnTwistEvent = new UnityEvent();
    public UnityEvent OnPlayerScore = new UnityEvent();
    public float BallSpeed = 30;
    [SerializeField] private int twistThreshold = 5;
    [SerializeField] private float startingSpeed = 30;
    [SerializeField] private float ballSpeedSupercharged = 60;

    // Start is called before the first frame update
    void Start()
    {
        GameSetup();
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerScores[PlayerType.PlayerOne] >= 10 && PlayerScores[PlayerType.PlayerTwo] >= 10)
        {
            BallSpeed = ballSpeedSupercharged;
        }
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

        PlayerSpeed = new Dictionary<PlayerType, float>();
        PlayerSpeed.Add(PlayerType.PlayerOne, startingSpeed);
        PlayerSpeed.Add(PlayerType.PlayerTwo, startingSpeed);
    }
}

public enum PlayerType
{
    PlayerOne,
    PlayerTwo
}