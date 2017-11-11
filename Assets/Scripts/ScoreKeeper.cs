using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreKeeper : MonoBehaviour
{
    private static int score;

    void Start()
    {
        Reset();
        
    }
    public static void AddScore(int points)
    {
        score += points;
    }

    public static void Reset()
    {
        score = 0;
    }

    public static int GetScore()
    {
        return score;
    }

    void Update()
    {
        this.GetComponent<Text>().text = score.ToString();
    }
}