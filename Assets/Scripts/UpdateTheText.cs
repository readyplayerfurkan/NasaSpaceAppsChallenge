using TMPro;
using UnityEngine;

public class UpdateTheText : MonoBehaviour
{
    private int score;
    private TextMeshProUGUI scoreText;

    private void Start()
    {
        scoreText = GetComponent<TextMeshProUGUI>();
    }
    public void OnCircleClicked()
    {
        score += 250;
        scoreText.text = "Score : " + score.ToString();
    }
}
