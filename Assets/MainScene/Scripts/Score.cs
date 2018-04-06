using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour {

    int p1Score = 0;
    int p2Score = 0;

    Text p1Text;
    Text p2Text;

    void Start()
    {
        p1Text = GameObject.Find("p1_score").GetComponent<Text>();
        p2Text = GameObject.Find("p2_score").GetComponent<Text>();
    }

    public void IncreaseScore(int player)
    {
       

        if (player == 1)
        {
            p1Score++;
            p1Text.text = p1Score.ToString();
        }
        else if (player == 2)
        {
            p2Score++;
            p2Text.text = p2Score.ToString();
        }
    }

    public int GetScore(int player)
    {
        if (player == 1) return p1Score;
        else return p2Score;
    }
    public void ResetScore()
    {
        p1Score = 0;
        p2Score = 0;
        p1Text.text = p1Score.ToString();
        p2Text.text = p2Score.ToString();
    }

}
