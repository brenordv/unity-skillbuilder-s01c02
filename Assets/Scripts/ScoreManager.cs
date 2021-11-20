using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public Text scoreText;
    public int score = 100;
    public int spawnBlockCost = 10;
    public int coinPickupValue = 10;
    public Color negativeScoreColor = Color.red;
    public Color positiveScoreColor = Color.black;

    public void BlockSpawned()
    {
        ChangeScore(-spawnBlockCost);
    }

    public void CoinPickedUp()
    {
        ChangeScore(coinPickupValue);
    }

    private void ChangeScore(int points)
    {
        score += points;
        UpdateUiScoreText();
    }
    
    private void UpdateUiScoreText()
    {
        scoreText.text = $"Score: {score}";
        scoreText.color = score < 0 ? negativeScoreColor : positiveScoreColor;
    }
    
    
}