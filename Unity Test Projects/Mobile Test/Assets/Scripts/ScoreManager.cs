using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static int score;
    public static TextMeshProUGUI textScore;

    private void Start()
    {
        score = 0;
        textScore = GameObject.Find("Score").GetComponent<TextMeshProUGUI>();
        textScore.text = $"Donut Packed: 0";
    }


    public static void IncrementScore(int amount)
    {
        score += amount;
        textScore.text = $"Donut Packed: " + score;
    }
}
