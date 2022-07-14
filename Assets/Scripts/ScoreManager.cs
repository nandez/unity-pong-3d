using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    [SerializeField]
    private int playerScore;

    [SerializeField]
    private int aiScore;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnPlayerScore()
    {
        playerScore++;
    }

    public void OnAiScore()
    {
        aiScore++;
    }
}
