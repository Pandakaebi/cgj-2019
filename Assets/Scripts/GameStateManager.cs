using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameStateManager : MonoBehaviour
{
    private Ball ball;
    public Dictionary<PlayerType, int> PlayerScores;
    public Dictionary<PlayerType, bool> PlayerTwist;
    public Dictionary<PlayerType, float> PlayerSpeed;
    public Dictionary<PlayerType, int> PlayerHealth;
    public UnityEvent OnTwistEvent = new UnityEvent();
    public UnityEvent OnPlayerScore = new UnityEvent();
    public float BallSpeed = 35;
    [SerializeField] private float ballSpeedFast = 50;
    [SerializeField] private int twistThreshold = 5;
    [SerializeField] private float playerSpeedStart = 35;
    [SerializeField] private float playerSpeedFast = 50;
    [SerializeField] private float playerSpeedSlow = 20;
    [SerializeField] private int playerHealthStart = 100;
    public int PlayerDamage = 20;

    //[SerializeField] private float readonlyPlayerOneSpeed;
    //[SerializeField] private float readonlyPlayerTwoSpeed;

    // Start is called before the first frame update
    void Start()
    {
        GameSetup();
        ball = FindObjectOfType<Ball>();
    }

    void Update()
    {
        //readonlyPlayerOneSpeed = PlayerSpeed[PlayerType.PlayerOne];
        //readonlyPlayerTwoSpeed = PlayerSpeed[PlayerType.PlayerTwo];
    }

    public void AddScore(PlayerType playerType)
    {
        PlayerScores[playerType] += 1;
        OnPlayerScore.Invoke();

        // Twist condition
        if (PlayerScores[playerType] == twistThreshold)
        {
            SetTwist(playerType, true);
        }
  
        if (PlayerTwist[PlayerType.PlayerOne] == true && PlayerTwist[PlayerType.PlayerTwo] == true)
        {
            BallSpeed = ballSpeedFast;
            PlayerSpeed[PlayerType.PlayerOne] = playerSpeedFast;
            PlayerSpeed[PlayerType.PlayerTwo] = playerSpeedFast;
        }

        ball.ReturnToStartPosition();
    }

    public void ModifyHealth(PlayerType playerType, int damage)
    {
        PlayerHealth[playerType] -= damage;
    }

    public void SetTwist(PlayerType playerType, bool active)
    {
        PlayerTwist[playerType] = active;
        PlayerSpeed[playerType] = playerSpeedSlow;
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
        PlayerSpeed.Add(PlayerType.PlayerOne, playerSpeedStart);
        PlayerSpeed.Add(PlayerType.PlayerTwo, playerSpeedStart);

        PlayerHealth = new Dictionary<PlayerType, int>();
        PlayerHealth.Add(PlayerType.PlayerOne, playerHealthStart);
        PlayerHealth.Add(PlayerType.PlayerTwo, playerHealthStart);
    }
}

public enum PlayerType
{
    PlayerOne,
    PlayerTwo
}