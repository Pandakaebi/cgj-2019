using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameStateManager : MonoBehaviour
{
    public Dictionary<PlayerType, int> PlayerScores;
    public Dictionary<PlayerType, bool> PlayerTwist;
    public Dictionary<PlayerType, float> PlayerSpeed;
    public Dictionary<PlayerType, float> PlayerHealth;
    public UnityEvent OnTwistEvent = new UnityEvent();
    public UnityEvent OnPlayerScore = new UnityEvent();
    public UnityEvent OnHealthUpdate = new UnityEvent();
    public float BallSpeed = 300;
    [SerializeField] private float ballSpeedFast = 450;
    [SerializeField] private int twistThreshold = 5;
    [SerializeField] private float playerSpeedStart = 300;
    [SerializeField] private float playerSpeedFast = 400;
    [SerializeField] private float playerSpeedSlow = 225;
    [SerializeField] private float playerHealthStart = 100;
    public int PlayerDamage = 20;
    private AudioSource audioSource;
    [SerializeField] private AudioClip first;
    [SerializeField] private AudioClip second;
    [SerializeField] private AudioClip third;
    private PlayerController playerOne;
    private PlayerController playerTwo;
    [SerializeField] private int TargetScore = 20;


    //[SerializeField] private float readonlyPlayerOneSpeed;
    //[SerializeField] private float readonlyPlayerTwoSpeed;

    // Start is called before the first frame update
    void Start()
    {
        GameSetup();
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = first;
        audioSource.Play();
        playerOne = GameObject.FindGameObjectWithTag("PlayerOne").GetComponent<PlayerController>();
        playerOne.PlayerDamagedEvent.AddListener(PlayerOneDamaged);
        playerTwo = GameObject.FindGameObjectWithTag("PlayerTwo").GetComponent<PlayerController>();
        playerTwo.PlayerDamagedEvent.AddListener(PlayerTwoDamaged);
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
            if (audioSource.clip == first | audioSource.clip == second)
            {
                audioSource.clip = third;
                audioSource.Play();
            }
        }
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
        if (audioSource.clip == first)
        {
            audioSource.clip = second;
            audioSource.Play();
        }
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

        PlayerHealth = new Dictionary<PlayerType, float>();
        PlayerHealth.Add(PlayerType.PlayerOne, playerHealthStart);
        PlayerHealth.Add(PlayerType.PlayerTwo, playerHealthStart);
    }

    private void PlayerOneDamaged()
    {
        if(PlayerHealth[PlayerType.PlayerOne] <= 0f)
        {
            //playerOne.DestroyPlayer();
            AddScore(PlayerType.PlayerTwo);
            PlayerHealth[PlayerType.PlayerOne] = playerHealthStart;
        }
    }

    private void PlayerTwoDamaged()
    {
        if(PlayerHealth[PlayerType.PlayerTwo] <= 0f)
        {
            //playerTwo.DestroyPlayer();
            AddScore(PlayerType.PlayerOne);
            PlayerHealth[PlayerType.PlayerTwo] = playerHealthStart;
        }
    }
}

public enum PlayerType
{
    PlayerOne,
    PlayerTwo
}