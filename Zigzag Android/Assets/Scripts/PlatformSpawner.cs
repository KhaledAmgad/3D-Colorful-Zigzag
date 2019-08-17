using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSpawner : MonoBehaviour
{
    public GameObject platform,diamond,ball;
    public Material blue;
    bool gotRandom;
    Color randomColor;
    Vector3 lastPos;
    float size;
    int minScore;
    // Start is called before the first frame update
    void Start()
    {
        lastPos = platform.transform.position;
        size = platform.transform.localScale.x;
        minScore = 0;
        gotRandom = false;
        for (int i = 0; i < 50; i++)
        {
            SpawnPlatforms();
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManger.instance.gameOver)
        { CancelInvoke("SpawnPlatforms"); }
	if (PlayerPrefs.GetInt("score") - minScore >100f)
        {
            randomColor = new Color(Random.value, Random.value, Random.value, 1.0f);
            gotRandom = true;
            minScore +=100;
            ball.GetComponent<BallController>().incrementSpeed();
            
        }
        if (gotRandom)
        {
            blue.color = Vector4.Lerp(blue.color, randomColor, Time.deltaTime);
            if (blue.color == randomColor)
            {
                gotRandom = false;
            }
        }
       
    }
    public void startSpawnPlatforms()
    {
        InvokeRepeating("SpawnPlatforms", 0.1f, 0.3f);
    }
    void SpawnPlatforms()
    {
        int rand = Random.Range(0, 6);
        if(rand<3)
        {
            spawnX();
        }
        else
        {
            spawnZ();
        }
    }

    void spawnX()
    {
        Vector3 pos = lastPos;
        pos.x += size;
        lastPos = pos;
        GameObject currentPlatform = Instantiate(platform, pos , Quaternion.identity) as GameObject;
        if (Random.Range(0,10)==0)
        {
            currentPlatform.GetComponentInChildren<TriggerChecker>().selfDiamend = Instantiate(diamond, new Vector3(pos.x, pos.y + 1, pos.z), diamond.transform.rotation) as GameObject;
        }
    }
    void spawnZ()
    {
        Vector3 pos = lastPos;
        pos.z += size;
        lastPos = pos;
        GameObject currentPlatform =  Instantiate(platform, pos, Quaternion.identity) as GameObject;
        if (Random.Range(0, 10) == 0)
        {
            currentPlatform.GetComponentInChildren<TriggerChecker>().selfDiamend =  Instantiate(diamond, new Vector3(pos.x, pos.y + 1, pos.z), diamond.transform.rotation) as GameObject;
        }
    }
}
