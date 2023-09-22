using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private enum State
    {
        GameStarted,
        GamePlaying,
        GameOver,
        GameCompleted,
    }
    public static GameManager Instance { get; private set; }

    public event EventHandler OnStateChanged;


    private float gamePlayingTimer;
    private float gamePlayingTimerMax = 300f;
    private State state;

    private void Awake()
    {
        Instance = this;

        state = State.GameStarted;

        
    }

    void Start()
    {
        FollowPlayer.Instance.CaughtPlayer += FollowPlayer_CaughtPlayer;
        GameCompleted.Instance.OnGameCompleted += GameCompleted_OnGameCompleted;
    }

    private void GameCompleted_OnGameCompleted(object sender, System.EventArgs e)
    {
        state = State.GameCompleted;
        OnStateChanged?.Invoke(this, EventArgs.Empty);
        
    }
    private void FollowPlayer_CaughtPlayer(object sender, System.EventArgs e)
    {
        if (FollowPlayer.Instance.HasPlayerBeenCaught())
        {
            state = State.GameOver;
            OnStateChanged?.Invoke(this, EventArgs.Empty);
        }

    }

    // Update is called once per frame
    void Update()
    {
        switch (state)
        {
            case State.GameStarted:
                gamePlayingTimer = gamePlayingTimerMax;
                state = State.GamePlaying;
                break;
            case State.GamePlaying:
                gamePlayingTimer -= Time.deltaTime;
                if(gamePlayingTimer < 0f)
                {
                    Debug.Log("coming from gamemanager");
                    state = State.GameOver; 
                    OnStateChanged?.Invoke(this, EventArgs.Empty);
                }
                break;
            case State.GameOver:
                break;
            case State.GameCompleted: 
                break;
        }
        
    }

    public bool IsGameOver()
    {
        return state == State.GameOver;
    }

    public bool IsGamePlaying()
    {
        return state == State.GamePlaying;
    }
    public float GetPlayingTime()
    {
        return 1- (gamePlayingTimer / gamePlayingTimerMax);
    }

    public bool IsGameCompleted()
    {
        return state == State.GameCompleted;
    }
}
