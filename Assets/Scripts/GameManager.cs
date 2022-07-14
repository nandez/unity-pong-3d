using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public TMPro.TMP_Text scoreText;

    public AiController ai;
    public BallController ball;
    public PlayerController player;

    [SerializeField]
    private int playerScore;

    [SerializeField]
    private int aiScore;

    public void OnPlayerScore()
    {
        playerScore++;
        UpdateScoreText();
    }

    public void OnAiScore()
    {
        aiScore++;
        UpdateScoreText();
    }

    private void UpdateScoreText()
    {
        ai.ResetPosition();
        ball.ResetPosition();
        player.ResetPosition();

        scoreText.text = $"{aiScore} | {playerScore}";
    }
}