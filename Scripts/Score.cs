using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public Text scoreText;
    public Text timeText;
    public Text yourScore;

    public static int score = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (score==-5)
        {
            Debug.Log("Score -Game Over!!");
            yourScore.text = "Score - Your Score " + score.ToString() + " Eggs";
            Application.Quit();
        }
    }

    public void AddScore(int amount)
    {
        score += amount;
        scoreText.text = score.ToString();
    }
    public void ReduceScore(int amount)
    {
        score -= amount;
        scoreText.text = score.ToString();
    }
}
