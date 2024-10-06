using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    [SerializeField] TMP_Text scoreDisplayText;
    private void Start()
    {
        ScoreDisplay();
    }
    private void ScoreDisplay()
    {
        scoreDisplayText.text = "Your Score :" + MOVE.score;
    }
}
