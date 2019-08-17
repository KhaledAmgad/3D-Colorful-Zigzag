using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManger : MonoBehaviour
{
    public static ScoreManger instance;
    public int score, highScore;
    void Awake()
    {
        if (instance==null)
        {
            instance = this;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        PlayerPrefs.SetInt("score", score);
    }

    // Update is called once per frame
    void Update()
    {
        PlayerPrefs.SetInt("score", score);
    }
    void incrementScore()
    {
        score++;
    }
    public void startScore()
    {
        InvokeRepeating("incrementScore", 0.1f, 0.5f);
    }
    public void stopScore()
    {
        CancelInvoke("incrementScore");
        PlayerPrefs.SetInt("score", score);
        if (PlayerPrefs.HasKey("highScore"))
        {
            if (score>PlayerPrefs.GetInt("highScore"))
            {
                PlayerPrefs.SetInt("highScore", score);
            }
        }
        else
        {
            PlayerPrefs.SetInt("highScore", score);
        }
    }
    
}
