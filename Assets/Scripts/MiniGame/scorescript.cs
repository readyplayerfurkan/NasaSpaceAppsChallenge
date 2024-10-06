using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class scorescript : MonoBehaviour
{
    [SerializeField] private TMP_Text scoreText;
    public static int score;
    void Update()
    {
        scoreText.text = "Score: " + score.ToString();
    }
}
