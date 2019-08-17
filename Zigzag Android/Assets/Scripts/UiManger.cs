using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class UiManger : MonoBehaviour
{
    public static UiManger instance;
    public GameObject zigzagPanel, gameOverPanel,tapText;
    public Text score, currentScore, highScore1, highScore2;
    public Button pause;
    // Start is called before the first frame update
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
    void Start()
    {
        if (PlayerPrefs.HasKey("highScore"))
        {
            highScore1.text = "High Score: "+PlayerPrefs.GetInt("highScore").ToString();
        }
    }
    public void GameStart()
    {
        tapText.SetActive(false);
        zigzagPanel.GetComponent<Animator>().Play("PanelUp");
        currentScore.GetComponent<Animator>().Play("ScoreDrop");
        pause.GetComponent<Animator>().Play("PauseDown");

    }
    public void GameOver()
    {
        gameOverPanel.SetActive(true);
        score.text = PlayerPrefs.GetInt("score").ToString();
        highScore2.text = PlayerPrefs.GetInt("highScore").ToString();
        currentScore.GetComponent<Animator>().Play("WaitTouch");
        pause.GetComponent<Animator>().Play("WaitTouch");
        gameOverPanel.GetComponent<Animator>().Play("gameOverPanelApper");
    }

    public void Reset()
    {
        SceneManager.LoadScene(0);
    }

    // Update is called once per frame
    void Update()
    {
       currentScore.text = PlayerPrefs.GetInt("score").ToString();
    }
}
