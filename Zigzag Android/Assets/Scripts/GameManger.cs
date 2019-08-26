using System.Collections;
using System.Collections.Generic;
using Imphenzia;
using UnityEngine;


public class GameManger : MonoBehaviour
{
    public static GameManger instance;
    public bool gameOver, pause;
    public GameObject ball;
    Vector3 oldSpeed;
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
        gameOver = false;
        pause = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void GameStart()
    {
        UiManger.instance.GameStart();
        GameObject.Find("PlatformSpawner").GetComponent<PlatformSpawner>().startSpawnPlatforms();
    }
    public void GameStop()
    {
        UiManger.instance.GameOver();
        ScoreManger.instance.stopScore();
    }
    public void pauseContinue()
    {

            if (!pause)
            {
                pause = true;
                Time.timeScale = 0;
            }
            else
            {
                Time.timeScale = 1;
                pause = false;
            }
        
    }
}
