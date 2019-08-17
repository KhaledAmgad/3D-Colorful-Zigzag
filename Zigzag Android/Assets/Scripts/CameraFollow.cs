using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public GameObject Ball;
    Vector3 offset;
    public float lerpRate;

    // Start is called before the first frame update

    void Start()
    {
        offset = Ball.transform.position - transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if(!GameManger.instance.gameOver)
        { Follow(); }
        
    }
    void Follow()
    {
        Vector3 pos = transform.position;
        Vector3 newPos = Ball.transform.position-offset;
        pos=Vector3.Lerp(pos, newPos, lerpRate * Time.deltaTime);
        transform.position = pos;
    }
}
