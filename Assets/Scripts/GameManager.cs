using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    public GameState State { get; private set; } = GameState.SERVE;

    private int playerScore;
    private int aiScore;

    public void Awake()
    {
        if (Instance == null)
            Instance = this;
    }

    public static void SetGameState(GameState state)
    {
        // TODO: validate state change...
        Instance.State = state;
    }

    public void OnPlayerScore()
    {
        SetGameState(GameState.SCORE);
        playerScore++;

        Invoke(nameof(ResetToServeState), 2f);
    }

    public void onAiScore()
    {
        SetGameState(GameState.SCORE);
        aiScore++;

        Invoke(nameof(ResetToServeState), 2f);
    }

    private void ResetToServeState()
    {
        SetGameState(GameState.SERVE);
    }
}
