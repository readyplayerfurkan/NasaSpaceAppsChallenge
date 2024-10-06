using TMPro;
using UnityEngine;

public class UpdateTheText : MonoBehaviour
{
    private int score;
    private TextMeshProUGUI scoreText;
    public TextMeshProUGUI endScore;

    private void Start()
    {
        scoreText = GetComponent<TextMeshProUGUI>();
    }
    public void OnCircleClicked()
    {
        score += 5;
        scoreText.text = "Score : " + score.ToString();
        endScore.text = "Your Score: " + score.ToString();
    }

    public void RestartedScore()
    {
        score = 0;
        scoreText.text = "Score: 0";
    }
}
