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

    private void Start()
    {
        infoMessageText.SetText("(Press SPACEBAR or MOUSE to start)");
        infoMessageText.gameObject.SetActive(true);
    }

    public static void SetGameState(GameState state)
    {
        // TODO: validate state change...
        if (state == GameState.PLAY)
            Instance.infoMessageText.gameObject.SetActive(false);

        Instance.State = state;
    }

    public void OnPlayerScore()
    {
        SetGameState(GameState.SCORE);
        playerScore++;
        playerScoreText.SetText($"Player: {playerScore}");
        infoMessageText.SetText("You Scored!");
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
        infoMessageText.SetText("(Press SPACEBAR or MOUSE to start)");
        SetGameState(GameState.SERVE);
    }
}
