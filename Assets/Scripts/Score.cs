using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{
    
    public TextMeshProUGUI txt;
    private int score=0;
    public void trackScore(int points)
    {
        score += points;
        txt.text = score.ToString();
    }
}
