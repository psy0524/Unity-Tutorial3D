using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance = null;
    
    public TextMeshProUGUI currentScoreUI;
    public TextMeshProUGUI bestScoreUI;

    private int currentScore;
    private int bestScore;

    public int Score
    {
        get 
        { 
            return currentScore; 
        }
        set 
        {
            currentScore = value;
            currentScoreUI.text = "Score : " + currentScore;

            if (currentScore > bestScore)
            {
                bestScore = currentScore;
                bestScoreUI.text = "Best Score : " + bestScore;

                PlayerPrefs.SetInt("BestScore", bestScore);
            }
        }
    }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    private void Start()
    {
        bestScore = PlayerPrefs.GetInt("BestScore", 0);

        bestScoreUI.text = "Best Score : " + bestScore;
    }

    public void SetScore(int value)
    {
        
    }
}
