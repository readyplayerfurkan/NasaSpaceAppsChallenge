using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Over : MonoBehaviour
{
    [SerializeField] TMP_Text scoreDisplayText;

    private void start()
    {
        if (scoreDisplayText == null)
        {
            Debug.LogError("Score Display Text is not assigned!");
            return;
        }

        ScoreDisplay();
    }


    private void ScoreDisplay()
    {
        // MOVE sýnýfýndaki score deðiþkeninin güncel deðerini gösteriyoruz.
        scoreDisplayText.text = "Your Score : " + MOVE.score;
    }
}
