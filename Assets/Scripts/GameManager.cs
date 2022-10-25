using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    public GameState State { get; private set; } = GameState.SERVE;

    [SerializeField] private TMPro.TMP_Text aiScoreText;
    [SerializeField] private TMPro.TMP_Text playerScoreText;
    [SerializeField] private TMPro.TMP_Text infoMessageText;

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
        playerScoreText.SetText($"Player: {playerScore}");
        infoMessageText.SetText("Player Scored!");
        infoMessageText.gameObject.SetActive(true);

        Invoke(nameof(ResetToServeState), 2f);
    }

    public void onAiScore()
    {
        SetGameState(GameState.SCORE);
        aiScore++;
        aiScoreText.SetText($"AI: {aiScore}");
        infoMessageText.SetText("AI Scored!");
        infoMessageText.gameObject.SetActive(true);

        Invoke(nameof(ResetToServeState), 2f);
    }

    private void ResetToServeState()
    {
        SetGameState(GameState.SERVE);
        infoMessageText.gameObject.SetActive(false);
    }
}
