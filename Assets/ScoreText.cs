using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreText : MonoBehaviour
{

    public TMP_Text scoreText;
    public TMP_Text multiText;
    public int score;
    public int scorePerNote;
    public int multi;
    public int streak;

    void Start()
    {
        score = 0;
        streak = 0;
        // Set starting multiplier to 1 and set points per on time input to 20
        scorePerNote = 20;
        multi = 1;
        scoreText = GetComponent<TextMeshProUGUI>();
        multiText = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    // Currently using Update() to test score updating functionality
    void Update()
    {
        // Score is currently set to just display the time to verify 
        // it's connected to the UI element correctly
        scoreText.SetText(DateTime.Now.ToString());
    }

    public void NoteSuccess() 
    {
        // Increment current streak counter and update multiplier at each streak threshold 
        streak++;
        if (streak < 5)
        {
            multi = 1;
        }
        else if (streak >= 5 && streak < 15)
        {
            multi = 4;
        }
        else if (streak >= 15 && streak < 30)
        {
            multi = 8;
        }
        else if (streak >= 30)
        {
            multi = 12;
        }

        // Multiply the score per note by current multiplier and update score
        score += scorePerNote * multi;
        scoreText.SetText(score.ToString());


    }

    public void NoteFail()
    {
        streak = 0;
    }
}
